using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ExamenFinal.Models;

namespace ExamenFinal.Models
{

    [Table("Administrador")]
    public class AdministradorModel
    {
        public AdministradorModel() {
            this.OdersAdmins = new HashSet<VentaModel>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdmin { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se requiere el nombre")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_NOMBRE_CLIENTE", IsUnique = true, Order = 1)]
        public string NombreAdmin { get; set; }


        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Se requiere el Apellido")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_APELLIO_CLIENTE", IsUnique = true, Order = 2)]
        public string ApellidoAdmin { get; set; }


        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Se requiere el número")]
        [Column(TypeName = "Varchar")]
        [StringLength(9)]
        [MinLength(8)]
        public string NumeroAdmin { get; set; }


        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Se requiere el Cargo")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(5)]
        public string CargoAdmin { get; set; }


        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Se requiere el Titulo")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(6)]
        public string TituloAdmin { get; set; }


        [Display(Name = "Email")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CorreoAdmin { get; set; }

        [Display(Name = "Contraseña")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [MinLength(10)]
        public string PassAdmin { get; set; }

        public Nullable<bool> tipopersona { get; set; }
        public virtual ICollection<VentaModel> OdersAdmins { get; set; }
    }
}