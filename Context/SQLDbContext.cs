using ExamenFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamenFinal.Context
{
    public class SQLDbContext : DbContext
    {
        internal IEnumerable<object> registrar;

        public SQLDbContext() : base("ExamenFinal") { 
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ProveedorModel> Proveedor { get; set; }
        public DbSet<AdministradorModel> Admin { get; set; }
        public DbSet<EmpleadoModel> Empleado { get; set; }        
        public DbSet<ProductoModel> Producto{ get; set; }
        public DbSet<VentaModel> Venta { get; set; }

    }
}