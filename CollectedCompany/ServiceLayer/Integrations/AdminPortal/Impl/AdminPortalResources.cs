using CollectedCompany.Models.Application;
using CollectedCompany.Models.Shared;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.ServiceLayer.Integrations.AdminPortal.Impl
{
    public class AdminPortalResources: IAdminPortalResources
    {
        private readonly SharedDbContext _sharedDbContext;
        private readonly ApplicationDbContext _appDbContext;

        public AdminPortalResources(SharedDbContext sharedDbContext, ApplicationDbContext appDbContext)
        {
            _sharedDbContext = sharedDbContext;
            _appDbContext = appDbContext;
        }


        public ApplicationDbContext ApplicationResources
        {
            get { return _appDbContext; }
        }

        public SharedDbContext SharedResources
        {
            get { return _sharedDbContext; }
        }
    }
}