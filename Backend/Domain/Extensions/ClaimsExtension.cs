using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;


namespace Backend.Domain.Extensions
{
    public static class ClaimsExtension
    {
        public static int GetUserLoggedId(ClaimsPrincipal User)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userid = int.Parse(id);
            return userid;
        }

          public static string GetUserLoggedRole(ClaimsPrincipal User)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            return role;
        }
    }
}