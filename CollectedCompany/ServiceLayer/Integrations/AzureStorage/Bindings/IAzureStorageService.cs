using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CollectedCompany.ServiceLayer.Integrations.AzureStorage.Bindings
{
    public interface IAzureStorageService
    {
        String SaveImage(FileStream image, String fileName, String containerReference);
    }
}