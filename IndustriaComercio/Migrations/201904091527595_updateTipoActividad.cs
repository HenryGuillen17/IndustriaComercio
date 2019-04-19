namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTipoActividad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoActividad",
                c => new
                    {
                        TipoActividadId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoActividadId);
            
            DropTable("dbo.TipoContribuyente");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TipoContribuyente",
                c => new
                    {
                        TipoContribuyenteId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TipoContribuyenteId);
            
            DropTable("dbo.TipoActividad");
        }
    }
}
