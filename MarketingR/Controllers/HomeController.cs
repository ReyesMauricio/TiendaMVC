using MarketingR.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketingR.Models;

namespace MarketingR.Controllers
{
    public class HomeController : Controller
    {
        private MarketingContext db = new MarketingContext();

        public ActionResult Index()
        {
            ViewData["MostarGrafica"] = true;
            ViewData["NumeroEmpleados"] = CountEmpleados();
            ViewData["NumeroClientes"] = CountClientes();
            ViewData["NumeroProductos"] = CountProductos();
            ViewData["TotalVenta"] = SumaVentas();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Contar el numero de Registro de empelados
        private int CountEmpleados() {
            int NumEmpleados = (from emp in db.Empleadoes select emp).Count();
            return NumEmpleados;
        }

        // Contar numero de Clienets
        private int CountClientes() {
            int NumClientes = (from cli in db.Clientes select cli).Count();
            return NumClientes;
        }

        //Contar numero de Productos
        private int CountProductos() { 
            int NumProductos = (from pro in db.Productoes select pro).Count();
            return NumProductos;
        }

        //Suma de ventas
        private double SumaVentas() {
            var ventas = from detalle in db.Detalle_venta select detalle;
            try
            {
                double SumVentas = ventas.Sum(detalle => detalle.PrecioVenta);
                return SumVentas;
            }
            catch (System.InvalidOperationException ex) {
                return 0;
            }
        }

        //grafica ventas
        [HttpPost]
        public ActionResult GraficaProductosPorCategoria() {

            var total = (from pro in db.Productoes
                        join cat in db.Categorias on pro.IdCategoria equals cat.IdCategoria
                        group cat by cat.Descripcion into g
                        orderby g.Select(x => x.IdCategoria).Count() descending
                        select new
                        {
                            Categoria = g.Key,
                            Total = g.Select(x => x.IdCategoria).Count()
                        }).Take(10);

            return Json(total);
        }

        [HttpPost]
        public ActionResult GraficaVentasPorProducto() {
            var total = (from pro in db.Productoes
                         join detalle in db.Detalle_venta on pro.IdProducto equals detalle.IdProducto
                         group pro by pro.Nombre_producto into g
                         orderby g.Select(x => x.IdProducto).Count() descending
                         select new { 
                            Producto = g.Key,
                            Total = g.Select(x => x.IdProducto).Count()
                         }).Take(10);

            return Json(total);
        }
    }
}