using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectedCompany.Models
{
    public class ProductViewModel
    {
        public List<HttpPostedFileBase> Files { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public decimal Price { get; set; }

        public decimal CompareAtPrice { get; set; }

        public String StockKeepingUnit { get; set; }

        public String Barcode { get; set; }

        public Boolean AllowPurchaseWhenOutOfStock { get; set; }

        public Boolean RequiresShipping { get; set; }
    }
}