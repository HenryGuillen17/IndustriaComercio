namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTelefonoInPersonas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "Telefono", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "Telefono");
        }
    }
}
