using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndustriaComercio.Common.Utils;
using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Servicios;

namespace IndustriaComercio.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private ModelServidor _db;
        private TipoDocumentoService _tipoDocumentoService;

        public TipoDocumentoController()
        {
            _db = new ModelServidor();
            _tipoDocumentoService = new TipoDocumentoService(_db);
        }
        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View(_db.TipoDocumento.ToList());
        }

        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoDocumentoId,Descripcion,Estado")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                tipoDocumento.TipoDocumentoId = _tipoDocumentoService.GetConsecutivo();
                _db.TipoDocumento.Add(tipoDocumento);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = _db.TipoDocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDocumentoId,Descripcion,Estado")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(tipoDocumento).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDocumento);
        }


        public JsonResult FindAllCb()
        {
            return Json(
                _db.TipoDocumento
                .Select(x => new ComboBox
                {
                    Key = x.TipoDocumentoId,
                    Value = x.Descripcion
                }).ToList(), 
                JsonRequestBehavior.AllowGet);
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
