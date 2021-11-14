using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenFinal.Models
{
    [Table("Empleado")]
    public class EmpleadoModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se requiere el nombre")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_NOMBRE_EMPLEADO", IsUnique = true, Order = 1)]
        public string NombreEmpleado { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Se requiere el Apellido")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_APELLIO_EMPLEADO", IsUnique = true, Order = 2)]
        public string ApellidoEmpleado { get; set; }

        [Display(Name = "DPI")]
        [Required(ErrorMessage = "Se requiere el DPI")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        [MinLength(13)]
        [Index("INDEX_DPI_EMPLEADO", IsUnique = true, Order = 3)]
        [Index("INDEX_DPI", IsUnique = true)]
        public string DpiEmpleado { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Se requiere el número")]
        [Column(TypeName = "Varchar")]
        [StringLength(9)]
        [MinLength(8)]
        public string NumeroEmpleado { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Se requiere la Dirección")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(5)]
        public string DirEmpleado { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Se requiere el Cargo")]
        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        [MinLength(3)]
        public string CargoEmpleado { get; set; }

        [Display(Name = "Email")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CorreoEmpleado { get; set; }

        [Display(Name = "Contraseña")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [MinLength(10)]
        public string PassEmpleado { get; set; }

    }
}