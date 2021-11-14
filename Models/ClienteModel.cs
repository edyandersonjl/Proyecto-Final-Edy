using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenFinal.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        public ClienteModel()
        {
            this.Cli = new HashSet<ClienteModel>();
        }


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="Se requiere el nombre")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_NOMBRE_CLIENTE", IsUnique = true, Order = 1)]
        public string NombreCliente { get; set; }


        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Se requiere el Apellido")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_APELLIO_CLIENTE", IsUnique = true, Order = 2)]
        public string ApellidoCliente { get; set; }


        [Display(Name = "NIT")]
        [Required(ErrorMessage = "Se requiere el NIT")]
        [Column(TypeName = "Varchar")]
        [StringLength(9)]
        [MinLength(8)]
        [Index("INDEX_NOMBRE_CLIENTE", IsUnique = true, Order = 3)]
        [Index("INDEX_NIT", IsUnique = true)]
        public string NitCliente{ get; set; }


        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Se requiere el número")]
        [Column(TypeName = "Varchar")]
        [StringLength(9)]
        [MinLength(8)]
        public string NumeroCliente { get; set; }


        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Se requiere la Dirección")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(5)]
        public string DirCliente { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Se requiere el Correo Electronico")]
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        [MinLength(8)]
        public string EmailCliente { get; set; }

        public virtual ICollection<ClienteModel> Cli{ get; set; }

    }
}