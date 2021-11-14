using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenFinal.Context;
using ExamenFinal.Models;

namespace ExamenFinal.Controllers
{
    public class ProductoController : Controller
    {
        private SQLDbContext db = new SQLDbContext();

        // GET: Producto
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.FK_Producto_Proveedor);
            return View(producto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModel productoModel = db.Producto.Find(id);
            if (productoModel == null)
            {
                return HttpNotFound();
            }
            return View(productoModel);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "NombreProveedor");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,NombreProducto,Descripcion,IdProveedor,FechaVencimiento,UbicacionFisica,ExistenciaMinima,PrecioUnidad")] ProductoModel productoModel)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(productoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "NombreProveedor", productoModel.IdProveedor);
            return View(productoModel);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModel productoModel = db.Producto.Find(id);
            if (productoModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "NombreProveedor", productoModel.IdProveedor);
            return View(productoModel);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,NombreProducto,Descripcion,IdProveedor,FechaVencimiento,UbicacionFisica,ExistenciaMinima,PrecioUnidad")] ProductoModel productoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "NombreProveedor", productoModel.IdProveedor);
            return View(productoModel);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoModel productoModel = db.Producto.Find(id);
            if (productoModel == null)
            {
                return HttpNotFound();
            }
            return View(productoModel);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoModel productoModel = db.Producto.Find(id);
            db.Producto.Remove(productoModel);
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
