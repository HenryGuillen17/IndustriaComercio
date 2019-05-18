using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly ModelServidor _db;

        public MunicipioController()
        {
            _db = new ModelServidor();
        }

        public JsonResult FindAllAutocomplete(int limit, int departamentoId, string value)
        {
            return Json(
                _db.Municipio.Where(x => x.Descripcion.StartsWith(value.Trim()))
                .Select(x => new ComboBox
                {
                    Key = x.MunicipioId, 
                    Value = x.Descripcion
                }).ToList(), 
                JsonRequestBehavior.AllowGet
                );
        }

    }
}