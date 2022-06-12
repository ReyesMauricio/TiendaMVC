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
    public class Tipo_documentoController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: Tipo_documento
        public ActionResult Index()
        {
            return View(db.Tipo_documentos.ToList());
        }

        // GET: Tipo_documento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_documento tipo_documento = db.Tipo_documentos.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // GET: Tipo_documento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_documento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_tipoDocumento,Descripcion")] Tipo_documento tipo_documento)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_documentos.Add(tipo_documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_documento);
        }

        // GET: Tipo_documento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_documento tipo_documento = db.Tipo_documentos.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // POST: Tipo_documento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_tipoDocumento,Descripcion")] Tipo_documento tipo_documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_documento);
        }

        // GET: Tipo_documento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_documento tipo_documento = db.Tipo_documentos.Find(id);
            if (tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_documento);
        }

        // POST: Tipo_documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_documento tipo_documento = db.Tipo_documentos.Find(id);
            db.Tipo_documentos.Remove(tipo_documento);
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
