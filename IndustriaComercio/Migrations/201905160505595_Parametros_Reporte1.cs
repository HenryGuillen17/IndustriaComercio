namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Parametros_Reporte1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ReportePagoDeclaracionDetalles", newName: "ReportesPagosDeclaracionesDetalles");
            RenameTable(name: "dbo.ReportePagoDeclaracions", newName: "ReportesPagosDeclaraciones");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ReportesPagosDeclaraciones", newName: "ReportePagoDeclaracions");
            RenameTable(name: "dbo.ReportesPagosDeclaracionesDetalles", newName: "ReportePagoDeclaracionDetalles");
        }
    }
}
