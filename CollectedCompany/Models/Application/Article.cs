using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectedCompany.Models.Application
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public int CreatedById { get; set; }

        public String ThumbNail { get; set; }

        public String Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [Display(Name="Publish Date")]
        public DateTime PublishOn { get; set; }

        [Display(Name="Hash Tags")]
        public String TagCloud { get; set; }
    }
}