namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personas", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente");
            DropIndex("dbo.Personas", new[] { "ClasificacionContribuyenteId" });
            AddColumn("dbo.Clientes", "ClasificacionContribuyenteId", c => c.Int());
            CreateIndex("dbo.Clientes", "ClasificacionContribuyenteId");
            AddForeignKey("dbo.Clientes", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente", "ClasificacionContribuyenteId");
            DropColumn("dbo.Clientes", "TipoClienteId");
            DropColumn("dbo.Personas", "ClasificacionContribuyenteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personas", "ClasificacionContribuyenteId", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "TipoClienteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Clientes", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente");
            DropIndex("dbo.Clientes", new[] { "ClasificacionContribuyenteId" });
            DropColumn("dbo.Clientes", "ClasificacionContribuyenteId");
            CreateIndex("dbo.Personas", "ClasificacionContribuyenteId");
            AddForeignKey("dbo.Personas", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente", "ClasificacionContribuyenteId");
        }
    }
}
