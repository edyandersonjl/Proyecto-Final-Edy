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
    public class ProveedorController : Controller
    {
        private SQLDbContext db = new SQLDbContext();

        // GET: Proveedor
        public ActionResult Index()
        {
            return View(db.Proveedor.ToList());
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorModel proveedorModel = db.Proveedor.Find(id);
            if (proveedorModel == null)
            {
                return HttpNotFound();
            }
            return View(proveedorModel);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProveedor,NombreProveedor,ApellidoProveedor,NitProveedor,NumeroProveedor,DirProveedor,CorreoProveedor")] ProveedorModel proveedorModel)
        {
            if (ModelState.IsValid)
            {
                db.Proveedor.Add(proveedorModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedorModel);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorModel proveedorModel = db.Proveedor.Find(id);
            if (proveedorModel == null)
            {
                return HttpNotFound();
            }
            return View(proveedorModel);
        }

        // POST: Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProveedor,NombreProveedor,ApellidoProveedor,NitProveedor,NumeroProveedor,DirProveedor,CorreoProveedor")] ProveedorModel proveedorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedorModel);
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorModel proveedorModel = db.Proveedor.Find(id);
            if (proveedorModel == null)
            {
                return HttpNotFound();
            }
            return View(proveedorModel);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProveedorModel proveedorModel = db.Proveedor.Find(id);
            db.Proveedor.Remove(proveedorModel);
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
