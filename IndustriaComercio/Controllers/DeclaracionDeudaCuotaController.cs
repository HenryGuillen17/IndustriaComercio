using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
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


        public JsonResult GenerarPlanillaPago(HashSet<int> ids)
        {
            var fechaVencimiento = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            var modelReport = _db.DeclaracionDeudaCuota.Include(x => x.DeclaracionPrevia).Include(x => x.DeclaracionPrevia.Cliente.Persona).Include(x => x.DeclaracionPrevia.Cliente.Persona.TipoDocumento)
                .Where(x => ids.Contains(x.DeclaracionDeudaCuotaId))
                .GroupBy(x => new
                {
                    x.DeclaracionPrevia.PersonaId,
                    x.DeclaracionPrevia.Cliente.Persona.NombreCompleto,
                    NoIdentificacionCompleto = x.DeclaracionPrevia.Cliente.Persona.TipoDocumento.Descripcion + " - " + x.DeclaracionPrevia.Cliente.Persona.NoIdentificacion
                })
                .Select(y => new DeclaracionDeudaCuotaModel
                {
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
                    InteresesMora = 0,
                }).FirstOrDefault();

            ReportDocument report = new CRDeclaracionDeudaCuota();

            report.Database.Tables[0].SetDataSource(new List<DeclaracionDeudaCuotaModel> { modelReport });

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            var stream = report.ExportToStream(ExportFormatType.PortableDocFormat);
            // report.ExportToDisk(ExportFormatType.PortableDocFormat, $@"C:\Users\henry\Documents\PlanillaDePago_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf");
            stream.Seek(0, SeekOrigin.Begin);
            byte[] m_Bytes = StreamExtensions.ReadToEnd(stream);

            return Json(Convert.ToBase64String(m_Bytes, 0, m_Bytes.Length));
            // return Json(new { file = File(stream, "application/pdf", $"PlanillaDePago_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf") });
        }

    }
}