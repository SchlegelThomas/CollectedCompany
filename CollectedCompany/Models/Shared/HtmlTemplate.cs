using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectedCompany.Models.Shared
{
    public class HtmlTemplate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Boolean IsActive { get; set; }

        public String Name { get; set; }

        public String TemplateUrl { get; set; }

        public virtual ICollection<HtmlColorVariable> Colors { get; set; }

        public virtual ICollection<HtmlFontSizeVariable> Fonts { get; set; }

        public virtual ICollection<HtmlImageVariable> Images { get; set; }
    }

    public class HtmlColorVariable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String CssSelector { get; set; }

        public String Value { get; set; }
    }


    public class HtmlFontSizeVariable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String CssSelector { get; set; }

        public String Value { get; set; }
    }

    public class HtmlImageVariable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String CssSelector { get; set; }

        public String Value { get; set; }
    }
}