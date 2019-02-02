namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClasificacionContribuyente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClasificacionesContribuyente",
                c => new
                    {
                        ClasificacionContribuyenteId = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ClasificacionContribuyenteId);
            
            AddColumn("dbo.DeclaracionesPrevias", "ClasificacionContribuyenteId", c => c.Int(nullable: false));
            CreateIndex("dbo.DeclaracionesPrevias", "ClasificacionContribuyenteId");
            AddForeignKey("dbo.DeclaracionesPrevias", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente", "ClasificacionContribuyenteId");
            DropColumn("dbo.DeclaracionesPrevias", "ClasificacionContribuyente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeclaracionesPrevias", "ClasificacionContribuyente", c => c.String());
            DropForeignKey("dbo.DeclaracionesPrevias", "ClasificacionContribuyenteId", "dbo.ClasificacionesContribuyente");
            DropIndex("dbo.DeclaracionesPrevias", new[] { "ClasificacionContribuyenteId" });
            DropColumn("dbo.DeclaracionesPrevias", "ClasificacionContribuyenteId");
            DropTable("dbo.ClasificacionesContribuyente");
        }
    }
}
