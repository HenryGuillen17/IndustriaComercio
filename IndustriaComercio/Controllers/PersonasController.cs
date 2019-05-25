using IndustriaComercio.Entidades.Persona;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Model;
using IndustriaComercio.Models.Servicios;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ModelServidor _db;
        private readonly PersonaService _personaService;

        public PersonasController()
        {
            _db = new ModelServidor();
            _personaService = new PersonaService(_db);
        }

        [HttpGet]
        [Route("~/Persona/FindById/{id:int}")]
        public JsonResult GetById(int id)
        {
            return Json(_personaService.FindById(id), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Route("~/Persona/FindByEmail")]
        public JsonResult FindByEmail(PersonaModel model)
        {
            return Json(_personaService.FindByEmail(model.Correo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("~/Persona/FindByIndentificacion")]
        public JsonResult FindByIndentificacion(PersonaModel model)
        {
            return Json(_personaService.FindByIndentificacion(model.NoIdentificacion), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("~/Persona/Save")]
        public JsonResult Save(PersonaModel model)
        {
            return Json(_personaService.Save(model), JsonRequestBehavior.AllowGet);
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
