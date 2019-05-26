using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Entidades.Declaracion;
using IndustriaComercio.Models.Model;
using IndustriaComercio.Models.Reportes.Pdf;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class DeclaracionDeudaCuotaController : Controller
    {
        private readonly ModelServidor _db;

        public DeclaracionDeudaCuotaController()
        {
            _db = new ModelServidor();
        }

        // GET: DeclaracionDeudaCuota
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetListDeclaracionDeudaCuotaPaginado(
            string sort, int page, int perPage, string filter
            )
        {
            var apiFilter = new ApiFilter<DeclaracionDeudaCuotaModel>(sort, page, perPage, filter);

            var filtros = apiFilter.Filtros != null;

            var list =
                from a in _db.DeclaracionDeudaCuota.Include(x => x.DeclaracionPrevia)
                where
                    filtros &&
                    (
                        apiFilter.Filtros.PersonaId == 0 || a.DeclaracionPrevia.PersonaId == apiFilter.Filtros.PersonaId
                    )
                select new DeclaracionDeudaCuotaModel
                {
                    DeclaracionDeudaCuotaId = a.DeclaracionDeudaCuotaId,
                    DeclaracionPreviaId = a.DeclaracionPreviaId,
                    FechaVencimiento = a.FechaVencimiento,
                    PersonaId = a.DeclaracionPrevia.PersonaId,
                    AnioDeclaracion = a.DeclaracionPrevia.Año,
                    TotalImpuestoIndustriaComercio = a.TotalImpuestoIndustriaComercio,
                    ImpuestoAvisosTableros = a.ImpuestoAvisosTableros,
                    PagoUnidadesComerciales = a.PagoUnidadesComerciales,
                    SobretasaBomberil = a.SobretasaBomberil,
                    SobretasaSeguridad = a.SobretasaSeguridad,
                    TotalImpuestoCargo = a.TotalImpuestoCargo,
                    ValorExoneracionImpuesto = a.ValorExoneracionImpuesto,
                    RetencionesDelMunicipio = a.RetencionesDelMunicipio,
                    AutoretencionesDelMunicipio = a.AutoretencionesDelMunicipio,
                    AnticipoAnioAnterior = a.AnticipoAnioAnterior,
                    AnticipoAnioSiguiente = a.AnticipoAnioSiguiente,
                    ValorSancion = a.ValorSancion,
                    SaldoFavorPeriodoAnterior = a.SaldoFavorPeriodoAnterior,
                    TotalSaldoCargo = a.TotalSaldoCargo,
                    TotalSaldoFavor = a.TotalSaldoFavor,
                    InteresesMora = 0,
                };

            return Json(list.OrderBy(apiFilter.OrdenarPor, apiFilter.EsAscendente)
                .ToPagedList(apiFilter.PaginaNo, apiFilter.PorPagina).Paginar(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FindById(int id)
        {
            var model = (
                from a in _db.DeclaracionDeudaCuota.Include(x => x.DeclaracionPrevia)
                where
                    a.DeclaracionDeudaCuotaId == id
                select new DeclaracionDeudaCuotaModel
                {
                    DeclaracionDeudaCuotaId = a.DeclaracionDeudaCuotaId,
                    DeclaracionPreviaId = a.DeclaracionPreviaId,
                    FechaVencimiento = a.FechaVencimiento,
                    PersonaId = a.DeclaracionPrevia.PersonaId,
                    AnioDeclaracion = a.DeclaracionPrevia.Año,
                    TotalImpuestoIndustriaComercio = a.TotalImpuestoIndustriaComercio,
                    ImpuestoAvisosTableros = a.ImpuestoAvisosTableros,
                    PagoUnidadesComerciales = a.PagoUnidadesComerciales,
                    SobretasaBomberil = a.SobretasaBomberil,
                    SobretasaSeguridad = a.SobretasaSeguridad,
                    TotalImpuestoCargo = a.TotalImpuestoCargo,
                    ValorExoneracionImpuesto = a.ValorExoneracionImpuesto,
                    RetencionesDelMunicipio = a.RetencionesDelMunicipio,
                    AutoretencionesDelMunicipio = a.AutoretencionesDelMunicipio,
                    AnticipoAnioAnterior = a.AnticipoAnioAnterior,
                    AnticipoAnioSiguiente = a.AnticipoAnioSiguiente,
                    ValorSancion = a.ValorSancion,
                    SaldoFavorPeriodoAnterior = a.SaldoFavorPeriodoAnterior,
                    TotalSaldoCargo = a.TotalSaldoCargo,
                    TotalSaldoFavor = a.TotalSaldoFavor,
                    InteresesMora = 0,
                }).FirstOrDefault();

            model.InteresesMora = CalculoInteresMora(new CalculoInteres(model.FechaVencimiento, model.TotalSaldoCargo));

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GenerarPlanillaPago(HashSet<int> ids)
        {

            var fechaVencimiento = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            var reporteId = GenerarReporte(ids);

            var model = _db.DeclaracionDeudaCuota
                .Include(x => x.DeclaracionPrevia).Include(x => x.DeclaracionPrevia.Cliente.Persona)
                .Include(x => x.DeclaracionPrevia.Cliente.Persona.TipoDocumento)
                .Where(x => ids.Contains(x.DeclaracionDeudaCuotaId))
                .Select(y => new DeclaracionDeudaCuotaModel
                {
                    ReporteId = reporteId,
                    PersonaId = y.DeclaracionPrevia.PersonaId,
                    NombreCompleto = y.DeclaracionPrevia.Cliente.Persona.NombreCompleto,
                    NoIdentificacionCompleto = y.DeclaracionPrevia.Cliente.Persona.TipoDocumento.Descripcion + " - " + y.DeclaracionPrevia.Cliente.Persona.NoIdentificacion,
                    FechaVencimiento = fechaVencimiento,
                    TotalImpuestoIndustriaComercio = y.TotalImpuestoIndustriaComercio,
                    ImpuestoAvisosTableros = y.ImpuestoAvisosTableros,
                    PagoUnidadesComerciales = y.PagoUnidadesComerciales,
                    SobretasaBomberil = y.SobretasaBomberil,
                    SobretasaSeguridad = y.SobretasaSeguridad,
                    TotalImpuestoCargo = y.TotalImpuestoCargo,
                    ValorExoneracionImpuesto = y.ValorExoneracionImpuesto,
                    RetencionesDelMunicipio = y.RetencionesDelMunicipio,
                    AutoretencionesDelMunicipio = y.AutoretencionesDelMunicipio,
                    AnticipoAnioAnterior = y.AnticipoAnioAnterior,
                    AnticipoAnioSiguiente = y.AnticipoAnioSiguiente,
                    ValorSancion = y.ValorSancion,
                    SaldoFavorPeriodoAnterior = y.SaldoFavorPeriodoAnterior,
                    TotalSaldoCargo = y.TotalSaldoCargo,
                    TotalSaldoFavor = y.TotalSaldoFavor
                }).ToList();

            model.ForEach(x => x.InteresesMora = CalculoInteresMora(new CalculoInteres(x.FechaVencimiento, x.TotalSaldoCargo)));

            var modelReport = model
                .GroupBy(x => new
                {
                    x.PersonaId,
                    x.NombreCompleto,
                    x.NoIdentificacionCompleto
                })
                .Select(y => new DeclaracionDeudaCuotaModel
                {
                    ReporteId = reporteId,
                    PersonaId = y.Key.PersonaId,
                    NombreCompleto = y.Key.NombreCompleto,
                    NoIdentificacionCompleto = y.Key.NoIdentificacionCompleto,
                    FechaVencimiento = fechaVencimiento,
                    TotalImpuestoIndustriaComercio = y.Sum(x => x.TotalImpuestoIndustriaComercio),
                    ImpuestoAvisosTableros = y.Sum(x => x.ImpuestoAvisosTableros),
                    PagoUnidadesComerciales = y.Sum(x => x.PagoUnidadesComerciales),
                    SobretasaBomberil = y.Sum(x => x.SobretasaBomberil),
                    SobretasaSeguridad = y.Sum(x => x.SobretasaSeguridad),
                    TotalImpuestoCargo = y.Sum(x => x.TotalImpuestoCargo),
                    ValorExoneracionImpuesto = y.Sum(x => x.ValorExoneracionImpuesto),
                    RetencionesDelMunicipio = y.Sum(x => x.RetencionesDelMunicipio),
                    AutoretencionesDelMunicipio = y.Sum(x => x.AutoretencionesDelMunicipio),
                    AnticipoAnioAnterior = y.Sum(x => x.AnticipoAnioAnterior),
                    AnticipoAnioSiguiente = y.Sum(x => x.AnticipoAnioSiguiente),
                    ValorSancion = y.Sum(x => x.ValorSancion),
                    SaldoFavorPeriodoAnterior = y.Sum(x => x.SaldoFavorPeriodoAnterior),
                    TotalSaldoCargo = y.Sum(x => x.TotalSaldoCargo),
                    TotalSaldoFavor = y.Sum(x => x.TotalSaldoFavor),
                    InteresesMora = y.Sum(x => x.InteresesMora),
                }).FirstOrDefault();

            ReportDocument report = new CRDeclaracionDeudaCuota();

            report.Database.Tables[0].SetDataSource(new List<DeclaracionDeudaCuotaModel> { modelReport });

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            var stream = report.ExportToStream(ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            byte[] m_Bytes = StreamExtensions.ReadToEnd(stream);

            return Json(Convert.ToBase64String(m_Bytes, 0, m_Bytes.Length));
        }

        private long GenerarReporte(HashSet<int> ids)
        {
            var consecutivo = _db.ReportePagoDeclaracion.Consecutivo(x => x.ReportePagoDeclaracionId);
            var reporte = new ReportePagoDeclaracion
            {
                ReportePagoDeclaracionId = consecutivo,
                FechaCreacion = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddMonths(1).AddDays(-1),
                HaSidoCancelado = false
            };
            var reporteDetalle = new List<ReportePagoDeclaracionDetalle>();
            foreach (var i in ids)
            {
                reporteDetalle.Add(
                    new ReportePagoDeclaracionDetalle
                    {
                        DeclaracionDeudaCuotaId = i,
                        ReportePagoDeclaracionId = consecutivo,
                    });
            }
            _db.ReportePagoDeclaracion.Add(reporte);
            _db.ReportePagoDeclaracionDetalle.AddRange(reporteDetalle);

            _db.SaveChanges();

            return consecutivo;
        }

        private double CalculoInteresMora(CalculoInteres data)
        {
            var fechaHoy = DateTime.Now;
            var rangoInicial = new DateTime(data.FechaVencimiento.AddMonths(1).Year, data.FechaVencimiento.AddMonths(1).Month, 1);
            var rangoFinal = data.FechaVencimiento.AddMonths(Math.Abs((rangoInicial.Month - fechaHoy.Month) + 12 * (rangoInicial.Year - fechaHoy.Year)));

            var intereses = _db.Interes.Where(x =>
                DbFunctions.TruncateTime(DbFunctions.CreateDateTime(x.Anio, x.Mes, 1, 0, 0, 0)) >= DbFunctions.TruncateTime(rangoInicial)
                && DbFunctions.TruncateTime(DbFunctions.CreateDateTime(x.Anio, x.Mes, 1, 0, 0, 0)) <= DbFunctions.TruncateTime(rangoFinal)
                ).Sum(x => x.Porcentaje);

            return data.Total * (intereses * 0.01);
        }

    }
}