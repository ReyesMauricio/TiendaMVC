namespace MarketingR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nombres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id_empleado = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 30),
                        Apellidos = c.String(nullable: false, maxLength: 30),
                        Porcentaje_bonificado = c.Single(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Hora_inicio = c.DateTime(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(nullable: false),
                        Id_tipoDocumento = c.Int(nullable: false),
                        Numero_documento = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id_empleado)
                .ForeignKey("dbo.Tipo_documento", t => t.Id_tipoDocumento, cascadeDelete: true)
                .Index(t => t.Id_tipoDocumento);
            
            CreateTable(
                "dbo.Tipo_documento",
                c => new
                    {
                        Id_tipoDocumento = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id_tipoDocumento);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id_producto = c.Int(nullable: false, identity: true),
                        Nombre_producto = c.String(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        Ultima_compra = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                        Existencias = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id_producto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "Id_tipoDocumento", "dbo.Tipo_documento");
            DropIndex("dbo.Empleadoes", new[] { "Id_tipoDocumento" });
            DropTable("dbo.Productoes");
            DropTable("dbo.Tipo_documento");
            DropTable("dbo.Empleadoes");
        }
    }
}
