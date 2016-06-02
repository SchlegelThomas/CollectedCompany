using CollectedCompany.Models.Application;

namespace CollectedCompany.ServiceLayer.Integrations.Site.Bindings
{
    public interface IWebsiteResources
    {
        ApplicationDbContext ApplicationResources { get; }
    }
}