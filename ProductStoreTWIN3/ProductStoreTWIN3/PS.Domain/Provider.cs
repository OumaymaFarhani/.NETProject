using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
   public class Provider:Concept
    {
        // public String ConfirmPassword { get; set; }
        private String confirmPassword;
        [DataType(DataType.Password)]
        [Required]
        [NotMapped]
        [Compare("Password",ErrorMessage ="Confirmation must match the password")]
        public String ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (value.Equals(PassWord))
                    confirmPassword = value;
                
                else Console.WriteLine("errorConfirm");
            }
        }
        public DateTime DateCreated { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }
        [Key]
        public int ProviderCode { get; set; }
        public bool IsApproved { get; set; }
        //public String Password { get; set; }
        private String passWord;
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="password must be not null")]
        [MinLength(10)]
        public String PassWord
        {
            get { return passWord; }
            set {
                if (value.Length > 20 || value.Length < 5)
                    Console.WriteLine("error");
                else passWord = value;
            } 
        }
        public String UserName { get; set; }
        public List<Product> Products { get; set; }

        public static void SetIsApproved(Provider p)
        {
            p.IsApproved = p.PassWord.Equals(p.ConfirmPassword); 
        }
        public static void SetIsApproved2(String pass, String confPass, bool isApproved)
        {
            isApproved = pass.Equals(confPass);
        }
        public static void calculer(int a,int b,ref int c)
        {
            c = a + b;
        }
       /** public bool Login(String username,String password)
        {
            return UserName.Equals(username) && passWord.Equals(password);
        }
        public bool Login(String username, String password,String email)
        {
            return UserName.Equals(username) && PassWord.Equals(password)&& Email.Equals(email);
        }
       */

        public bool Login(String username, String password, String email=null)
        {
            if(email==null)
                return UserName.Equals(username) && passWord.Equals(password);
            else
                 return UserName.Equals(username) && PassWord.Equals(password) && Email.Equals(email);
        }
        //Parcourir liste de produit
        public override void GetDetails()
        {
            Console.WriteLine("Nom : " +UserName);
          /*  for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine(Products[i]);
            }*/
            foreach(Product p in Products)
            {
                Console.WriteLine(p);
            }
        }
        public void GetProducts(string filterType,string filterValue)
        {
            switch (filterType)
            {
                case "Name":
                    foreach(Product p in Products)
                    {
                        if (p.Name == filterValue)
                        {
                            Console.WriteLine(p);
                        }
                    }
                    break;
                case "DateProd":
                    foreach (Product p in Products)
                    {
                        if (p.DateProd== DateTime.Parse (filterValue))
                        {
                            Console.WriteLine(p);
                        }
                    }
                    break;
                case "Price":
                    foreach (Product p in Products)
                    {
                        if (p.Price == double.Parse(filterValue))
                        {
                            Console.WriteLine(p);
                        }
                    }
                    break;

            }
        }
    }
}
