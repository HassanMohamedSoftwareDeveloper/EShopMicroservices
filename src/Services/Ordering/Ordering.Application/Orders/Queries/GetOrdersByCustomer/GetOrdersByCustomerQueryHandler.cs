namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

internal sealed class GetOrdersByCustomerQueryHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
{
    public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);

        var orderDtos = orders.ToOrderDtoList();
        return new Task<GetOrdersByCustomerResult>(orderDtos);
    }
}