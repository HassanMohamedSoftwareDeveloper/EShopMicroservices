using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
{
    #region PROPS :

    public DbSet<Coupon> Coupons { get; set; }

    #endregion PROPS :
}