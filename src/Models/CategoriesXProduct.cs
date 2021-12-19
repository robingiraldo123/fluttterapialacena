using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dotnet_api.Models {
    public class CategoriesXProduct {

        [Key]
        public int idCategoriesXProduct { get; set;}

        public List<Categories> Categories_idCategory { get; set; } = new();

        public List<Products> Products_idProducts { get; set; } = new();
    }
}