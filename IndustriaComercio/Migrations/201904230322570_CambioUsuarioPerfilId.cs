namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioUsuarioPerfilId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Usuarios", new[] { "PerfilId" });
            AlterColumn("dbo.Usuarios", "Login", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Usuarios", "Contrasenia", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Usuarios", "PerfilId", c => c.Byte());
            CreateIndex("dbo.Usuarios", "PerfilId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", new[] { "PerfilId" });
            AlterColumn("dbo.Usuarios", "PerfilId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Usuarios", "Contrasenia", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Usuarios", "Login", c => c.String());
            CreateIndex("dbo.Usuarios", "PerfilId");
        }
    }
}
