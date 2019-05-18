namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Parametros_Reporte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeclaracionDeudasCuotas",
                c => new
                    {
                        DeclaracionDeudaCuotaId = c.Int(nullable: false),
                        DeclaracionPreviaId = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        TotalImpuestoIndustriaComercio = c.Double(nullable: false),
                        ImpuestoAvisosTableros = c.Double(nullable: false),
                        PagoUnidadesComerciales = c.Double(nullable: false),
                        SobretasaBomberil = c.Double(nullable: false),
                        SobretasaSeguridad = c.Double(nullable: false),
                        TotalImpuestoCargo = c.Double(nullable: false),
                        ValorExoneracionImpuesto = c.Double(nullable: false),
                        RetencionesDelMunicipio = c.Double(nullable: false),
                        AutoretencionesDelMunicipio = c.Double(nullable: false),
                        DocumentoRetencion = c.String(),
                        AnticipoAnioAnterior = c.Double(nullable: false),
                        AnticipoAnioSiguiente = c.Double(nullable: false),
                        TipoSancionId = c.Int(),
                        ValorSancion = c.Double(nullable: false),
                        SaldoFavorPeriodoAnterior = c.Double(nullable: false),
                        TotalSaldoCargo = c.Double(nullable: false),
                        TotalSaldoFavor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DeclaracionDeudaCuotaId)
                .ForeignKey("dbo.DeclaracionesPrevias", t => t.DeclaracionPreviaId)
                .Index(t => new { t.DeclaracionPreviaId, t.FechaVencimiento }, unique: true);
            
            CreateTable(
                "dbo.ReportePagoDeclaracionDetalles",
                c => new
                    {
                        DeclaracionDeudaCuotaId = c.Int(nullable: false),
                        ReportePagoDeclaracionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeclaracionDeudaCuotaId, t.ReportePagoDeclaracionId })
                .ForeignKey("dbo.DeclaracionDeudasCuotas", t => t.DeclaracionDeudaCuotaId)
                .Index(t => t.DeclaracionDeudaCuotaId);
            
            CreateTable(
                "dbo.ParametrosVencimientos",
                c => new
                    {
                        ParametroVencimientoId = c.Int(nullable: false),
                        Mes = c.Int(nullable: false),
                        Dia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParametroVencimientoId)
                .Index(t => new { t.Mes, t.Dia }, unique: true);
            
            CreateTable(
                "dbo.ReportePagoDeclaracions",
                c => new
                    {
                        ReportePagoDeclaracionId = c.Long(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        HaSidoCancelado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReportePagoDeclaracionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportePagoDeclaracionDetalles", "DeclaracionDeudaCuotaId", "dbo.DeclaracionDeudasCuotas");
            DropForeignKey("dbo.DeclaracionDeudasCuotas", "DeclaracionPreviaId", "dbo.DeclaracionesPrevias");
            DropIndex("dbo.ParametrosVencimientos", new[] { "Mes", "Dia" });
            DropIndex("dbo.ReportePagoDeclaracionDetalles", new[] { "DeclaracionDeudaCuotaId" });
            DropIndex("dbo.DeclaracionDeudasCuotas", new[] { "DeclaracionPreviaId", "FechaVencimiento" });
            DropTable("dbo.ReportePagoDeclaracions");
            DropTable("dbo.ParametrosVencimientos");
            DropTable("dbo.ReportePagoDeclaracionDetalles");
            DropTable("dbo.DeclaracionDeudasCuotas");
        }
    }
}
