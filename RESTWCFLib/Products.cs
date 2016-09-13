using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RESTWCFLib
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int Price { get; set; }
    }

    public partial class Products
    {
        private static readonly Products _instance = new Products();

        private Products() { }

        public static Products instance
        {
            get { return _instance; }
        }

        public List<Product> ProductList
        {
            get { return _products; }
        }

        private List<Product> _products = new List<Product>()
        {
            new Product() { ProductId = 1, Name = "Product 1", CategoryName = "Category 1", Price = 10 },
            new Product() { ProductId = 2, Name = "Product 2", CategoryName = "Category 2", Price = 20 },
            new Product() { ProductId = 3, Name = "Product 3", CategoryName = "Category 3", Price = 30 },
            new Product() { ProductId = 4, Name = "Product 4", CategoryName = "Category 4", Price = 40 }
        };
    }
}
