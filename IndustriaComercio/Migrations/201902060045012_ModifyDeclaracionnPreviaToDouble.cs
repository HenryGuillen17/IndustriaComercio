namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDeclaracionnPreviaToDouble : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeclaracionesPrevias", new[] { "Interes_Anio", "Interes_Mes" }, "dbo.InteresesMora");
            DropIndex("dbo.DeclaracionesPrevias", new[] { "Interes_Anio", "Interes_Mes" });
            AlterColumn("dbo.ActividadesGravablesPorDeclaracion", "IngresosGravados", c => c.Double(nullable: false));
            AlterColumn("dbo.ActividadesGravablesPorDeclaracion", "Tarifa", c => c.Double(nullable: false));
            AlterColumn("dbo.ActividadesGravablesPorDeclaracion", "Impuesto", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosEnElPais", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosFueraDelMunicipio", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalIngresosMunicipio", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosDevoluciones", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosExportaciones", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosActivosFijos", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosNoGravados", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosActividadesExentas", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalIngresosGravables", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalTarifa", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "CapacidadInstalada", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotaImpuestoEnergiaElectrica", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalImpuestoIndustriaComercio", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "ImpuestoAvisosTableros", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "PagoUnidadesComerciales", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "SobretasaBomberil", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "SobretasaSeguridad", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalImpuestoCargo", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "ValorExoneracionImpuesto", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "RetencionesDelMunicipio", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "AutoretencionesDelMunicipio", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "AnticipoAnioAnterior", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "AnticipoAnioSiguiente", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "SaldoFavorPeriodoAnterior", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalSaldoCargo", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalSaldoFavor", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "ValorPagar", c => c.Double(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalPagar", c => c.Double(nullable: false));
            DropColumn("dbo.DeclaracionesPrevias", "Interes_Anio");
            DropColumn("dbo.DeclaracionesPrevias", "Interes_Mes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeclaracionesPrevias", "Interes_Mes", c => c.Byte());
            AddColumn("dbo.DeclaracionesPrevias", "Interes_Anio", c => c.Short());
            AlterColumn("dbo.DeclaracionesPrevias", "TotalPagar", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "ValorPagar", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalSaldoFavor", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalSaldoCargo", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "SaldoFavorPeriodoAnterior", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "AnticipoAnioSiguiente", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "AnticipoAnioAnterior", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "AutoretencionesDelMunicipio", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "RetencionesDelMunicipio", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "ValorExoneracionImpuesto", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalImpuestoCargo", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "SobretasaSeguridad", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "SobretasaBomberil", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "PagoUnidadesComerciales", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "ImpuestoAvisosTableros", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalImpuestoIndustriaComercio", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotaImpuestoEnergiaElectrica", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "CapacidadInstalada", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalTarifa", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalIngresosGravables", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosActividadesExentas", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosNoGravados", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosActivosFijos", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosExportaciones", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosDevoluciones", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "TotalIngresosMunicipio", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosFueraDelMunicipio", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "IngresosEnElPais", c => c.Int(nullable: false));
            AlterColumn("dbo.ActividadesGravablesPorDeclaracion", "Impuesto", c => c.Int(nullable: false));
            AlterColumn("dbo.ActividadesGravablesPorDeclaracion", "Tarifa", c => c.Int(nullable: false));
            AlterColumn("dbo.ActividadesGravablesPorDeclaracion", "IngresosGravados", c => c.Int(nullable: false));
            CreateIndex("dbo.DeclaracionesPrevias", new[] { "Interes_Anio", "Interes_Mes" });
            AddForeignKey("dbo.DeclaracionesPrevias", new[] { "Interes_Anio", "Interes_Mes" }, "dbo.InteresesMora", new[] { "Anio", "Mes" });
        }
    }
}
