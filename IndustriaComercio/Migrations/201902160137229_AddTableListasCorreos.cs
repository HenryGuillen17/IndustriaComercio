namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableListasCorreos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListaCorreos",
                c => new
                    {
                        ListaCorreoId = c.Int(nullable: false, identity: true),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.ListaCorreoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ListaCorreos");
        }
    }
}
