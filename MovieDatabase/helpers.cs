using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;


namespace MovieDatabase
{
    public static class helpers
    {
        public static string getUserID(System.Security.Principal.IIdentity ident)
        {
            var claimIdent = ident as ClaimsIdentity;
            if( claimIdent != null )
            {
                var userIdClaim = claimIdent.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    return userIdClaim.Value;
                }
                return "none";
            }
            else
            {
                return "none";
            }
        }

        public static bool isAdmin(System.Security.Principal.IPrincipal Controller, string userid)
        {
            if( Controller.Identity.IsAuthenticated)
            {
                var user = Controller.Identity;
                Models.ApplicationDbContext db = new Models.ApplicationDbContext();
                var store = new UserStore<Models.ApplicationUser>(db);
                var userMgr = new ApplicationUserManager(store);

                var s = userMgr.GetRolesAsync(userid).Result;
                foreach( string role in s )
                {
                    if (role == "Admin")
                        return true;
                }
                return false;
            }
            return false;
        }

     //   public static bool isAdmin(System.)
    }
}