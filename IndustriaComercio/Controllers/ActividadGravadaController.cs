using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Entidades.Basicos;
using IndustriaComercio.Models.Servicios;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class ActividadGravadaController : Controller
    {
        private readonly ModelServidor _db;
        private readonly ActividadGravadaService _actividadGravadaService;

        public ActividadGravadaController()
        {
            _db = new ModelServidor();
            _actividadGravadaService = new ActividadGravadaService(_db);
        }
        // GET: ActividadGravada
        public ActionResult Index()
        {
            return View(_db.ActividadGravada.ToList());
        }

        // GET: ActividadGravada/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActividadGravada/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActividadId,Descripcion,Codigo,Tarifa,Valor")] ActividadGravada actividadGravada)
        {
            if (ModelState.IsValid)
            {
                actividadGravada.ActividadId = _actividadGravadaService.GetConsecutivo();
                _db.ActividadGravada.Add(actividadGravada);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actividadGravada);
        }

        // GET: ActividadGravada/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadGravada actividadGravada = _db.ActividadGravada.Find(id);
            if (actividadGravada == null)
            {
                return HttpNotFound();
            }
            return View(actividadGravada);
        }

        // POST: ActividadGravada/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActividadId,Descripcion,Codigo,Tarifa,Valor")] ActividadGravada actividadGravada)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(actividadGravada).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actividadGravada);
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
