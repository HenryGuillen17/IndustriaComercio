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

        // GET: Personas
        public ActionResult Index()
        {
            var persona = _db.Persona.Include(p => p.Cliente).Include(p => p.TipoDocumento).Include(p => p.Usuario);
            return View(persona.ToList());
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoId = new SelectList(_db.TipoDocumento, "TipoDocumentoId", "Descripcion");
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonaId,TipoDocumentoId,NoIdentificacion,DigitoChequeo,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,NombreCompleto,FotoPerfil,Correo,Celular,Direccion,Municipio,Departamento,Telefono")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _db.Persona.Add(persona);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoId = new SelectList(_db.TipoDocumento, "TipoDocumentoId", "Descripcion", persona.TipoDocumentoId);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = _db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoId = new SelectList(_db.TipoDocumento, "TipoDocumentoId", "Descripcion", persona.TipoDocumentoId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonaId,TipoDocumentoId,NoIdentificacion,DigitoChequeo,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,NombreCompleto,FotoPerfil,Correo,Celular,Direccion,Municipio,Departamento,Telefono")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(persona).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoId = new SelectList(_db.TipoDocumento, "TipoDocumentoId", "Descripcion", persona.TipoDocumentoId);
            return View(persona);
        }


        [HttpGet]
        [Route("~/Persona/FindById/{id:int}")]
        public JsonResult GetById(int id)
        {
            return Json(_personaService.FindById(id), JsonRequestBehavior.AllowGet);
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
