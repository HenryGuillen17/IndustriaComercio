namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clientes", new[] { "ClasificacionContribuyenteId" });
            AlterColumn("dbo.Clientes", "ClasificacionContribuyenteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "ClasificacionContribuyenteId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", new[] { "ClasificacionContribuyenteId" });
            AlterColumn("dbo.Clientes", "ClasificacionContribuyenteId", c => c.Int());
            CreateIndex("dbo.Clientes", "ClasificacionContribuyenteId");
        }
    }
}
