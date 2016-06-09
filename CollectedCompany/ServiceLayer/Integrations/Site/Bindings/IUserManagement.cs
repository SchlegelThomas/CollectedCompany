using System;
using CollectedCompany.Models;
using CollectedCompany.ServiceLayer.Integrations.Site.Models;

namespace CollectedCompany.ServiceLayer.Integrations.Site.Bindings
{
    public interface IUserManagement
    {
        void UpdateRoles(Permissions permissions);

        Permissions GetPermission(ApplicationUser user);
    }
}