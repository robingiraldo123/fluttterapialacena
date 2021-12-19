using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dotnet_api.Models {
    public class UserXShoppingList {

        [Key][Column(TypeName = "nvarchar(45)")]
        public int idUserXShoppingList { get; set;}

        [Column(TypeName = "nvarchar(45)")]
        public List<Users> Users_idUsers { get; set; }

        public List<Products> ShoppList_Products_idProducts { get; set; }

        //check index
        public List<ShoppingList> ShoppingList_idShoppingList { get; set; }

        [Column(TypeName = "nvarchar(45)")]
        public int idUser { get; set; }

        [Column(TypeName = "nvarchar(45)")]
        public int idShoppingList { get; set; }

    }
}