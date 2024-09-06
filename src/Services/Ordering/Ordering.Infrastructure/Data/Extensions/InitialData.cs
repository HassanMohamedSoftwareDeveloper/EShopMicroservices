namespace Ordering.Infrastructure.Data.Extensions;

internal static class InitialData
{
    public static IEnumerable<Customer> Customers =>
        [
        Customer.Create(CustomerId.Of(new Guid("a0017eb8-2322-44b4-9a88-609adbbe7edc")),"Hassan Mohamed","hassanmohamed_hm@hotmail.com"),
        Customer.Create(CustomerId.Of(new Guid("84b77d25-9d63-4993-82b3-cc67a5eb67f6")),"Ahmed Mohamed","ahmedmohamed_am@hotmail.com"),
        ];

    public static IEnumerable<Product> Products =>
        [
        Product.Create(ProductId.Of(new Guid("9cdabfbd-ffae-43c6-b852-41deb6d165ff")),"Samsung Ultra S24",60000),
        Product.Create(ProductId.Of(new Guid("27c272c7-1daa-4264-9351-1157ddbcf3a2")),"IPhone 15 Pro Max",65000),
        Product.Create(ProductId.Of(new Guid("533e30ea-49f8-4818-a337-80a77d7f3f8c")),"Oppo Reno 11",16000),
        Product.Create(ProductId.Of(new Guid("9a0b1d62-7073-4937-8214-46d7c53cb0ff")),"Oppo Reno 12F",15000),
        ];

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Hassan", "Mohamed", "hassanmohamed_hm@hotmail.com", "Ellozy Elgdeda-markz sherbien", "Egypt", "Dakhlia", "55555");
            var address2 = Address.Of("Ahmed", "Mohamed", "ahmedmohamed_am@hotmail.com", "Ellozy Elgdeda-markz sherbien", "Egypt", "Dakhlia", "55555");

            var payment1 = Payment.Of("HASSANMOHAMED", "1234567891234567", "06/28", "123", 1);
            var payment2 = Payment.Of("AHMEDMOHAMED", "9876543219876543", "02/30", "258", 1);

            var order1 = Order.Create(OrderId.Of(Guid.NewGuid()),
                                      CustomerId.Of(new Guid("a0017eb8-2322-44b4-9a88-609adbbe7edc")),
                                      OrderName.Of("ORD_1"),
                                      shippingAddress: address1,
                                      billingAddress: address1,
                                      payment1);

            order1.Add(ProductId.Of(new Guid("9cdabfbd-ffae-43c6-b852-41deb6d165ff")), 1, 60000);

            var order2 = Order.Create(OrderId.Of(Guid.NewGuid()),
                                      CustomerId.Of(new Guid("84b77d25-9d63-4993-82b3-cc67a5eb67f6")),
                                      OrderName.Of("ORD_2"),
                                      shippingAddress: address2,
                                      billingAddress: address2,
                                      payment2);

            order2.Add(ProductId.Of(new Guid("533e30ea-49f8-4818-a337-80a77d7f3f8c")), 1, 16000);

            return [order1, order2];
        }
    }
}