using System;
using Nager.AmazonProductAdvertising.Model;

namespace CollectedCompany.ServiceLayer.Integrations.Amazon.Bindings
{
    public interface IAmazonProductAdvertisingService
    {
        AmazonItemResponse Search(String searchTerms, AmazonSearchIndex indexToSearch, AmazonResponseGroup responseGroup = AmazonResponseGroup.Large);
    }
}