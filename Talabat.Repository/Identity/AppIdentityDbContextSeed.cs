using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task IdentitySeedAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Samir Mohamed",
                    UserName = "Samir.Mohamed",
                    PhoneNumber = "01142406124",
                    Email = "Samir.Mohamed@gmail.com",
                    Address = new Address
                    {
                        Country = "Egypt",
                        City = "Cairo",
                        Street = "Tahrir",
                        FirstName = "Samir",
                        LastName = "Mohamed"
                    }
                };

                await userManager.CreateAsync(user, "P@ssw0rd");
            }
        }
    }
}
