using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
   public class Chemical : Product
    {
        public Adress Adress { get; set; } = new Adress();
        public String LabName { get; set; }
     
        public override void GetMyType()
        {
            //Console.WriteLine("Je suis un produit");
            base.GetMyType();
            Console.WriteLine(" Chemical");
        }
        public override string ToString()
        {
            return base.ToString()+"City :"+Adress.City;
        }
    }
    
   

}
