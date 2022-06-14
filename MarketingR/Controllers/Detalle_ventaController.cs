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
            if (TempData["Accion"] != null)
            {
                var accion = Convert.ToString(TempData["Accion"]);
                if (accion == "Insertado")
                {
                    ViewBag.Accion = "Insertado";
                }
                else if (accion == "Editado")
                {
                    ViewBag.Accion = "Editado";
                }
                else if (accion == "Eliminado")
                {
                    ViewBag.Accion = "Eliminado";
                }
            }
            var detalle_venta = db.Detalle_venta.Include(d => d.oProducto).Include(d => d.oVenta);
            return View(detalle_venta.ToList());
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
            Producto dato = db.Productoes.Find(detalle_venta.IdProducto);
            decimal cantidad = dato.Precio;
            decimal precioVenta = detalle_venta.Cantidad * cantidad;

            var detalleVenta = new Detalle_venta
            {
                IdDetalleVenta = detalle_venta.IdDetalleVenta,
                IdVenta = detalle_venta.IdVenta,
                IdProducto = detalle_venta.IdProducto,
                Cantidad = detalle_venta.Cantidad,
                PrecioVenta = ((double)precioVenta)
            };
            if (ModelState.IsValid)
            {
                db.Detalle_venta.Add(detalleVenta);
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
                TempData["Accion"] = "Editado";
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.Productoes, "IdProducto", "Nombre_producto", detalle_venta.IdProducto);
            ViewBag.IdVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", detalle_venta.IdVenta);
            return View(detalle_venta);
        }

        public ActionResult EliminarDato(int? id)
        {
            Detalle_venta dato = db.Detalle_venta.Find(id);
            db.Detalle_venta.Remove(dato);
            TempData["Accion"] = "Eliminado";
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
