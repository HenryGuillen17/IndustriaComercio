namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPersonasClientesV01 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.DeclaracionesPrevias", "ClasificacionContribuyente_ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente");
            //DropIndex("dbo.DeclaracionesPrevias", new[] { "ClasificacionContribuyente_ClasificacionContribuyenteId" });
            AlterColumn("dbo.Personas", "NoIdentificacion", c => c.String());
            AlterColumn("dbo.Personas", "PrimerNombre", c => c.String());
            AlterColumn("dbo.Personas", "PrimerApellido", c => c.String());
            CreateIndex("dbo.Personas", "ClasificacionContribuyenteId");
            AddForeignKey("dbo.Personas", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente", "ClasificacionContribuyenteId");
            //DropColumn("dbo.DeclaracionesPrevias", "ClasificacionContribuyente_ClasificacionContribuyenteId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.DeclaracionesPrevias", "ClasificacionContribuyente_ClasificacionContribuyenteId", c => c.Int());
            //DropForeignKey("dbo.Personas", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente");
            //DropIndex("dbo.Personas", new[] { "ClasificacionContribuyenteId" });
            AlterColumn("dbo.Personas", "PrimerApellido", c => c.String(nullable: false));
            AlterColumn("dbo.Personas", "PrimerNombre", c => c.String(nullable: false));
            AlterColumn("dbo.Personas", "NoIdentificacion", c => c.String(nullable: false));
            //CreateIndex("dbo.DeclaracionesPrevias", "ClasificacionContribuyente_ClasificacionContribuyenteId");
            //AddForeignKey("dbo.DeclaracionesPrevias", "ClasificacionContribuyente_ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente", "ClasificacionContribuyenteId");
        }
    }
}
