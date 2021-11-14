using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenFinal.Models
{
    [Table("Ventas")]
    public class VentaModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoVenta { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Se requiere la descripción")]
        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        [MinLength(5)]
        public string Descripcion { get; set; }

        [Display(Name = "Codigo del Cliente")]
        [Required(ErrorMessage = "Se requiere el Codigo del Cliente")]
        [ForeignKey("FK_Cliente_Venta")]
        public int IdCliente { get; set; }
        public ClienteModel FK_Cliente_Venta { get; set; }

        [Display(Name = "Codigo Producto")]
        [Required(ErrorMessage = "Se requiere el Codigo del Producto")]
        [ForeignKey("FK_Producto_Venta")]
        public int IdProducto { get; set; }
        public ProductoModel FK_Producto_Venta { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Se requiere la Cantidad de Articulos")]
        public int Cantidad { get; set; }

        [Display(Name = "Fecha de Venta")]
        [Required(ErrorMessage = "Ingrese la Fecha que se realizo la venta")]
        [Column(TypeName = "Date")]
        public DateTime FechaVenta { get; set; }

    }
}