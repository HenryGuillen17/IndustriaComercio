using IndustriaComercio.Common;
using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Entidades.Basicos;
using IndustriaComercio.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class DeclaracionPreviaController : Controller
    {
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
            try
            {
                // Si no es válido, se regresa a corregir
                if (!ModelState.IsValid || !model.ActividadesGravadas.Any())
                {
                    CalcularListasDropDown(ref model);
                    return View(model);
                }
                SetDeclaracionPrevia(model);

                return RedirectToAction("Exito");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ActionResult Exito()
        {
            return View();
        }

        // GET: DeclaracionPrevia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeclaracionPrevia/Create
        public ActionResult Create(DeclaracionPreviaModel declaracion)
        {
            return View();
        }

        // POST: DeclaracionPrevia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DeclaracionPrevia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeclaracionPrevia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DeclaracionPrevia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeclaracionPrevia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private void CalcularListasDropDown(
            ref DeclaracionPreviaModel model
            )
        {
            var db = new ModelServidor();
            var tiposDeDocumentos = db.TipoDocumento.ToList();
            var tiposDeContribuyentes = db.TipoContribuyente.ToList();
            var actividadesGravadas = db.ActividadGravada.OrderBy(x => x.Descripcion)
                    .Select(x => new ComboBox
                        {
                            Key = x.ActividadId,
                            Value = x.Descripcion
                        })
                    .ToList();
            var clasificacionesContribuyentes = db.ClasificacionContribuyente.OrderBy(x => x.Descripcion)
                    .Select(x => new ComboBox
                        {
                            Key = x.ClasificacionContribuyenteId,
                            Value = x.Descripcion
                        })
                    .ToList();

            model.TipoDocumentos = tiposDeDocumentos
                .Select(x => new SelectListItem { Text = x.Descripcion, Value = x.TipoDocumentoId.ToString() }).ToList();
            model.TipoContribuyentes = tiposDeContribuyentes
                .Select(x => new SelectListItem { Text = x.Descripcion, Value = x.TipoContribuyenteId.ToString() }).ToList();
            model.ListaActividadesGravadas = actividadesGravadas;
            model.ListaClasificacionesContribuyentes = clasificacionesContribuyentes;
        }

        private void SetDeclaracionPrevia(
            DeclaracionPreviaModel model
            )
        {
            var db = new ModelServidor();

            var declaracionPreviaId = db.DeclaracionPrevia.Consecutivo(x => x.DeclaracionPreviaId);

            var declaracionPrevia = ToDeclaracionPrevia(model, declaracionPreviaId);
            var actividadesGravadas = ToActividadesGravadas(
                model.ActividadesGravadas, declaracionPreviaId
                );

            db.DeclaracionPrevia.Add(declaracionPrevia);
            db.ActividadGravablePorDeclaracion.AddRange(actividadesGravadas);

            db.SaveChanges();
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
                    Tarifa = x.Tarifa,
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
                Año = model.Año,
                TipoDeclaracion = model.TipoDeclaracion,
                TipoContribuyenteId = model.TipoContribuyenteId,
                TienePagoVoluntario = model.TienePagoVoluntario,
                PersonaId = model.ClienteId,
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
                AutoretencionesDelMunicipio = model.AutoretencionesDelMunicipio,
                AnticipoAnioAnterior = model.AnticipoAnioAnterior,
                AnticipoAnioSiguiente = model.AnticipoAnioSiguiente,
                TipoSancion = model.TipoSancion,
                SaldoFavorPeriodoAnterior = model.SaldoFavorPeriodoAnterior,
                TotalSaldoCargo = model.TotalSaldoCargo,
                TotalSaldoFavor = model.TotalSaldoFavor,
                ValorPagar = model.ValorPagar,
                TotalPagar = model.TotalPagar
            };
        }
    }
}
