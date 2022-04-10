namespace BasketService.Context;
public class BasketContext : DbContext
{
    public BasketContext(DbContextOptions<BasketContext> options) : base(options)
    {
    }

    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<BasketCheckout> BasketCheckouts{ get; set; }
    public DbSet<CustomerBasket> CustomerBaskets  { get; set; }
}
