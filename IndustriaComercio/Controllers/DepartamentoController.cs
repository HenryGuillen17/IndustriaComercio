using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly ModelServidor _db;

        public DepartamentoController()
        {
            _db = new ModelServidor();
        }

        public JsonResult FindAllAutocomplete(int limit, string value)
        {
            return Json(
                _db.Departamento.Where(x => x.Descripcion.StartsWith(value.Trim()))
                .Select(x => new ComboBox
                {
                    Key = x.DepartamentoId, 
                    Value = x.Descripcion
                }).ToList(), 
                JsonRequestBehavior.AllowGet
                );
        }

    }
}