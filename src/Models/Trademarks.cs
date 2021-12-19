using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dotnet_api.Models {
    public class Trademarks {

        [Key]
        public int idTrademarks { get; set;}

        [Column(TypeName = "nvarchar(100)")]
        public string mark { get; set; }

        public List<Products> Products_idProducts { get; set; } 
    }
}