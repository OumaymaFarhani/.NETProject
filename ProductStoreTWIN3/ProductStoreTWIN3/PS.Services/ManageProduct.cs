using System;
using System.Collections.Generic;
using System.Text;
using PS.Domain;
using System.Linq;

namespace PS.Services
{
    public class ManageProduct
    {
        //Delegué : affecter des methodes temporelle
            //  Func : parametre : char , retour: list<product>
        public Func<char ,List<Product>> FindProduct;
            // Action: 
        public Action<Category> ScanProduct;
        public List<Product> lsProduct { get; set; }
        public List<Product> Methode1(char c)
        {
            List<Product> ls = new List<Product>();
            foreach (Product p in lsProduct)
            {
                if (p.Name.StartsWith(c))
                {
                    ls.Add(p);
                }
                
            }
            return ls;

        }

        //equivalent de meth1:
        public ManageProduct()
        {
           // FindProduct = Methode1;
            FindProduct = c =>
            {
                List<Product> ls = new List<Product>();
                foreach (Product p in lsProduct)
                {
                    if (p.Name.StartsWith(c))
                    {
                        ls.Add(p);
                    }

                }
                return ls;
            };
            ScanProduct = cat =>
              {
                  foreach (Product p in lsProduct)
                  {
                      if (p.Category.CategoryId == cat.CategoryId) {
                          Console.WriteLine(p);
                      }
                }
              };

        }
        public IEnumerable<Chemical> Get3Chemichal(double price)
        {
            var req = from p in lsProduct.OfType<Chemical>()
                      where p.Price > price
                      select p;
            return req.Take(3);

        }
        ///ignorer les 2 premier produits
        /////GetProductPrice(double price) : return req.Skip(2);
        public double GetAveragePrice() {
            return lsProduct.Average(p => p.Price);

        }
        public double GetMaxPrice()
        {
            return lsProduct.Max(p => p.Price);

        }
        public int GetCountProduct()
        {
            return lsProduct.OfType<Chemical>().Count();
        }
        public IEnumerable<Chemical> GetChemicalCity()
        {
            var req = from c in lsProduct.OfType<Chemical>()
                      orderby c.Adress.City descending
                      select c;
            var req2 = lsProduct.OfType<Chemical>().OrderBy(ch => ch.Adress.City);
            return req2;
        }
        public IEnumerable<IGrouping<String,Chemical>> GetChemicalGroupByCity()
        {
            var req = from c in lsProduct.OfType<Chemical>()
                       orderby c.Adress.City descending
                       group c by c.Adress.City;
            var req2 = lsProduct.OfType<Chemical>().OrderBy(ch => ch.Adress.City).GroupBy(ch => ch.Adress.City);
                      
            return req2;
        }


    }
}
