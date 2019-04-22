using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CrystalDecisions.CrystalReports.Engine;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Reportes.Model;
using IndustriaComercio.Models.Reportes.Pdf;

namespace IndustriaComercio.Models.Servicios
{
    public class DeclaracionPreviaService
    {
        private readonly ModelServidor _db;

        public DeclaracionPreviaService(
            ModelServidor db
            )
        {
            _db = db;
        }


        public ReportDocument GetReportByDeclaracionPreviaId(
            int declaracionPreviaId
            )
        {
            var model = GetListReporteByIdDeclaracion(declaracionPreviaId);
            var actividades = GetListActividadesReporteByIdDeclaracion(declaracionPreviaId);

            ReportDocument report;
            report = new CRDeclaracionPrevia();

            report.Database.Tables[0].SetDataSource(model);
            report.Database.Tables[1].SetDataSource(actividades);

            return report;
        }


        private IEnumerable<DeclaracionPreviaReport> GetListReporteByIdDeclaracion(
            int declaracionPreviaId
            )
        {
            var model = _db.DeclaracionPrevia
                .Include(x => x.Cliente.Persona)
                .Include(x => x.TipoSancion)
                .Include(x => x.ActividadesGravadas)
                .Where(x => x.DeclaracionPreviaId == declaracionPreviaId)
                .Select(
                x => new DeclaracionPreviaReport
                {
                    DeclaracionPreviaId = x.DeclaracionPreviaId,
                    Anio = x.Año,
                    DepartamentoReporte = "Santander",
                    MunicipioReporte = "Piedecuesta",
                    TipoDeclaracion = "Declaración Inicial",
                    PagaAvisoTablero = x.PagaAvisoTablero,
                    FechaDeclaracion = x.FechaDeclaracion,
                    PersonaId = x.PersonaId,
                    NombreRazonSocial = x.Cliente.Persona.NombreCompleto,
                    TipoDocumentoNombre = x.Cliente.Persona.TipoDocumento.Descripcion,
                    NoIdentificacion = x.Cliente.Persona.NoIdentificacion,
                    DigitoChequeo = x.Cliente.Persona.DigitoChequeo,
                    DireccionNegocio = x.Cliente.Persona.Direccion,
                    MunicipioNegocio = x.Cliente.Persona.Municipio.Descripcion,
                    DepartamentoNegocio = x.Cliente.Persona.Municipio.Departamento.Descripcion,
                    Telefono = x.Cliente.Persona.Telefono,
                    CorreoElectronico = x.Cliente.Persona.Correo,
                    TipoContribuyenteNombre = x.Cliente.ClasificacionContribuyente.Descripcion,
                    NoEstablecimientos = x.Cliente.NumeroEstablecimientos,
                    IngresosEnElPais = x.IngresosEnElPais,
                    IngresosFueraDelMunicipio = x.IngresosFueraDelMunicipio,
                    TotalIngresosMunicipio = x.TotalIngresosMunicipio,
                    IngresosDevoluciones = x.IngresosDevoluciones,
                    IngresosExportaciones = x.IngresosExportaciones,
                    IngresosActivosFijos = x.IngresosActivosFijos,
                    IngresosNoGravados = x.IngresosNoGravados,
                    IngresosActividadesExentas = x.IngresosActividadesExentas,
                    TotalIngresosGravables = x.TotalIngresosGravables,
                    TotalImpuestrosGravados = x.ActividadesGravadas.Sum(y => y.Impuesto),
                    CapacidadInstalada = x.CapacidadInstalada,
                    TotaImpuestoEnergiaElectrica = x.TotaImpuestoEnergiaElectrica,
                    TotalImpuestoIndustriaComercio = x.TotalImpuestoIndustriaComercio,
                    ImpuestoAvisosTableros = x.ImpuestoAvisosTableros,
                    PagoUnidadesComerciales = x.PagoUnidadesComerciales,
                    SobretasaBomberil = x.SobretasaBomberil,
                    SobretasaSeguridad = x.SobretasaSeguridad,
                    TotalImpuestoCargo = x.TotalImpuestoCargo,
                    ValorExoneracionImpuesto = x.ValorExoneracionImpuesto,
                    RetencionesDelMunicipio = x.RetencionesDelMunicipio,
                    AutoretencionesDelMunicipio = x.AutoretencionesDelMunicipio,
                    DocumentoRetencion = x.DocumentoRetencion,
                    AnticipoAnioAnterior = x.AnticipoAnioAnterior,
                    AnticipoAnioSiguiente = x.AnticipoAnioSiguiente,
                    // TIENE ERRORES  QUE NO IDENTIFICO, AL DESCOMENTAR ESOS DATOS, NO ME TRAE NINGÚN REGISTRO
                    //TipoSancionNombre = x.TipoSancionId != null ? x.TipoSancion.Descripcion : "-- Sin Sanción --",
                    //ValorSancion = x.TipoSancionId != null ? (x.TipoSancion.Porcentaje * 0.01) * x.TotalImpuestoCargo : 0,
                    SaldoFavorPeriodoAnterior = x.SaldoFavorPeriodoAnterior,
                    TotalSaldoCargo = x.TotalSaldoCargo,
                    TotalSaldoFavor = x.TotalSaldoFavor,
                    ValorPagar = x.ValorPagar,
                    Descuento = x.Descuento,
                    Interes = x.Interes,
                    TotalPagar = x.TotalPagar
                })
                .ToList();

            return model;
        }

        private IEnumerable<ActividadGravada> GetListActividadesReporteByIdDeclaracion(
            int declaracionPreviaId
            )
        {
            return _db.ActividadGravablePorDeclaracion
                .Include(x => x.Actividad)
                .Where(x => x.DeclaracionPreviaId == declaracionPreviaId)
                .Select(x => new ActividadGravada
                {
                    ActividadId = x.ActividadId,
                    Codigo = x.Actividad.Codigo,
                    Descripcion = x.Actividad.Descripcion,
                    IngresosGravados = x.IngresosGravados,
                    Tarifa = x.Actividad.Tarifa,
                    Impuesto = x.Impuesto,
                }).ToList();
        }
    }
}