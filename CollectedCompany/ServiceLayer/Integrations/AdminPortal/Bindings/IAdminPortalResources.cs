using CollectedCompany.Models.Application;
using CollectedCompany.Models.Shared;
using CollectedCompany.ServiceLayer.Integrations.AzureStorage.Bindings;
using CollectedCompany.ServiceLayer.Integrations.CityState.Bindings;
using CollectedCompany.ServiceLayer.Integrations.Site.Bindings;

namespace CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings
{
    public interface IAdminPortalResources
    {
        ApplicationDbContext ApplicationResources { get; }

        SharedDbContext SharedResources { get; }

        ICityStateApiService CityStateApi { get; }

        IUserManagement UserManagementService { get; }

        IAzureStorageService ImageStorageService { get; }
    }
}