using System;
using System.Collections.Generic;
using PS.Domain;
using PS.Services;
using PS.Data;

namespace PS.GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Product p = new Product();
            p.Name="farid";
            p.DateProd=DateTime.Now;
            Console.WriteLine(p.Name);
            Console.WriteLine(p.DateProd);
            Product p22 = new Product()
            { Name = "salah", Description = "aaaaa" };
            Console.WriteLine(p22.Name);
            Console.WriteLine(p);
            Provider pr = new Provider();
            pr.PassWord = "aaaaaaaa";
            pr.ConfirmPassword = "aaaaaaaa";
            Console.WriteLine(pr.PassWord);
            Console.WriteLine(pr.ConfirmPassword);
            Provider.SetIsApproved(pr);
            Console.WriteLine("ref"+pr.IsApproved);
            Provider.SetIsApproved2(pr.PassWord, pr.ConfirmPassword, pr.IsApproved);
            Console.WriteLine("notRef"+pr.IsApproved);

            int j = 5;
            int k = 3;
            int i = 1;
            Provider.calculer(j, k, ref i);
            Console.WriteLine(i);



            //tester Polymorphisme

            Provider pp = new Provider();

            pp.UserName = "Sofiene";
            pp.Email = "Sofiene@gmail.com";
            pp.PassWord = "testtest";
            Console.WriteLine(pp.Login("Sofiene","testtest11"));
            Console.WriteLine(pp.Login("Hyba","testtest", "Sofiene@gmail.com"));


            Product pro = new Product();
            Chemical c1 = new Chemical()
            {
                Name="Chemical1",
                Price=500,
         
    
            };
            
            Chemical c4 = new Chemical()
            {
                Name = "Chemical4",
                Price = 50,

            };
            c4.Adress.City = "Paris";
            Chemical c2 = new Chemical()
            {
                Name = "Chemical2",
                Price = 300,
               

            };
            Chemical c3 = new Chemical()
            {
                Name = "Chemical3",
                Price = 700,

            };
            Chemical c5 = new Chemical()
            {
                Name = "Chemical5",
                Price = 70,
              

            };
            Product b = new Biological();
            pro.GetMyType();
            c1.GetMyType();
            b.GetMyType();
            Product p1 = new Product()
            {
                Name = "fraise",
                Quantity = 5,
                Price=200
            };
            p1.DateProd = new DateTime(2022, 1, 31);
            Product p2 = new Product()
            {
                Name = "banane",
                Quantity = 2
            };
            p2.DateProd = new DateTime(2020, 10, 20);

            Product p3 = new Product()
            {
                Name = "batata",
                Quantity = 54,
                Price=23.21
            };
            p3.DateProd = new DateTime(2021, 2, 5);
            //Collection
            Provider provider = new Provider();
            List<Product> products = new List<Product>()
            {
                c4
            };
            provider.UserName="Oumayma";
           // products.Add(p1);
          //  products.Add(p2);
         //   products.Add(p3);
            provider.Products = products;
            Console.WriteLine("\n");
            provider.GetDetails();
            Console.WriteLine("\n");
            Console.WriteLine("la methode getProducts");

            provider.GetProducts("Price", "200");

            provider.GetProducts("dateProd", "2020/10/20");
           
         

            Console.WriteLine("---------------------déléguer-----------------------------");

            ManageProduct mp = new ManageProduct();
            mp.lsProduct = products;

            foreach (Product ap in mp.FindProduct('b'))
            {
                Console.WriteLine(ap);
            }
            Console.WriteLine("-------------------Tester les methodes de la class ManageProducts------------------");

            foreach(Chemical c in mp.Get3Chemichal(300))
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("Averge : "+mp.GetAveragePrice()+" Count :"+ mp.GetCountProduct()+" Max Price : "+mp.GetMaxPrice());

            Console.WriteLine("-----------Get Chemical by city : ---------------------------");
            foreach (Chemical c in mp.GetChemicalCity())
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("-----------Get Chemical group by city : ---------------------------");
            foreach (var g in mp.GetChemicalGroupByCity())
            {
                Console.WriteLine(g.Key);
                foreach (Chemical ch in g)
                {
                    Console.WriteLine(ch);
                }

            }
            Console.WriteLine("--------------------------- Methode d'extension -----------------------");
            String s = "bonjour";
           
            Console.WriteLine(s.Upper());

            Console.WriteLine("--------------------------- Insertion dans la base de donnees -----------------------");
            PSContext ctx = new PSContext();
            ctx.Products.Add(p);
            ctx.Chemicals.Add(c1);
            ctx.SaveChanges();
        }
    }
}
