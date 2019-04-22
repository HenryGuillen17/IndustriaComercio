using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class ClasificacionContribuyenteController : Controller
    {
        private readonly ModelServidor _db;

        public ClasificacionContribuyenteController() { _db = new ModelServidor(); }

        public JsonResult FindAllCb()
        {
            return Json(_db.ClasificacionContribuyente
                .Select(x => new ComboBox
                {
                    Key = x.ClasificacionContribuyenteId,
                    Value = x.Descripcion
                })
                .ToList(),
                JsonRequestBehavior.AllowGet
                );
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
