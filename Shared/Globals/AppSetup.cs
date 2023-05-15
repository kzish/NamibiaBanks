using Globals;
using Microsoft.AspNetCore.Identity;
using SharedModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharedProject.Globals
{
    internal class AppSetup
    {
        public static SignInManager<IdentityUser> signInManager;
        public static RoleManager<IdentityRole> roleManager;
        public static UserManager<IdentityUser> userManager;

        public static void Init()
        {
            CreateRoles();
            CreateDirectories();
            CreateAdminAccount();
            CreateKZAccount();
            SeedTobaccoSelfContractor();
        }

        public static void SeedTobaccoSelfContractor()
        {
            using (var db = new dbContext())
            {
                var self_contractor_exist = db.TobaccoContractors.Where(i => i.Name == "Self").Any();
                if (!self_contractor_exist)
                {
                    var self_contractor = new TobaccoContractor()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Self",
                    };
                    db.TobaccoContractors.Add(self_contractor);
                    db.SaveChanges();
                }
                db.Dispose();
            }
        }
        public static void CreateAdminAccount()
        {
            var db = new dbContext();

            var user_name = "superadmin@gmail.com";
            var user_email = user_name;
            var user_password = "Rubiem#99";

            var admin_exist = db.AspNetUsers.Where(u => u.UserName == user_name).Any();
            if (!admin_exist)
            {
                var user = new IdentityUser()
                {
                    UserName = user_name,
                    Email = user_email,
                };

                userManager.CreateAsync(user, user_password).Wait();
                userManager.AddToRoleAsync(user, "super_admin").Wait();
            }
        }
        public static void CreateKZAccount()
        {
            var db = new dbContext();

            var user_name = "kz@gmail.com";
            var user_email = user_name;
            var user_password = "Rubiem#99";

            var admin_exist = db.AspNetUsers.Where(u => u.UserName == user_name).Any();
            if (!admin_exist)
            {
                var user = new IdentityUser()
                {
                    UserName = user_name,
                    Email = user_email,
                };

                userManager.CreateAsync(user, user_password).Wait();
                userManager.AddToRoleAsync(user, "super_admin").Wait();
            }
        }
        public static void CreateDirectories()
        {
            //shared_folder_url
            if (!Directory.Exists(Common.shared_folder_url))
                Directory.CreateDirectory(Common.shared_folder_url);

            //path_raw
            if (!Directory.Exists(Common.path_storage))
                Directory.CreateDirectory(Common.path_storage);

            //logs
            if (!Directory.Exists(Common.path_logs))
                Directory.CreateDirectory(Common.path_logs);
        }
        public static void CreateRoles()
        {
            //super_admin
            if (!roleManager.RoleExistsAsync("super_admin").Result)
                roleManager.CreateAsync(new IdentityRole("super_admin")).Wait();

            //company_admin
            if (!roleManager.RoleExistsAsync("company_admin").Result)
                roleManager.CreateAsync(new IdentityRole("company_admin")).Wait();

            //users
            if (!roleManager.RoleExistsAsync("manage_users").Result)
                roleManager.CreateAsync(new IdentityRole("manage_users")).Wait();

            //settings
            if (!roleManager.RoleExistsAsync("manage_settings").Result)
                roleManager.CreateAsync(new IdentityRole("manage_settings")).Wait();



            //tobacco
            if (!roleManager.RoleExistsAsync("tobacco").Result)
                roleManager.CreateAsync(new IdentityRole("tobacco")).Wait();
            if (!roleManager.RoleExistsAsync("tobacco_inspector").Result)
                roleManager.CreateAsync(new IdentityRole("tobacco_inspector")).Wait();

            //maize
            if (!roleManager.RoleExistsAsync("maize").Result)
                roleManager.CreateAsync(new IdentityRole("maize")).Wait();
            if (!roleManager.RoleExistsAsync("maize_inspector").Result)
                roleManager.CreateAsync(new IdentityRole("maize_inspector")).Wait();

            //soybeans
            if (!roleManager.RoleExistsAsync("soybeans").Result)
                roleManager.CreateAsync(new IdentityRole("soybeans")).Wait();
            if (!roleManager.RoleExistsAsync("soybeans_inspector").Result)
                roleManager.CreateAsync(new IdentityRole("soybeans_inspector")).Wait();



        }

    }
}
