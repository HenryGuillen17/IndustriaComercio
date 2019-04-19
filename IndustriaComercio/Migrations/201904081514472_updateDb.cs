namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "NoPlaca", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "NoPlaca");
        }
    }
}
