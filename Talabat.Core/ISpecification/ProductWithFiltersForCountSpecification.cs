using Talabat.Core.Entities;

namespace Talabat.Core.ISpecification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationParams productParams)
            : base(
                    p =>
                    (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search.ToLower())) &&
                    (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId.Value) &&
                    (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId.Value)
                  )
        {
        }
    }
}
