using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectedCompany.Models.Application
{
    public class Settings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual StoreFront StoreFront { get; set; }

        public String AccountEmail { get; set; }

        public String CustomerEmail { get; set; }
    }

    public class StoreAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String LegalNameOfBusiness { get; set; }

        public String PhoneNumber { get; set; }

        public String Street { get; set; }

        [Display(Name="Apt, suite, etc. (optional)")]
        public String Street2 { get; set; }

        public String City { get; set; }

        public String Zip { get; set; }

        public String Country { get; set; }

        public String State { get; set; }

        public String Email { get; set; }
    }
}