using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using CollectedCompany.ServiceLayer.Integrations.Amazon.Bindings;
using Nager.AmazonProductAdvertising;
using Nager.AmazonProductAdvertising.Model;

namespace CollectedCompany.ServiceLayer.Integrations.Amazon.Impl
{
    public class AmazonProductAdvertisingService : IAmazonProductAdvertisingService
    {

        private readonly AmazonWrapper _requestWrapper;

        public AmazonProductAdvertisingService()
        {
            _requestWrapper = new AmazonWrapper(new AmazonAuthentication
            {
                AccessKey = ConfigurationManager.AppSettings["AmazonProductApiAccessKeyId"],
                SecretKey = ConfigurationManager.AppSettings["AmazonProductApiSecretKeyId"]
            }, AmazonEndpoint.US);
        }

        public AmazonItemResponse Search(String searchTerms, AmazonSearchIndex indexToSearch, AmazonResponseGroup responseGroup = AmazonResponseGroup.Large)
        {
            return _requestWrapper.Search(searchTerms, indexToSearch, responseGroup);
        }

        public void DoStuff()
        {


        }

    }
}