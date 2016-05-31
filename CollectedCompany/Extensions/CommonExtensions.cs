using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Caching;
using System.Web.Mvc;
using CollectedCompany.Models;

namespace CollectedCompany.Extensions
{
    public static class CommonExtensions
    {
        public static string FirstName(this IPrincipal user)
        {
            if (!IsAuthenticated(user)) return "";

            var claimsIdentity = user.Identity as ClaimsIdentity;

            if (claimsIdentity == null || claimsIdentity.Claims == null) return "";

            return GetClaimValue(claimsIdentity, ClaimKeys.FirstName);
        }

        public static string LastName(this IPrincipal user)
        {
            if (!IsAuthenticated(user)) return "";

            var claimsIdentity = user.Identity as ClaimsIdentity;

            if (claimsIdentity == null || claimsIdentity.Claims == null) return "";

            return GetClaimValue(claimsIdentity, ClaimKeys.LastName);
        }

        public static Boolean IsAdmin(this IPrincipal user)
        {
            if (!IsAuthenticated(user)) return false;

            var claimsIdentity = user.Identity as ClaimsIdentity;

            if (claimsIdentity == null || claimsIdentity.Claims == null) return false;

            return Boolean.Parse(GetClaimValue(claimsIdentity, ClaimKeys.Admin));
        }

        static bool IsAuthenticated(IPrincipal user)
        {
            return user.Identity.IsAuthenticated;
        }

        static string GetClaimValue(ClaimsIdentity claimsIdentity, ClaimKeys claimKey)
        {
            Claim claim = claimsIdentity.FindFirst(x => x.Type == claimKey.ToString());

            return claim != null ? claim.Value : "";
        }
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }

    public static class JavascriptExtension
    {
        public static MvcHtmlString IncludeVersionedJs(this HtmlHelper helper, string filename)
        {
            string version = GetVersion(helper, filename);
            return MvcHtmlString.Create("<script type='text/javascript' src='" + filename + version + "'></script>");
        }

        public static MvcHtmlString IncludeVersionedCss(this HtmlHelper helper, String filename)
        {
            string version = GetVersion(helper, filename);
            return MvcHtmlString.Create("<link rel='stylesheet' href='" + filename + version + "'/>");
        }

        private static string GetVersion(this HtmlHelper helper, string filename)
        {
            var context = helper.ViewContext.RequestContext.HttpContext;

            if (context.Cache[filename] == null)
            {
                var physicalPath = context.Server.MapPath(filename);
                var version = "?v=" +
                  new System.IO.FileInfo(physicalPath).LastWriteTime
                    .ToString("yyyyMMddhhmmss");
                context.Cache.Add(physicalPath, version, null,
                  DateTime.Now.AddMinutes(1), TimeSpan.Zero,
                  CacheItemPriority.Normal, null);
                context.Cache[filename] = version;
                return version;
            }
            else
            {
                return context.Cache[filename] as string;
            }
        }


    }
}