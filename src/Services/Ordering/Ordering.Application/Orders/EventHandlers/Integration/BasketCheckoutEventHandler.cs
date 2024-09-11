using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger) : IConsumer<BasketCheckoutEvent>
{
    #region Methods :

    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }

    #endregion Methods :

    #region Helpers :

    private static CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName, message.CardNumber, message.Expiration, message.CVV, message.PaymentMethod);
        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(Id: orderId,
                                    CustomerId: message.CustomerId,
                                    OrderName: message.UserName,
                                    ShippingAddress: addressDto,
                                    BillingAddress: addressDto,
                                    Payment: paymentDto,
                                    Status: OrderStatus.Pending,
                                    OrderItems: [new OrderItemDto(orderId, new Guid("9cdabfbd-ffae-43c6-b852-41deb6d165ff"), 1, 60000)]);

        return new CreateOrderCommand(orderDto);
    }

    #endregion Helpers :
}