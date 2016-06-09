using System;
using System.Collections.Generic;
using CollectedCompany.Models;

namespace CollectedCompany.ServiceLayer.Integrations.Site.Models
{
    public class Permissions
    {
        public ApplicationUser User { get; set; }

        public List<UserPermission> UserRoles { get; set; }

        public List<StaffPermission> StaffRoles { get; set; }
    }

    public class UserPermission
    {
        public Boolean IsInRole { get; set; }

        public UserRoles UserRole { get; set; }
    }

    public class StaffPermission
    {
        public Boolean IsInRole { get; set; }

        public StaffRoles UserRole { get; set; }
    }
}