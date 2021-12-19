using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dotnet_api.Models {
    public class UserXCupBoard {

        [Key][Column(TypeName = "nvarchar(45)")]
        public int idUserXCupBoard { get; set; }

        public List<Users> Users_idUsers { get; set; }

        public List<CupBoards> CupBoards_idCupBoarda { get; set; }

        [Column(TypeName = "nvarchar(45)")]
        public int idUser { get; set; }

        [Column(TypeName = "nvarchar(45)")]
        public int idCupBoard { get; set; }

    }
}