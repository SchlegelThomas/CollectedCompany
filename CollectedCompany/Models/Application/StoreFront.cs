using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectedCompany.Models.Application
{
    public class StoreFront
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public String LogoImageUrl { get; set; }

        public String BusinessName { get; set; }

        public String FavIconUrl { get; set; }

        public String ContactEmail { get; set; }

        public String Address { get; set; }

        public String Address2 { get; set; }

        public String State { get; set; }

        public String City { get; set; }

        public String Zip { get; set; }

        public String ContactPhone { get; set; }

        public String TimeZoneId { get; set; }

        public virtual EbayIntegration Ebay { get; set; }

        public virtual TcgPlayerIntegration Tcg { get; set; }

        public virtual AmazonIntegration Amazon { get; set; }

        public virtual FacebookIntegration Facebook { get; set; }

        public virtual TwitterIntegration Twitter { get; set; }

        public virtual InstagramIntegration Instagram { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }

        public virtual StoreAddress StoreAddress { get; set; }
        

    }
}