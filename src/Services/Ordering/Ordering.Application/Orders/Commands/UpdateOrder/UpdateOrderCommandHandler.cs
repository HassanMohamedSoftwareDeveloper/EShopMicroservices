namespace Ordering.Application.Orders.Commands.UpdateOrder;

internal sealed class UpdateOrderCommandHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    #region Methods :

    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.Order.Id);
        var order = await dbContext.Orders.FindAsync([orderId], cancellationToken);

        if (order is null)
            throw new OrderNotFoundException(command.Order.Id);

        UpdateOrderWithNewValues(order, command.Order);

        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateOrderResult(true);
    }

    #endregion Methods :

    #region Helpers :

    private static void UpdateOrderWithNewValues(Order order, OrderDto orderDto)
    {
        var updatedShippingAddress = Address.Of(orderDto.ShippingAddress.FirstName,
                                                orderDto.ShippingAddress.LastName,
                                                orderDto.ShippingAddress.EmailAddress,
                                                orderDto.ShippingAddress.AddressLine,
                                                orderDto.ShippingAddress.Country,
                                                orderDto.ShippingAddress.State,
                                                orderDto.ShippingAddress.ZipCode);

        var updatedBillingAddress = Address.Of(orderDto.BillingAddress.FirstName,
                                               orderDto.BillingAddress.LastName,
                                               orderDto.BillingAddress.EmailAddress,
                                               orderDto.BillingAddress.AddressLine,
                                               orderDto.BillingAddress.Country,
                                               orderDto.BillingAddress.State,
                                               orderDto.BillingAddress.ZipCode);

        var updatedPayment = Payment.Of(orderDto.Payment.CardName,
                                        orderDto.Payment.CardNumber,
                                        orderDto.Payment.Expiration,
                                        orderDto.Payment.Cvv,
                                        orderDto.Payment.PaymentMethod);

        order.Update(OrderName.Of(orderDto.OrderName),
                     updatedShippingAddress,
                     updatedBillingAddress,
                     updatedPayment,
                     orderDto.Status);
    }

    #endregion Helpers :
}