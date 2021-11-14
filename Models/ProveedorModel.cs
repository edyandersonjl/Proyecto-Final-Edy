using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenFinal.Models
{
    [Table("Proveedor")]
    public class ProveedorModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProveedor { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se requiere el nombre")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_NOMBRE_PROVEEDOR", IsUnique = true, Order = 1)]
        public string NombreProveedor { get; set; }


        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Se requiere el Apellido")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_APELLIO_PROVEEDOR", IsUnique = true, Order = 2)]
        public string ApellidoProveedor { get; set; }


        [Display(Name = "NIT")]
        [Required(ErrorMessage = "Se requiere el NIT")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        [MinLength(13)]
        [Index("INDEX_NIT_PROVEEDOR", IsUnique = true, Order = 3)]
        [Index("INDEX_NIT", IsUnique = true)]
        public string NitProveedor { get; set; }


        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Se requiere el número")]
        [Column(TypeName = "Varchar")]
        [StringLength(9)]
        [MinLength(8)]
        public string NumeroProveedor { get; set; }


        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Se requiere la Dirección")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(5)]
        public string DirProveedor { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Se requiere el Correo")]
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        [MinLength(3)]
        public string CorreoProveedor { get; set; }

    }
}