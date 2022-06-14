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
    public class ProductoesController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: Productoes
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
                var productoes = db.Productoes.Include(p => p.oCategoria);
            return View(productoes.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Descripcion");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,Nombre_producto,Precio,Cantidad,Ultima_compra,Existencias,IdCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
                TempData["Accion"] = "Insertado";
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Descripcion", producto.IdCategoria);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ultima_compra = string.Format("{0:dd/MM/yyyy}", producto.Ultima_compra);
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Descripcion", producto.IdCategoria);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,Nombre_producto,Precio,Cantidad,Ultima_compra,Existencias,IdCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Accion"] = "Editado";
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Descripcion", producto.IdCategoria);
            return View(producto);
        }

        public ActionResult EliminarDato(int? id)
        {
            Producto dato = db.Productoes.Find(id);
            db.Productoes.Remove(dato);
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
