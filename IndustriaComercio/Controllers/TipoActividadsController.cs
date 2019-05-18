using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Servicios;

namespace IndustriaComercio.Controllers
{
    public class TipoActividadsController : Controller
    {
        private ModelServidor _db;
        private TipoActividadService _tipoActividadService;

        public TipoActividadsController()
        {
            _db = new ModelServidor();
            _tipoActividadService = new TipoActividadService(_db);
        }

        // GET: TipoActividads
        public ActionResult Index()
        {
            return View(_db.TipoActividad.ToList());
        }

        // GET: TipoActividads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoActividads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoActividadId,Descripcion,Estado")] TipoActividad tipoActividad)
        {
            if (ModelState.IsValid)
            {
                tipoActividad.TipoActividadId = _tipoActividadService.GetConsecutivo();
                _db.TipoActividad.Add(tipoActividad);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoActividad);
        }

        // GET: TipoActividads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoActividad tipoActividad = _db.TipoActividad.Find(id);
            if (tipoActividad == null)
            {
                return HttpNotFound();
            }
            return View(tipoActividad);
        }

        // POST: TipoActividads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoActividadId,Descripcion,Estado")] TipoActividad tipoActividad)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(tipoActividad).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoActividad);
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
