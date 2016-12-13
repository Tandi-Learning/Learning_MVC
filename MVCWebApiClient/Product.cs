using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApiClient
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int Price { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string ISO2Code { get; set; }
        public string CapitalCity { get; set; }
    }

}