using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndustriaComercio.Entidades.Persona;
using IndustriaComercio.Models.Context;

namespace IndustriaComercio.Controllers
{
    public class PersonasController : Controller
    {
        private ModelServidor db = new ModelServidor();

        // GET: Personas
        public ActionResult Index()
        {
            var persona = db.Persona.Include(p => p.Cliente).Include(p => p.TipoDocumento).Include(p => p.Usuario);
            return View(persona.ToList());
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "TipoDocumentoId", "Descripcion");
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
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "TipoDocumentoId", "Descripcion", persona.TipoDocumentoId);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "TipoDocumentoId", "Descripcion", persona.TipoDocumentoId);
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
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "TipoDocumentoId", "Descripcion", persona.TipoDocumentoId);
            return View(persona);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
