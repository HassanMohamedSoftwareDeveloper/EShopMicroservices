namespace Basket.API.Models;

public class ShoppingCart
{
    #region PROPS :

    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = [];
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    #endregion PROPS :

    #region CTORS :

    public ShoppingCart(string userName)
    {
        this.UserName = userName;
    }

    public ShoppingCart()
    {
    }

    #endregion CTORS :
}