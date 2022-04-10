namespace CatalogService.Mapping;
public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<AddItemToBasketCommand, BasketItem>();
        CreateMap<UpdateBasketCommand, BasketItem>();
    }
}
