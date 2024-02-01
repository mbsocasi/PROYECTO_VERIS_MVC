using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using PROYECTO_VERIS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PROYECTO_VERIS_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ApplicationDbContext context = new ApplicationDbContext();
            CrearRoles(context);
            CreateUsuarios(context);
            AssignarPermisos(context);
            context.Dispose();


        }


        private void CrearRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("SuperAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "SuperAdmin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Administrador"))
            {
                var role = new IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Medico"))
            {
                var role = new IdentityRole();
                role.Name = "Medico";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Paciente"))
            {
                var role = new IdentityRole();
                role.Name = "Paciente";
                roleManager.Create(role);
            }
        }
        private void CreateUsuarios(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = userManager.FindByEmailAsync("superadmin@gmail.com").Result;
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "SuperAdmin",
                    Email = "superadmin@gmail.com"
                };
                user.PasswordHash = PasswordHasher.ReferenceEquals(user.PasswordHash, null) ? userManager.PasswordHasher.HashPassword("123") : user.PasswordHash;
                userManager.Create(user);
            }
            var user2 = userManager.FindByEmailAsync("Admin@hotmail.com").Result;
            if (user2 == null)
            {
                user2 = new ApplicationUser
                {
                    UserName = "ADM",
                    Email = "Admin@hotmail.com"
                };
                user2.PasswordHash = PasswordHasher.ReferenceEquals(user2.PasswordHash, null) ? userManager.PasswordHasher.HashPassword("123") : user.PasswordHash;
                userManager.Create(user2);
            }


        }
        private void AssignarPermisos(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var user = userManager.FindByName("SuperAdmin");
            if (!userManager.IsInRole(user.Id, "SuperAdmin"))
            {
                userManager.AddToRole(user.Id, "SuperAdmin");
            }
            
        }
    }

}

