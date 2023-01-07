using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Core.IService
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
