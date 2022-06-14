using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarketingR.Context;
using MarketingR.Models;

namespace MarketingR.Controllers
{
    public class Tipo_documentosController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: Tipo_documentos
        public ActionResult Index()
        {
            return View(db.Tipo_documento.ToList());
        }

        // GET: Tipo_documentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_documento tipo_documento = db.Tipo_documento.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // GET: Tipo_documentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_documentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoDocumento,Descripcion")] Tipo_documento tipo_documento)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_documento.Add(tipo_documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_documento);
        }

        // GET: Tipo_documentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_documento tipo_documento = db.Tipo_documento.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // POST: Tipo_documentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoDocumento,Descripcion")] Tipo_documento tipo_documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_documento);
        }

        // GET: Tipo_documentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_documento tipo_documento = db.Tipo_documento.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // POST: Tipo_documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_documento tipo_documento = db.Tipo_documento.Find(id);
            db.Tipo_documento.Remove(tipo_documento);
            db.SaveChanges();
            return RedirectToAction("Index");
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
