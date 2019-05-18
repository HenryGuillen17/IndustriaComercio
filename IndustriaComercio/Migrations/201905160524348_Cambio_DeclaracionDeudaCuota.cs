namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambio_DeclaracionDeudaCuota : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DeclaracionDeudasCuotas", "DocumentoRetencion");
            DropColumn("dbo.DeclaracionDeudasCuotas", "TipoSancionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeclaracionDeudasCuotas", "TipoSancionId", c => c.Int());
            AddColumn("dbo.DeclaracionDeudasCuotas", "DocumentoRetencion", c => c.String());
        }
    }
}
