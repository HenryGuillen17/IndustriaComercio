namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActividadesGravadas", "TipoActividadId", c => c.Int());
            AddColumn("dbo.Clientes", "RetieneImpIndustriaComercio", c => c.Boolean(nullable: false));
            CreateIndex("dbo.ActividadesGravadas", "TipoActividadId");
            AddForeignKey("dbo.ActividadesGravadas", "TipoActividadId", "dbo.TipoActividad", "TipoActividadId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActividadesGravadas", "TipoActividadId", "dbo.TipoActividad");
            DropIndex("dbo.ActividadesGravadas", new[] { "TipoActividadId" });
            DropColumn("dbo.Clientes", "RetieneImpIndustriaComercio");
            DropColumn("dbo.ActividadesGravadas", "TipoActividadId");
        }
    }
}
