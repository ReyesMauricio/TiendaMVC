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
    public class Detalle_ventaController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: Detalle_venta
        public ActionResult Index()
        {
            var detalle_venta = db.Detalle_venta.Include(d => d.oProducto).Include(d => d.oVenta);
            return View(detalle_venta.ToList());
        }

        // GET: Detalle_venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_venta detalle_venta = db.Detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // GET: Detalle_venta/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "Nombre_producto");
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta");
            return View();
        }

        // POST: Detalle_venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleVenta,IdVenta,IdProducto,Cantidad,PrecioVenta")] Detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_venta.Add(detalle_venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "Nombre_producto", detalle_venta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", detalle_venta.IdVenta);
            return View(detalle_venta);
        }

        // GET: Detalle_venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_venta detalle_venta = db.Detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "Nombre_producto", detalle_venta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", detalle_venta.IdVenta);
            return View(detalle_venta);
        }

        // POST: Detalle_venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleVenta,IdVenta,IdProducto,Cantidad,PrecioVenta")] Detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "Nombre_producto", detalle_venta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", detalle_venta.IdVenta);
            return View(detalle_venta);
        }

        // GET: Detalle_venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_venta detalle_venta = db.Detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // POST: Detalle_venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_venta detalle_venta = db.Detalle_venta.Find(id);
            db.Detalle_venta.Remove(detalle_venta);
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
