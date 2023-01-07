namespace Talabat.Core.ISpecification
{
    public class ProductSpecificationParams
    {
        private const int MaxPageSize = 10;

        private int pageSize = 5;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public int PageIndex { get; set; } = 1;

        public string Search { get; set; }
        public string Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
    }
}
