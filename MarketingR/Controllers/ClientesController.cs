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
    public class ClientesController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: Clientes
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
            var clientes = db.Clientes.Include(c => c.Tipo_documento);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoDocumento = new SelectList(db.Tipo_documento, "IdTipoDocumento", "Descripcion");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Nombres,Apellidos,Correo,Numero_documento,Direccion,Estado,IdTipoDocumento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                TempData["Accion"] = "Insertado";
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoDocumento = new SelectList(db.Tipo_documento, "IdTipoDocumento", "Descripcion", cliente.IdTipoDocumento);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoDocumento = new SelectList(db.Tipo_documento, "IdTipoDocumento", "Descripcion", cliente.IdTipoDocumento);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nombres,Apellidos,Correo,Numero_documento,Direccion,Estado,IdTipoDocumento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Accion"] = "Editado";
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoDocumento = new SelectList(db.Tipo_documento, "IdTipoDocumento", "Descripcion", cliente.IdTipoDocumento);
            return View(cliente);
        }


        public ActionResult EliminarDato(int? id)
        {
            Cliente cl = db.Clientes.Find(id);
            db.Clientes.Remove(cl);
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
