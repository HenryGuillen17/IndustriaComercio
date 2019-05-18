using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Common.Tools;
using IndustriaComercio.Common.Utils;
using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Entidades.Basicos;
using IndustriaComercio.Models.Model;
using IndustriaComercio.Models.Servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class DeclaracionPreviaController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly DeclaracionPreviaService _declaracionPreviaService;


        public DeclaracionPreviaController()
        {
            var db = new ModelServidor();
            _clienteService = new ClienteService(db);
            _declaracionPreviaService = new DeclaracionPreviaService(db);

            //var cliente = new GetDatosClient();

        }


        // GET: DeclaracionPrevia
        public ActionResult Index()
        {
            var model = new DeclaracionPreviaModel();
            CalcularListasDropDown(ref model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DeclaracionPreviaModel model)
        {
            // Si no es válido, se regresa a corregir
            if (!ModelState.IsValid || !model.ActividadesGravadas.Any())
            {
                CalcularListasDropDown(ref model);
                return View(model);
            }
            var declaracionPreviaId = SetDeclaracionPrevia(model);

            return RedirectToAction("Exito", new { declaracionPreviaId });
        }


        public ActionResult Exito(int declaracionPreviaId)
        {
            ViewBag.DeclaracionPreviaId = declaracionPreviaId;
            return View();
        }

        public ActionResult ExportarReporteDeclaracionPrevia(int declaracionPreviaId)
        {
            var model = _declaracionPreviaService.GetReportByDeclaracionPreviaId(declaracionPreviaId);
            IEnumerable<string> listaCorreos = _clienteService.GetListaCorreos().Select(x => x.Correo).ToList();
            var informesPdf = new List<Tuple<Stream, string>>
            {
                new Tuple<Stream, string> (model.ExportToStream(ExportFormatType.PortableDocFormat), "declaracion.pdf")
            };
            // Si vas a utilizar tu cuenta de gmail. primero ve al link y activa el switch que te va a aparecer
            // https://myaccount.google.com/lesssecureapps?pli=1
            EnviarCorreo.EnviarEmail(
                "richardjacomeg@gmail.com",
                "rijako9004",
                listaCorreos,
                $"DeclaracionPrevia_{declaracionPreviaId}_{DateTime.Now:yyyyMMdd}",
                "Declaración Previa",
                null,
                informesPdf,
                null
                );
            return Export(model, $"DeclaracionPrevia_{declaracionPreviaId}_{DateTime.Now:yyyyMMdd}");
        }


        private ActionResult Export(
            ReportDocument report, string fileName
            )
        {
            var sw = new Stopwatch();
            sw.Start();

            var type = ExportFormatType.PortableDocFormat;
            var tipoArchivo = "application/pdf";
            var ext = ".pdf";

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            var stream = report.ExportToStream(type);
            stream.Seek(0, SeekOrigin.Begin);

            sw.Stop();
            Debug.WriteLine($" ***************************   {sw.Elapsed}");

            return File(stream, tipoArchivo, fileName + ext);
        }

        private void CalcularListasDropDown(
            ref DeclaracionPreviaModel model
            )
        {
            var db = new ModelServidor();
            var tiposDeDocumentos = db.TipoDocumento
                .Select(
                    x => new ComboBox
                    {
                        Key = x.TipoDocumentoId,
                        Value = x.Descripcion
                    })
                .ToList();
            var tiposDeContribuyentes = db.TipoActividad.ToList();
            var actividadesGravadas = db.ActividadGravada
                .OrderBy(x => x.Descripcion)
                .Select(x => new ActividadGravadaModel
                {
                    ActividadId = x.ActividadId,
                    Descripcion = x.Descripcion,
                    Codigo = x.Codigo,
                    Tarifa = x.Tarifa,
                    Valor = x.Valor
                })
                .ToList();
            var clasificacionesContribuyentes = db.ClasificacionContribuyente
                .OrderBy(x => x.Descripcion)
                .Select(x => new ComboBox
                {
                    Key = x.ClasificacionContribuyenteId,
                    Value = x.Descripcion
                })
                .ToList();
            var tipoSanciones = db.TipoSancion
                .OrderBy(x => x.Descripcion)
                .Select(x => new TipoSancionModel
                {
                    Key = x.TipoSancionId,
                    Value = x.Descripcion,
                    PorcentajeSancion = x.Porcentaje
                })
                .ToList();

            model.PagaAvisoTablero = true;
            model.TipoDocumentos = tiposDeDocumentos;
            model.TipoContribuyentes = tiposDeContribuyentes
                .Select(x => new SelectListItem { Text = x.Descripcion, Value = x.TipoActividadId.ToString() }).ToList();
            model.ListaActividadesGravadas = actividadesGravadas;
            model.ListaClasificacionesContribuyentes = clasificacionesContribuyentes;
            model.ListaTipoSanciones = tipoSanciones;
            model.TipoSancion = tipoSanciones?.FirstOrDefault()?.Key;
            model.Cliente = model.PersonaId != 0
                ? _clienteService.FindClienteByPersonaId(model.PersonaId)
                : new ClienteModel();
        }

        private int SetDeclaracionPrevia(
            DeclaracionPreviaModel model
            )
        {
            var db = new ModelServidor();

            var declaracionPreviaId = db.DeclaracionPrevia.Consecutivo(x => x.DeclaracionPreviaId);

            // guardarArchivo
            if (model.ArchivoRetencion != null)
                model.RutaArchivoRetencion = FileSave.GuardarArchivo(
                    model.ArchivoRetencion,
                    $"{AppDomain.CurrentDomain.BaseDirectory}/Uploads/{DateTime.Now:yyyy}/{DateTime.Now:MM}",
                    "ArchivoRetencion"
                    );


            var declaracionPrevia = ToDeclaracionPrevia(model, declaracionPreviaId);
            var actividadesGravadas = ToActividadesGravadas(
                model.ActividadesGravadas, declaracionPreviaId
                );
            var deudaCuotas = ToDeudaCuotas(declaracionPrevia);

            db.DeclaracionPrevia.Add(declaracionPrevia);
            db.ActividadGravablePorDeclaracion.AddRange(actividadesGravadas);
            db.DeclaracionDeudaCuota.AddRange(deudaCuotas);

            db.SaveChanges();

            return declaracionPreviaId;
        }

        private IEnumerable<ActividadGravablePorDeclaracion> ToActividadesGravadas(
            ICollection<ActividadGravadaModel> actividadesGravadas,
            int declaracionPreviaId
            )
        {
            return actividadesGravadas.Select(
                x => new ActividadGravablePorDeclaracion
                {
                    ActividadId = x.ActividadId,
                    DeclaracionPreviaId = declaracionPreviaId,
                    IngresosGravados = x.IngresosGravados,
                    Impuesto = x.Impuesto
                }).ToList();
        }

        private static DeclaracionPrevia ToDeclaracionPrevia(
            DeclaracionPreviaModel model, int consecutivo
            )
        {
            return new DeclaracionPrevia
            {
                DeclaracionPreviaId = consecutivo,
                FechaDeclaracion = DateTime.Now,
                Año = model.Año,
                TipoDeclaracion = model.TipoDeclaracion,
                TipoContribuyenteId = model.TipoContribuyenteId,
                TienePagoVoluntario = model.TienePagoVoluntario,
                PersonaId = model.PersonaId,
                IngresosEnElPais = model.IngresosEnElPais,
                IngresosFueraDelMunicipio = model.IngresosFueraDelMunicipio,
                TotalIngresosMunicipio = model.TotalIngresosMunicipio,
                IngresosDevoluciones = model.IngresosDevoluciones,
                IngresosExportaciones = model.IngresosExportaciones,
                IngresosActivosFijos = model.IngresosActivosFijos,
                IngresosNoGravados = model.IngresosNoGravados,
                IngresosActividadesExentas = model.IngresosActividadesExentas,
                TotalIngresosGravables = model.TotalIngresosGravables,
                TotalTarifa = model.TotalTarifa,
                CapacidadInstalada = model.CapacidadInstalada,
                TotaImpuestoEnergiaElectrica = model.TotaImpuestoEnergiaElectrica,
                TotalImpuestoIndustriaComercio = model.TotalImpuestoIndustriaComercio,
                ImpuestoAvisosTableros = model.ImpuestoAvisosTableros,
                PagoUnidadesComerciales = model.PagoUnidadesComerciales,
                SobretasaBomberil = model.SobretasaBomberil,
                SobretasaSeguridad = model.SobretasaSeguridad,
                TotalImpuestoCargo = model.TotalImpuestoCargo,
                ValorExoneracionImpuesto = model.ValorExoneracionImpuesto,
                RetencionesDelMunicipio = model.RetencionesDelMunicipio,
                DocumentoRetencion = model.RutaArchivoRetencion,
                AutoretencionesDelMunicipio = model.AutoretencionesDelMunicipio,
                AnticipoAnioAnterior = model.AnticipoAnioAnterior,
                AnticipoAnioSiguiente = model.AnticipoAnioSiguiente,
                TipoSancionId = model.TipoSancion,
                SaldoFavorPeriodoAnterior = model.SaldoFavorPeriodoAnterior,
                TotalSaldoCargo = model.TotalSaldoCargo,
                TotalSaldoFavor = model.TotalSaldoFavor,
                ValorPagar = model.ValorPagar,
                TotalPagar = model.TotalPagar
            };
        }

        private List<DeclaracionDeudaCuota> ToDeudaCuotas(DeclaracionPrevia model)
        {
            // 1.- consulto todas las cuotas
            // 2.- hace un foreach de esas cuotas y divide to-do lo que vaya a guardar entre el numero de cuotas y seteas la fecha de vencimiento para retornar
            var db = new ModelServidor();
            var deudasCuotas = new List<DeclaracionDeudaCuota>();
            var parametrosVencimientos = db.ParametroVencimiento.ToList();
            var consecutivo = db.DeclaracionDeudaCuota.Consecutivo(y => y.DeclaracionDeudaCuotaId);

            parametrosVencimientos.ForEach(
                x =>
                {
                    deudasCuotas.Add(new DeclaracionDeudaCuota
                    {
                        DeclaracionDeudaCuotaId = consecutivo,
                        DeclaracionPreviaId = model.DeclaracionPreviaId,
                        FechaVencimiento = new DateTime(model.Año, x.Mes, x.Dia),
                        TotalImpuestoIndustriaComercio = model.TotalImpuestoIndustriaComercio / parametrosVencimientos.Count,
                        ImpuestoAvisosTableros = model.ImpuestoAvisosTableros / parametrosVencimientos.Count,
                        PagoUnidadesComerciales = model.PagoUnidadesComerciales / parametrosVencimientos.Count,
                        SobretasaBomberil = model.SobretasaBomberil / parametrosVencimientos.Count,
                        SobretasaSeguridad = model.SobretasaSeguridad / parametrosVencimientos.Count,
                        TotalImpuestoCargo = model.TotalImpuestoCargo / parametrosVencimientos.Count,
                        ValorExoneracionImpuesto = model.ValorExoneracionImpuesto / parametrosVencimientos.Count,
                        RetencionesDelMunicipio = model.RetencionesDelMunicipio / parametrosVencimientos.Count,
                        AutoretencionesDelMunicipio = model.AutoretencionesDelMunicipio / parametrosVencimientos.Count,
                        AnticipoAnioAnterior = model.AnticipoAnioAnterior / parametrosVencimientos.Count,
                        AnticipoAnioSiguiente = model.AnticipoAnioSiguiente / parametrosVencimientos.Count,
                        SaldoFavorPeriodoAnterior = model.SaldoFavorPeriodoAnterior / parametrosVencimientos.Count,
                        TotalSaldoCargo = model.TotalSaldoCargo / parametrosVencimientos.Count,
                        TotalSaldoFavor = model.TotalSaldoFavor / parametrosVencimientos.Count,
                    });
                    consecutivo++;
                });
            return deudasCuotas;
        }
    }
}
