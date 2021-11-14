namespace ExamenFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        IdAdmin = c.Int(nullable: false, identity: true),
                        NombreAdmin = c.String(nullable: false, maxLength: 50, unicode: false),
                        ApellidoAdmin = c.String(nullable: false, maxLength: 50, unicode: false),
                        NumeroAdmin = c.String(nullable: false, maxLength: 9, unicode: false),
                        CargoAdmin = c.String(nullable: false, maxLength: 50, unicode: false),
                        TituloAdmin = c.String(nullable: false, maxLength: 50, unicode: false),
                        CorreoAdmin = c.String(maxLength: 100, unicode: false),
                        PassAdmin = c.String(maxLength: 100, unicode: false),
                        tipopersona = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdAdmin)
                .Index(t => t.NombreAdmin, unique: true, name: "INDEX_NOMBRE_CLIENTE")
                .Index(t => t.ApellidoAdmin, unique: true, name: "INDEX_APELLIO_CLIENTE");
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false, maxLength: 50, unicode: false),
                        ApellidoCliente = c.String(nullable: false, maxLength: 50, unicode: false),
                        NitCliente = c.String(nullable: false, maxLength: 9, unicode: false),
                        NumeroCliente = c.String(nullable: false, maxLength: 9, unicode: false),
                        DirCliente = c.String(nullable: false, maxLength: 50, unicode: false),
                        EmailCliente = c.String(nullable: false, maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.IdCliente)
                .Index(t => new { t.NombreCliente, t.NitCliente }, unique: true, name: "INDEX_NOMBRE_CLIENTE")
                .Index(t => t.ApellidoCliente, unique: true, name: "INDEX_APELLIO_CLIENTE")
                .Index(t => t.NitCliente, unique: true, name: "INDEX_NIT");
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        NombreEmpleado = c.String(nullable: false, maxLength: 50, unicode: false),
                        ApellidoEmpleado = c.String(nullable: false, maxLength: 50, unicode: false),
                        DpiEmpleado = c.String(nullable: false, maxLength: 13, unicode: false),
                        NumeroEmpleado = c.String(nullable: false, maxLength: 9, unicode: false),
                        DirEmpleado = c.String(nullable: false, maxLength: 50, unicode: false),
                        CargoEmpleado = c.String(nullable: false, maxLength: 25, unicode: false),
                        CorreoEmpleado = c.String(maxLength: 100, unicode: false),
                        PassEmpleado = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IdEmpleado)
                .Index(t => t.NombreEmpleado, unique: true, name: "INDEX_NOMBRE_EMPLEADO")
                .Index(t => t.ApellidoEmpleado, unique: true, name: "INDEX_APELLIO_EMPLEADO")
                .Index(t => t.DpiEmpleado, unique: true, name: "INDEX_DPI")
                .Index(t => t.DpiEmpleado, unique: true, name: "INDEX_DPI_EMPLEADO");
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        IdProveedor = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false, storeType: "date"),
                        UbicacionFisica = c.String(nullable: false, maxLength: 150, unicode: false),
                        ExistenciaMinima = c.String(nullable: false, maxLength: 8000, unicode: false),
                        PrecioUnidad = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.Proveedor", t => t.IdProveedor, cascadeDelete: true)
                .Index(t => t.NombreProducto, unique: true, name: "INDEX_NOMBRE_PRODUCTO")
                .Index(t => t.IdProveedor);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        NombreProveedor = c.String(nullable: false, maxLength: 50, unicode: false),
                        ApellidoProveedor = c.String(nullable: false, maxLength: 50, unicode: false),
                        NitProveedor = c.String(nullable: false, maxLength: 13, unicode: false),
                        NumeroProveedor = c.String(nullable: false, maxLength: 9, unicode: false),
                        DirProveedor = c.String(nullable: false, maxLength: 50, unicode: false),
                        CorreoProveedor = c.String(nullable: false, maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.IdProveedor)
                .Index(t => t.NombreProveedor, unique: true, name: "INDEX_NOMBRE_PROVEEDOR")
                .Index(t => t.ApellidoProveedor, unique: true, name: "INDEX_APELLIO_PROVEEDOR")
                .Index(t => t.NitProveedor, unique: true, name: "INDEX_NIT")
                .Index(t => t.NitProveedor, unique: true, name: "INDEX_NIT_PROVEEDOR");
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        CodigoVenta = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 200, unicode: false),
                        IdCliente = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        FechaVenta = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.CodigoVenta)
                .ForeignKey("dbo.Cliente", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdCliente)
                .Index(t => t.IdProducto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.Ventas", "IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.Producto", "IdProveedor", "dbo.Proveedor");
            DropIndex("dbo.Ventas", new[] { "IdProducto" });
            DropIndex("dbo.Ventas", new[] { "IdCliente" });
            DropIndex("dbo.Proveedor", "INDEX_NIT_PROVEEDOR");
            DropIndex("dbo.Proveedor", "INDEX_NIT");
            DropIndex("dbo.Proveedor", "INDEX_APELLIO_PROVEEDOR");
            DropIndex("dbo.Proveedor", "INDEX_NOMBRE_PROVEEDOR");
            DropIndex("dbo.Producto", new[] { "IdProveedor" });
            DropIndex("dbo.Producto", "INDEX_NOMBRE_PRODUCTO");
            DropIndex("dbo.Empleado", "INDEX_DPI_EMPLEADO");
            DropIndex("dbo.Empleado", "INDEX_DPI");
            DropIndex("dbo.Empleado", "INDEX_APELLIO_EMPLEADO");
            DropIndex("dbo.Empleado", "INDEX_NOMBRE_EMPLEADO");
            DropIndex("dbo.Cliente", "INDEX_NIT");
            DropIndex("dbo.Cliente", "INDEX_APELLIO_CLIENTE");
            DropIndex("dbo.Cliente", "INDEX_NOMBRE_CLIENTE");
            DropIndex("dbo.Administrador", "INDEX_APELLIO_CLIENTE");
            DropIndex("dbo.Administrador", "INDEX_NOMBRE_CLIENTE");
            DropTable("dbo.Ventas");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Producto");
            DropTable("dbo.Empleado");
            DropTable("dbo.Cliente");
            DropTable("dbo.Administrador");
        }
    }
}
