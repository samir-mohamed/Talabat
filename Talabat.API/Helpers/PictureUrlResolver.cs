using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.API.Dtos;
using Talabat.Core.Entities;

namespace Talabat.API.Helpers
{
    public class PictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        public PictureUrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
                return null;
            return $"{Configuration["BaseApiUrl"]}{source.PictureUrl}";
        }
    }
}
