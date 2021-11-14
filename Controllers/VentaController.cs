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
    public class VentaController : Controller
    {
        private SQLDbContext db = new SQLDbContext();

        // GET: Venta
        public ActionResult Index()
        {
            var venta = db.Venta.Include(v => v.FK_Cliente_Venta).Include(v => v.FK_Producto_Venta);
            return View(venta.ToList());
        }

        // GET: Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaModel ventaModel = db.Venta.Find(id);
            if (ventaModel == null)
            {
                return HttpNotFound();
            }
            return View(ventaModel);
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NombreCliente");
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "NombreProducto");
            return View();
        }

        // POST: Venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoVenta,Descripcion,IdCliente,IdProducto,Cantidad,FechaVenta")] VentaModel ventaModel)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(ventaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NombreCliente", ventaModel.IdCliente);
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "NombreProducto", ventaModel.IdProducto);
            return View(ventaModel);
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaModel ventaModel = db.Venta.Find(id);
            if (ventaModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NombreCliente", ventaModel.IdCliente);
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "NombreProducto", ventaModel.IdProducto);
            return View(ventaModel);
        }

        // POST: Venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoVenta,Descripcion,IdCliente,IdProducto,Cantidad,FechaVenta")] VentaModel ventaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "NombreCliente", ventaModel.IdCliente);
            ViewBag.IdProducto = new SelectList(db.Producto, "IdProducto", "NombreProducto", ventaModel.IdProducto);
            return View(ventaModel);
        }

        // GET: Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaModel ventaModel = db.Venta.Find(id);
            if (ventaModel == null)
            {
                return HttpNotFound();
            }
            return View(ventaModel);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaModel ventaModel = db.Venta.Find(id);
            db.Venta.Remove(ventaModel);
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
