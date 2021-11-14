using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenFinal.Models
{
    [Table("Producto")]
    public class ProductoModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se requiere el nombre")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [MinLength(3)]
        [Index("INDEX_NOMBRE_PRODUCTO", IsUnique = true)]
        public string NombreProducto { get; set; }


        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Se requiere una Descripcion")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [MinLength(5)]
        public string Descripcion { get; set; }

        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Se requiere Codigo Proveedor")]
        [ForeignKey("FK_Producto_Proveedor")]
        public int IdProveedor { get; set; }
        public ProveedorModel FK_Producto_Proveedor { get; set; }

        [Display(Name = "Fecha Venc.")]
        [Required(ErrorMessage = "Se requiere Fecha de Vencimiento")]
        [Column(TypeName = "Date")]
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Pasillo")]
        [Required(ErrorMessage = "Se requiere UbicacionFisica")]
        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        [MinLength(5)]
        public string UbicacionFisica { get; set; }

        [Display(Name = "Stock")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Se requiere una cantidad minima")]
        public string ExistenciaMinima { get; set; }

        [Display(Name = "Precio Unitario")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Se requiere un precio")]
        public string PrecioUnidad { get; set; }

    }
}