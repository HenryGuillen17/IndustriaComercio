namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateActividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActividadesGravadas", "Valor", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActividadesGravadas", "Valor");
        }
    }
}
