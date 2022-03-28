using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
   public class Biological : Product
    {
        public String Herbs { get; set; }
        public override void GetMyType()
        {
            base.GetMyType();
            Console.WriteLine("Je suis un Biological");
        }
    }
    

}
