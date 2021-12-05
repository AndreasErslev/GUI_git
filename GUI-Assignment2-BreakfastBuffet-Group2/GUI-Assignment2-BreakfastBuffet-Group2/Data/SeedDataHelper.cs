using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BreakfastBuffet2.Data
{
    // static så der ikke skal oprettes instansen - ingen tilstand men bare skal køres
    public static class SeedDataHelper
    {
        public static void SeedData(UserManager<IdentityUser> userManager,
            ILogger log)
        {
            SeedEmployee(userManager, log);
            SeedWaiter(userManager, log);
        }

        public static void SeedWaiter(UserManager<IdentityUser> userWaiter, ILogger log)
        {
            const string waiterEmail = "Waiter@localhost.dk";
            const string waiterPassword = "SecretWaiter";

            if (userWaiter.FindByEmailAsync(waiterEmail).Result == null)
            {
                log.LogWarning("Seeding the admin user");
                var user = new IdentityUser()
                {
                    UserName = waiterEmail,
                    Email = waiterEmail,
                };

                IdentityResult result = userWaiter.CreateAsync(user, waiterPassword).Result;
                if (result.Succeeded)
                {
                    var waiterClaim = new Claim("Waiter", "Yes");
                    userWaiter.AddClaimAsync(user, waiterClaim).Wait();
                }
            }
        }


        public static void SeedEmployee(UserManager<IdentityUser> userEmployee, ILogger log)
        {
            const string employeeEmail = "Employee@localhost.dk";
            const string employeePassword = "OnlyEmployee";

            if (userEmployee.FindByEmailAsync(employeeEmail).Result == null)
            {
                log.LogWarning("Seeding the employee user");
                var user = new IdentityUser()
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                };

                IdentityResult result = userEmployee.CreateAsync(user, employeePassword).Result;
                if (result.Succeeded)
                {
                    var employeeClaim = new Claim("Employee", "Yes");
                    userEmployee.AddClaimAsync(user, employeeClaim).Wait();
                }
            }
        }
    }
}
