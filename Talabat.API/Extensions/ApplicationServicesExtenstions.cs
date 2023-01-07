using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Talabat.API.Errors;
using Talabat.API.Mapper;
using Talabat.Core.IRepository;
using Talabat.Core.IService;
using Talabat.Repository;
using Talabat.Service;

namespace Talabat.API.Extensions
{
    public static class ApplicationServicesExtenstions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(MappingProfiles));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(m => m.Value.Errors.Count > 0)
                    .SelectMany(m => m.Value.Errors)
                    .Select(e => e.ErrorMessage);

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                    ;
                };
            });

            return services;
        }
    }
}
