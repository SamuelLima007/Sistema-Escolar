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
            var userid = int.Parse(id);
            if (userid != null)
            {
                return userid;
            }
            return -1;
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