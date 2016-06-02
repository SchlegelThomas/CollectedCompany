
using CollectedCompany.Models.Application;
using CollectedCompany.ServiceLayer.Integrations.Site.Bindings;

namespace CollectedCompany.ServiceLayer.Integrations.Site.Impl
{
    public class WebsiteResources : IWebsiteResources
    {
        private readonly ApplicationDbContext _appDbContext;

        public WebsiteResources( ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public ApplicationDbContext ApplicationResources
        {
            get { return _appDbContext; }
        }
    }
}