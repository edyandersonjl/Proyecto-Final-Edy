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
    public class AdministradorController : Controller
    {
        private SQLDbContext db = new SQLDbContext();

        // GET: Administrador
        public ActionResult Index()
        {
            return View(db.Admin.ToList());
        }

        public ActionResult RegistrarAdmi()
        {
            return View();
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorModel administradorModel = db.Admin.Find(id);
            if (administradorModel == null)
            {
                return HttpNotFound();
            }
            return View(administradorModel);
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdmin,NombreAdmin,ApellidoAdmin,NumeroAdmin,CargoAdmin,TituloAdmin,CorreoAdmin,PassAdmin")] AdministradorModel administradorModel)
        {
            if (ModelState.IsValid)
            {
                administradorModel.tipopersona = true;
                db.Admin.Add(administradorModel);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(administradorModel);
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorModel administradorModel = db.Admin.Find(id);
            if (administradorModel == null)
            {
                return HttpNotFound();
            }
            return View(administradorModel);
        }

        // POST: Administrador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdmin,NombreAdmin,ApellidoAdmin,NumeroAdmin,CargoAdmin,TituloAdmin,CorreoAdmin,PassAdmin")] AdministradorModel administradorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administradorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administradorModel);
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorModel administradorModel = db.Admin.Find(id);
            if (administradorModel == null)
            {
                return HttpNotFound();
            }
            return View(administradorModel);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministradorModel administradorModel = db.Admin.Find(id);
            db.Admin.Remove(administradorModel);
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
