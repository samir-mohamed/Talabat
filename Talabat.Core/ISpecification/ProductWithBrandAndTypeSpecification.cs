using Talabat.Core.Entities;

namespace Talabat.Core.ISpecification
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypeSpecification(ProductSpecificationParams productParams)
            : base(
                    p =>
                    (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search.ToLower())) &&
                    (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId.Value) &&
                    (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId.Value)
                  )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }

            ApplyPagination(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);
        }

        public ProductWithBrandAndTypeSpecification(int id)
            : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
