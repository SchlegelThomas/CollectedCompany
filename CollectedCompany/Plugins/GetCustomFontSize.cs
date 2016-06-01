using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollectedCompany.Models.Application;
using dotless.Core.Parser.Functions;
using dotless.Core.Parser.Infrastructure;
using dotless.Core.Parser.Infrastructure.Nodes;
using dotless.Core.Parser.Tree;
using dotless.Core.Plugins;
using dotless.Core.Utils;

namespace CollectedCompany.Plugins
{
    [DisplayName("UserFontPlugin")]
    public class UserFontPlugin: IFunctionPlugin
    {
        public Dictionary<string, Type> GetFunctions()
        {
            return new Dictionary<string, Type> 
            {
                { "getCustomFontSize", typeof(GetCustomFontSizeFunction) }
            };
        }
    }

    public class GetCustomFontSizeFunction : Function
    {
        
        protected override Node Evaluate(Env env)
        {
            Guard.ExpectNumArguments(1, Arguments.Count(), this, Location);
            Guard.ExpectNode<Keyword>(Arguments[0], this, Arguments[0].Location);

            ApplicationDbContext applicationDbContext = DependencyResolver.Current.GetService<ApplicationDbContext>();

            var fontSizeAttrName = Arguments[0] as Keyword;

            var customFontSize = applicationDbContext.HtmlFonts.FirstOrDefault(x => x.CssSelector == fontSizeAttrName.Value);

            var fontSize = customFontSize != null ? float.Parse(customFontSize.Value) : (float)12;

            return new Number(fontSize, "em");
        }
    }
}