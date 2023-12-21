using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Blog.Models;

namespace Blog.Extesions
{
    public static class RoleClaimsExetension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };
            result.AddRange(
                user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Slug))
            );

            return result;
        }
    }
}