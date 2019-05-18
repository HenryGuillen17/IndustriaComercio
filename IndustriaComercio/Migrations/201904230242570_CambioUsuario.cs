namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Contrasenia", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Usuarios", "Contraseña");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Contraseña", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Usuarios", "Contrasenia");
        }
    }
}
