using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SamaritanCore.DataModel.Models;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.EntityFrameworkCore;

namespace SamaritanCore.DataModel
{
    public class DummyData
    {
        public static async Task Initialize(SamaritanDbContext context,
                            UserManager<ApplicationUser> userManager,
                            RoleManager<ApplicationRole> roleManager/*, IApplicationBuilder app*/)
        {
            context.Database.EnsureCreated();
            //SamaritanDbContext context2 = app.ApplicationServices.GetRequiredService<SamaritanDbContext>();
            //context2.Database.Migrate();

            string admin_Id = "";

            string role_admin = "Administrator";
            string desc_admin = "Администратор сайта, имеет полный доступ";

            string role_user = "User";
            string desc_user = "Пользователь сайта, имеет доступ только к своему профилю";

            string role_volunteer = "Volunteer";
            string desc_volunteer = "Волонтер, может учавствовать в волонтерской программе";

            string password = "9*]egaRoFog)?";

            if (await roleManager.FindByNameAsync(role_admin) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role_admin, desc_admin));
            }

            if (await roleManager.FindByNameAsync(role_user) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role_user, desc_user));
            }

            if (await roleManager.FindByNameAsync(role_volunteer) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role_volunteer, desc_volunteer));
            }

            if ((await userManager.GetUsersInRoleAsync(role_admin)).Count == 0)
            {
                var user = new ApplicationUser
                {
                    UserName = "farik.dp.2008@gmail.com",
                    FirstName = "Valeriy",
                    Email = "farik.dp.2008@gmail.com",
                    PhoneNumber = "+38(097)8360372"
                };

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role_admin);
                }

                admin_Id = user.Id;
            }

            
        }
    }
}
