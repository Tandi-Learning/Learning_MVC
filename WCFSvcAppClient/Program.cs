using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFSvcAppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductSvc.ProductServiceClient proxy = new ProductSvc.ProductServiceClient();
            ProductSvc.Product product = proxy.GetProduct(3);
            Console.WriteLine(product.CategoryName + " - " + product.Price);

            Console.WriteLine("---------------------------------");

            List<ProductSvc.Product> products = proxy.GetProductList().ToList();
            foreach(var p in products)
                Console.WriteLine(p.CategoryName + " - " + p.Price);

            Console.ReadKey();
        }
    }
}
