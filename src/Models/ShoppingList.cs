using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dotnet_api.Models {
    public class ShoppingList {

        [Key][Column(TypeName = "nvarchar(45)")]
        public int idShoppingList { get; set;}

        public List<Products> Products_idProducts { get; set; }

        public string idProduct { get; set; }

        public int amount { get; set; }

        public float value { get; set; }

        public DateTime expirationDate { get; set; }
    }
}