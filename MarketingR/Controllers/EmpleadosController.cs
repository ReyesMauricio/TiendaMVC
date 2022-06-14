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
    public class EmpleadosController : Controller
    {
        private MarketingContext db = new MarketingContext();

        // GET: Empleados
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
            var empleadoes = db.Empleadoes.Include(e => e.Tipo_documento);
            return View(empleadoes.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoDocumento = new SelectList(db.Tipo_documento, "IdTipoDocumento", "Descripcion");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Nombres,Apellidos,FechaNacimiento,Salario,Email,Numero_documento,IdTipoDocumento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                TempData["Accion"] = "Insertado";
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoDocumento = new SelectList(db.Tipo_documento, "IdTipoDocumento", "Descripcion", empleado.IdTipoDocumento);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoDocumento = new SelectList(db.Tipo_documento, "IdTipoDocumento", "Descripcion", empleado.IdTipoDocumento);
            ViewBag.FechaNacimiento = string.Format("{0:dd/MM/yyyy}", empleado.FechaNacimiento);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Nombres,Apellidos,FechaNacimiento,Salario,Email,Numero_documento,IdTipoDocumento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Accion"] = "Editado";
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoDocumento = new SelectList(db.Tipo_documento, "IdTipoDocumento", "Descripcion", empleado.IdTipoDocumento);
            return View(empleado);
        }

        public ActionResult EliminarDato(int? id)
        {
            Empleado emp = db.Empleadoes.Find(id);
            db.Empleadoes.Remove(emp);
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
