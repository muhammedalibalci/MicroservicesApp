namespace CatalogService.SeedData;
public static class CatalogSeedData
{
    public static void AddAddCatalogSeedData(this IServiceCollection services)
    {
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        var context = serviceProvider.GetRequiredService<CatalogContext>();
        SetCatalogSeedData(context);
    }
    private static void SetCatalogSeedData(CatalogContext context)
    {
        var list = new List<CatalogItem>
            {
                new()
                {
                    Id = 1,
                    AvailableStock = 100,
                    Description = "iphone",
                    Name = "iphone 11",
                    Price = 1500
                },
                new()
                {
                    Id = 2,
                    AvailableStock = 50,
                    Description = "macbook",
                    Name = "macbook air",
                    Price = 2500
                }
            };

        context.AddRange(list);
        context.SaveChanges();
    }
}
