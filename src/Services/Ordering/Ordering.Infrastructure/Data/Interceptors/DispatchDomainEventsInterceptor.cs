﻿using MediatR;

namespace Ordering.Infrastructure.Data.Interceptors;

public class DispatchDomainEventsInterceptor(IMediator mediator) : SaveChangesInterceptor
{
    #region Methods :

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    #endregion Methods :

    #region Helpers :

    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context is null) return;

        var aggregates = context.ChangeTracker.Entries<IAggregate>()
            .Where(a => a.Entity.DomainEvents.Any())
            .Select(a => a.Entity);

        if (!aggregates.Any()) return;

        var domainEvents = aggregates.SelectMany(a => a.DomainEvents).ToList();
        if (!domainEvents.Any()) return;

        aggregates.ToList().ForEach(a => a.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }

    #endregion Helpers :
}