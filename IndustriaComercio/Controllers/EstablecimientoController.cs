using IndustriaComercio.Common.Extensions;
using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class EstablecimientoController : Controller
    {
        private readonly ModelServidor _db;

        public EstablecimientoController() { _db = new ModelServidor(); }

        public JsonResult FindAllCb()
        {
            return Json(_db.Establecimiento
                .Select(x => new ComboBox
                {
                    Key = x.EstablecimientoId,
                    Value = x.Descripcion
                })
                .ToList(),
                JsonRequestBehavior.AllowGet
                );
        }

        public JsonResult FindById(int id)
        {
            return Json(
                _db.Establecimiento
                .Where(x => x.EstablecimientoId == id)
                .Select(x => new EstablecimientoModel
                {
                    EstablecimientoId = x.EstablecimientoId,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    Direccion = x.Direccion,
                    EstablecimientoActividades = x.EstablecimientoActividades
                    .Select(y => new EstablecimientoActividadModel
                    {
                        ActividadId = y.ActividadId,
                        Descripcion = y.Actividad.Descripcion,
                        Codigo = y.Actividad.Codigo,
                        IngresosGravados = 0,
                        Tarifa = y.Actividad.Tarifa,
                        Valor = y.Actividad.Valor,
                        EstablecimientoId = x.EstablecimientoId,
                    }).ToList(),
                }).FirstOrDefault(), 
                JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Save(EstablecimientoModel model)
        {
            return Json(Guardar(model));
        }
        


        [HttpPost]
        public JsonResult AsignarCliente(ICollection<EstablecimientoModel> list)
        {
            var clienteId = list.Select(x => x.ClienteId).First();

            var listBd = _db.Establecimiento.Include(x => x.EstablecimientoActividades).Where(x => x.ClienteId == clienteId).ToList();

            var a1 = (
                from a in listBd
                join b in list on a.EstablecimientoId equals b.EstablecimientoId into ljb
                from b in ljb.DefaultIfEmpty()
                where b == null
                select a.EstablecimientoId
                ).ToList();

            foreach (var item in listBd)
            {
                if (a1.FirstOrDefault(x => x == item.EstablecimientoId) == 0)
                    continue;
                
                _db.Entry(item).State = EntityState.Deleted;
            }

            _db.SaveChanges();

            foreach (var item in list)
            {
                Guardar(item);
            }

            return Json(true);
        }

        private EstablecimientoModel Guardar(EstablecimientoModel model)
        {
            if (model.EstablecimientoId == 0)
            {
                model.EstablecimientoId = _db.Establecimiento.Consecutivo(x => x.EstablecimientoId);
                _db.Establecimiento.Add(model.ModelFactory());
            }
            else
            {
                var establecimiento = _db.Establecimiento.Include(x => x.EstablecimientoActividades).FirstOrDefault(x => x.EstablecimientoId == model.EstablecimientoId);
                model.ModelFactory(ref establecimiento);
            }

            _db.SaveChanges();

            return model;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
