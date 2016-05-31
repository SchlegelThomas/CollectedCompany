using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectedCompany.Models.Application
{
    public class AmazonIntegration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String AmazonApiKey { get; set; }

        public String Url { get; set; }
    }

    public class EbayIntegration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String EbayApiKey { get; set; }

        public String Url { get; set; }
    }

    public class TcgPlayerIntegration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String TcgPlayerApiKey { get; set; }

        public String Url { get; set; }
    }

    public class FacebookIntegration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String FacebookApiKey { get; set; }

        public String Url { get; set; }
    }

    public class TwitterIntegration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String TwitterApiKey { get; set; }

        public String Url { get; set; }
    }

    public class InstagramIntegration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String InstagramApiKey { get; set; }

        public String Url { get; set; }
    }
}