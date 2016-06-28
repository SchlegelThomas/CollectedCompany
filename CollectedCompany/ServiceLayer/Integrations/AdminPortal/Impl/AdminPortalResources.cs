using CollectedCompany.Models.Application;
using CollectedCompany.Models.Shared;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;
using CollectedCompany.ServiceLayer.Integrations.AzureStorage.Bindings;
using CollectedCompany.ServiceLayer.Integrations.CityState.Bindings;
using CollectedCompany.ServiceLayer.Integrations.Site.Bindings;

namespace CollectedCompany.ServiceLayer.Integrations.AdminPortal.Impl
{
    public class AdminPortalResources: IAdminPortalResources
    {
        private readonly SharedDbContext _sharedDbContext;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ICityStateApiService _cityStateApiService;
        private readonly IUserManagement _userManagement;
        private readonly IAzureStorageService _imageStorageService;

        public AdminPortalResources(SharedDbContext sharedDbContext, ApplicationDbContext appDbContext, ICityStateApiService cityStateApiService, IUserManagement userManagement, IAzureStorageService imageStorageService)
        {
            _sharedDbContext = sharedDbContext;
            _appDbContext = appDbContext;
            _cityStateApiService = cityStateApiService;
            _userManagement = userManagement;
            _imageStorageService = imageStorageService;
        }


        public ApplicationDbContext ApplicationResources
        {
            get { return _appDbContext; }
        }

        public SharedDbContext SharedResources
        {
            get { return _sharedDbContext; }
        }

        public ICityStateApiService CityStateApi
        {
            get { return _cityStateApiService; }
        }


        public IUserManagement UserManagementService
        {
            get { return _userManagement; }
        }


        public IAzureStorageService ImageStorageService
        {
            get { return _imageStorageService; }
        }
    }
}