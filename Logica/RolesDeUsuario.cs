using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebFormsStore.Logic
{
    internal class RolesDeUsuario
    {
        internal void AddUserAndRole()
        {
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "SiteAdmin" role if it doesn't already exist.
            if (!roleMgr.RoleExists("SiteAdmin"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "SiteAdmin" });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            try
            {
                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var appUser = new ApplicationUser
                {
                    UserName = "admin@s2b.edu.br",
                    Email = "admin@s2b.edu.br"
                };
                IdUserResult = userMgr.Create(appUser, "admin");

                // If the new "SiteAdmin" user was successfully created, 
                // add the "SiteAdmin" user to the "canEdit" role. 
                if (!userMgr.IsInRole(userMgr.FindByEmail("admin@s2b.edu.br").Id, "SiteAdmin"))
                {
                    IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("admin@s2b.edu.br").Id, "SiteAdmin");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} throws Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }



            try
            {
                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var appUser = new ApplicationUser
                {
                    UserName = "cristianofx@gmail.com",
                    Email = "cristianofx@gmail.com"
                };
                IdUserResult = userMgr.Create(appUser, "admin");

                // If the new "SiteAdmin" user was successfully created, 
                // add the "SiteAdmin" user to the "canEdit" role. 
                if (!userMgr.IsInRole(userMgr.FindByEmail("cristianofx@gmail.com").Id, "SiteAdmin"))
                {
                    IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("cristianofx@gmail.com").Id, "SiteAdmin");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} throws Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }


        }
    }
}