﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Application;
using CollectedCompany.Models.Shared;
using dotless.Core.Parser.Functions;
using dotless.Core.Parser.Infrastructure;
using dotless.Core.Parser.Infrastructure.Nodes;
using dotless.Core.Parser.Tree;
using dotless.Core.Plugins;
using dotless.Core.Utils;
using Color = dotless.Core.Parser.Tree.Color;

namespace CollectedCompany.Plugins
{
    [DisplayName("UserProfilePlugin")]
    public class UserProfilePlugin : IFunctionPlugin
    {
        public Dictionary<string, Type> GetFunctions()
        {
            return new Dictionary<string, Type> 
            {
                { "getCustomColor", typeof(GetCustomColorFunction) }
            };
        }
    }

    public class GetCustomColorFunction : Function
    {
        private const String DefaultBaseColor = "#D46A6A";

        protected override Node Evaluate(Env env)
        {
            Guard.ExpectNumArguments(1, Arguments.Count(), this, Location);
            Guard.ExpectNode<Keyword>(Arguments[0], this, Arguments[0].Location);

            ApplicationDbContext applicationDbContext = DependencyResolver.Current.GetService<ApplicationDbContext>();

            Keyword colorAttrName = Arguments[0] as Keyword;

            HtmlColorVariable customColor = applicationDbContext.HtmlColors.FirstOrDefault(x => x.CssSelector == colorAttrName.Value);

            String colorString = customColor != null ? customColor.Value : DefaultBaseColor;
            
            System.Drawing.Color color = ColorTranslator.FromHtml(colorString);
            

            return new Color(color.ToArgb());
        }
    }
}