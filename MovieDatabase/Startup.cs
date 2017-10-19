using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Linq;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(MovieDatabase.Startup))]
namespace MovieDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            this.createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            Models.ApplicationDbContext db = new Models.ApplicationDbContext();

            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var store = new UserStore<Models.ApplicationUser>(db);
            var userMgr = new ApplicationUserManager(store);
            //var userMgr = new ApplicationUserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(db));

            if (!roleMgr.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleMgr.Create(role);
            }

            var defaultUserName = ConfigurationManager.AppSettings["defaultUserName"];
            var defaultPassword = ConfigurationManager.AppSettings["defaultPassword"];
            var defaultEmail = ConfigurationManager.AppSettings["defaultEmail"];
            try
            {
                Models.ApplicationUser user = db.Users.Where(u => u.UserName == defaultUserName).Single();
            }
            catch( System.InvalidOperationException /* ex */)
            {
                var tempUser = new Models.ApplicationUser();
                tempUser.UserName = defaultUserName;
                tempUser.Email = defaultEmail;
                string pass = defaultPassword;
                var chkUser = userMgr.Create(tempUser, pass);

                if (chkUser.Succeeded)
                    userMgr.AddToRole(tempUser.Id, "Admin");
            }


            if( !roleMgr.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleMgr.Create(role);
            }
        }
    }
}
