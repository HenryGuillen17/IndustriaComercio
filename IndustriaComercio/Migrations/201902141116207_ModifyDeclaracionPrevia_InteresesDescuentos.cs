namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDeclaracionPrevia_InteresesDescuentos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeclaracionesPrevias", "Descuento", c => c.Double(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "Interes", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeclaracionesPrevias", "Interes");
            DropColumn("dbo.DeclaracionesPrevias", "Descuento");
        }
    }
}
