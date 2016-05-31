using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollectedCompany.Models.Application;
using CollectedCompany.Models.Shared;

namespace CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings
{
    public interface IAdminPortalResources
    {
        ApplicationDbContext ApplicationResources { get; }

        SharedDbContext SharedResources { get; }
    }
}