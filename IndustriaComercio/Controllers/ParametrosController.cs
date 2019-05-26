using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class ParametrosController : Controller
    {
        private readonly ModelServidor _db;

        public ParametrosController()
        {
            _db = new ModelServidor();
        }

        // GET: Parametros
        public ActionResult Index()
        {
            return RedirectToAction("VencimientoCuota");
        }
        public ActionResult VencimientoCuota()
        {
            return View();
        }
        public JsonResult ObtenerTodos()
        {
            return Json(_db.ParametroVencimiento.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Bulk(List<ParametroVencimientoModel> list)
        {
            var listModel = new List<ParametroVencimiento>();
            var lisAdd = list.Where(x => x.ParametroVencimientoId == null).ToList();
            var lisUpd = list.Where(x => x.ParametroVencimientoId != null).ToList();
            var idLisUpt = lisUpd.Select(y => y.ParametroVencimientoId).ToList();
            var listEliminar = _db.ParametroVencimiento.Where(x => !idLisUpt.Contains(x.ParametroVencimientoId)).ToList();

            var consecutivo = _db.ParametroVencimiento.Consecutivo(x => x.ParametroVencimientoId);
            lisAdd.ForEach(x =>
            {
                x.ParametroVencimientoId = consecutivo;
                consecutivo++;
            });
            listModel.AddRange(
                lisUpd.Select(x => new ParametroVencimiento
                {
                    ParametroVencimientoId = x.ParametroVencimientoId ?? 0,
                    Mes = x.Mes,
                    Dia = x.Dia,
                }));

            listModel.ForEach(x => _db.Entry(x).State = EntityState.Modified);

            _db.ParametroVencimiento.AddRange(
                lisAdd.Select(x => new ParametroVencimiento
                {
                    ParametroVencimientoId = x.ParametroVencimientoId ?? 0,
                    Mes = x.Mes,
                    Dia = x.Dia,
                }));

            _db.ParametroVencimiento.RemoveRange(listEliminar);

            _db.SaveChanges();

            return Json(lisAdd.Concat(lisUpd).OrderBy(x => x.Mes));
        }


    }
}