namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ActividadesGravadas", new[] { "TipoActividadId" });
            AlterColumn("dbo.ActividadesGravadas", "TipoActividadId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActividadesGravadas", "TipoActividadId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ActividadesGravadas", new[] { "TipoActividadId" });
            AlterColumn("dbo.ActividadesGravadas", "TipoActividadId", c => c.Int());
            CreateIndex("dbo.ActividadesGravadas", "TipoActividadId");
        }
    }
}
