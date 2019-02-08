namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyActividadesGravables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActividadesGravadas", "Tarifa", c => c.Double(nullable: false));
            DropColumn("dbo.ActividadesGravablesPorDeclaracion", "Tarifa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActividadesGravablesPorDeclaracion", "Tarifa", c => c.Double(nullable: false));
            DropColumn("dbo.ActividadesGravadas", "Tarifa");
        }
    }
}
