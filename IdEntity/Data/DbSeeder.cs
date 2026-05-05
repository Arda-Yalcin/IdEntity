using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdEntity.Models;
using Microsoft.AspNetCore.Identity;

namespace IdEntity.Data
{
    public static class DbSeeder
    {
        public static async Task RoleEkle(IServiceProvider serviceProvider)
        {
            var roleManager=serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager=serviceProvider.GetRequiredService<UserManager<AppUser>>();
            //Rolleri oluşturma.
            string[] roller={"Admin","Member"};
            foreach(var rol in roller)
            {
                if(!await roleManager.RoleExistsAsync(rol))
                {
                    await roleManager.CreateAsync(new IdentityRole(rol));
                }
            }
            // varsayılan kullanıcı oluştuır
            var adminMail="admin@proje.com";
            var adminUser= await userManager.FindByEmailAsync(adminMail);
            if (adminUser == null)
            {
                var newAdmin=new AppUser
                {
                    UserName=adminMail,
                    Email=adminMail,
                    Ad="Arda",
                    Soyad="Yonetici",
                    EmailConfirmed=true
                };
            var createAdmin=await userManager.CreateAsync(adminUser,"Admin123");
                if (createAdmin.Succeeded)
                {
                    await userManager.AddClaimAsync(newAdmin,new Claim("TamAd",newAdmin.Ad+""+newAdmin.Soyad));
                    await userManager.AddToRoleAsync(newAdmin,"Admin");
                }
            }
        }
    }
}