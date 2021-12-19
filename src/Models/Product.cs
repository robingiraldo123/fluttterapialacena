using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Models {
    public class Products {

        [Key]
        public int idProducts { get; set;}

        [Column(TypeName = "nvarchar(100)")]
        public string nameProduct { get; set; }

        public DateTime expirationDate { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public int barCode { get; set; }


        public CategoriesXProduct CategoriesXProduct { get; set; }
        public int CategoriesXProductId { get; set; }

        public Trademarks Trademarks { get; set; }
        public int TrademarksId { get; set; }

    }
}