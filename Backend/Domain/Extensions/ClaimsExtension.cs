using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;


namespace Backend.Domain.Extensions
{
    public static class ClaimsExtension
    {
        public static int GetUserLoggedId(this ClaimsPrincipal User)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (id != null)
            {
                var userid = int.Parse(id);
                return userid;
            }
           
    
             return 0;
        }

        public static string GetUserLoggedRole(this ClaimsPrincipal User)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            if (role != null)
            {
                return role;
            }
            return "";

        }
    }
}