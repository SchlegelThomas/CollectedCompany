using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models;

namespace CollectedCompany.Attributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params UserType[] roles)
            : base()
        {
            Roles = string.Join(",", roles.Select(role => role.ToString()).ToList());
        }
    }
}