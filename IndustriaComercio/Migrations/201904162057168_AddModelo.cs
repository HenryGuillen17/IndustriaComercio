namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstablecimientoActividades",
                c => new
                    {
                        EstablecimientoId = c.Int(nullable: false),
                        ActividadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EstablecimientoId, t.ActividadId })
                .ForeignKey("dbo.ActividadesGravadas", t => t.ActividadId)
                .ForeignKey("dbo.Establecimientos", t => t.EstablecimientoId)
                .Index(t => t.EstablecimientoId)
                .Index(t => t.ActividadId);
            
            CreateTable(
                "dbo.Establecimientos",
                c => new
                    {
                        EstablecimientoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.EstablecimientoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstablecimientoActividades", "EstablecimientoId", "dbo.Establecimientos");
            DropForeignKey("dbo.Establecimientos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.EstablecimientoActividades", "ActividadId", "dbo.ActividadesGravadas");
            DropIndex("dbo.Establecimientos", new[] { "ClienteId" });
            DropIndex("dbo.EstablecimientoActividades", new[] { "ActividadId" });
            DropIndex("dbo.EstablecimientoActividades", new[] { "EstablecimientoId" });
            DropTable("dbo.Establecimientos");
            DropTable("dbo.EstablecimientoActividades");
        }
    }
}
