using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.IRepository
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
