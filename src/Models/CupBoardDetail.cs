using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dotnet_api.Models {
    public class CupBoarddetail {

        [Key][Column(TypeName = "nvarchar(45)")]
        public int idCupBoardDetail { get; set; }

        [Column(TypeName = "nvarchar(45)")]
        
        public List<CupBoards> CupBoars_idCupBoards { get; set; }

        [Column(TypeName = "nvarchar(45)")]
        public List<Products> Products_idProducts { get; set; }

        [Column(TypeName = "nvarchar(45)")]
        public int idProduct { get; set; }

        [Column(TypeName = "nvarchar(45)")]
        public int idCupBoard { get; set; }

        public int amount { get; set; }

        public DateTime entryDate { get; set; }

        public DateTime exitDate { get; set; }

        public DateTime expirationDate { get; set; }

    }
}