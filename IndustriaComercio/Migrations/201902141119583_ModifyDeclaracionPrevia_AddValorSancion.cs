namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDeclaracionPrevia_AddValorSancion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeclaracionesPrevias", "ValorSancion", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeclaracionesPrevias", "ValorSancion");
        }
    }
}
