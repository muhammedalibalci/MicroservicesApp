using CatalogService.CQRS.Commands.CreateCatalog;

namespace CatalogService.Mapping;
public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCatalogCommand, CatalogItem>();
        CreateMap<UpdateCatalogCommand, CatalogItem>();
    }
}
