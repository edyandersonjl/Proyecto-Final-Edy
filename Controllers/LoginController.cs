using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExamenFinal.Context;
using ExamenFinal.Models;


namespace ExamenFinal.Controllers
{
    public class LoginController : Controller
    {
        private SQLDbContext db = new SQLDbContext();
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult IndexEmpleado()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin([Bind(Include = "IdAdmin,NombreAdmin,ApellidoAdmin,NumeroAdmin,CargoAdmin,TituloAdmin,CorreoAdmin,PassAdmin")] AdministradorModel administradorModel)
        {
            if (administradorModel.CorreoAdmin == null && administradorModel.PassAdmin == null)
            {   
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Login = db.Admin
                .Where(w => w.CorreoAdmin == administradorModel.CorreoAdmin && w.PassAdmin == administradorModel.PassAdmin)
                .Select(s => new { s.tipopersona, s.IdAdmin })
                .FirstOrDefault();

            GetInformation.getId(Login.IdAdmin);
            if (Login.tipopersona.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            else if (Login.tipopersona.Equals(true))
                return RedirectToAction("IndexAdmin");
            else
                return RedirectToAction("IndexEmpleado");
        }

        public ActionResult LoginAdmin()
        {
            return View();
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
