using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Application;

namespace CollectedCompany.Plugins
{
    public class CustomViewEngine : RazorViewEngine 
    {
        public CustomViewEngine()
        {
            ApplicationDbContext applicationDbContext = DependencyResolver.Current.GetService<ApplicationDbContext>();

            var activeTheme = applicationDbContext.HtmlTemplates.FirstOrDefault(x => x.IsActive);

            var viewLocations = new[] 
            {  
                "~/Themes/"+activeTheme.TemplateUrl+"/Views/{0}.cshtml",
                "~/Themes/"+activeTheme.TemplateUrl+"/Views/{1}/{0}.cshtml",
                "~/Themes/"+activeTheme.TemplateUrl+"/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",  
                "~/Views/{1}/{0}.cshtml",  
                "~/Views/Shared/{0}.cshtml",   
            };

            PartialViewLocationFormats = viewLocations;
            ViewLocationFormats = viewLocations;
        }
    }
}