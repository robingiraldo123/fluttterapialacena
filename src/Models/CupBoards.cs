using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_api.Models {
    public class CupBoards {

        [Key][Column(TypeName = "nvarchar(45)")]
        public int idCupBoards { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string nameCupBoard { get; set; }

        public bool isDefault { get; set; }

        public DateTime creationDate { get; set; }

    }
}