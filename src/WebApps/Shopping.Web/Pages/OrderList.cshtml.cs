namespace Shopping.Web.Pages
{
    public class OrderListModel(IOrderingService orderingService, ILogger<OrderListModel> logger) : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("a0017eb8-2322-44b4-9a88-609adbbe7edc");
            var response = await orderingService.GetOrdersByCustomer(customerId);
            Orders = response.Orders;
            return Page();
        }
    }
}