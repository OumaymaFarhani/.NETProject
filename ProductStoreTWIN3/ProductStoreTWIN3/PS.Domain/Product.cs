using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Domain
{

    //sealed pour bloquer l heritage
    public class Product
    {
        public int ProductId { get; set; }
        [Required (ErrorMessage ="name is required")]
        [MaxLength(25,ErrorMessage ="name length should be less than 25")] //input length
        [StringLength(50)] //proprety length
        public String Name { get; set; }

        [Display(Name ="Date de Production")] //reformler le nom de l'attribut dans l'affichage
        [DataType(DataType.Date)]
        public DateTime DateProd { get; set; }

        [Range(0,int.MaxValue)] //l'intervalle de l'attribut
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [DataType(DataType.MultilineText)] //MBLOQUé MULTILIGNE
        public string Description  { get; set; }
        // public int CategoryId { get; set; }

     //   [ForeignKey("Category")] 2eme methode pour relier Category et CategoryFk
        public int? CategoryFk { get; set; }
        [ForeignKey("CategoryFk")]
        public Category Category { get; set; }
        public int ImageName { get; set; }
        public List<Provider> Providers { get; set; }

        public override string ToString()
        {
            return "Name: "+Name+" DateProd: "+DateProd+" Quantity: "+Quantity+" Price: "+Price+" Category :"+Category+" Providers :"+Providers;
        }

        public virtual void GetMyType()
        {
            Console.Write("Je suis un produit");
        }



    }
}
