using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PerfilUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PerfilUsuarios.Controllers
{
    public class PerfilUsuarioController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: PerfilUsuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: PerfilUsuario/Details/5
        public ActionResult Details()
        {
            if (User.Identity.IsAuthenticated) {

                var idUsuarioActual = User.Identity.GetUserId();

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var usuario = userManager.FindById(idUsuarioActual);
                ViewBag.Name = usuario.Name;
                ViewBag.LastName = usuario.LastName;
                ViewBag.BirthDate = usuario.BirthDate;
                ViewBag.Email = usuario.Email;

            }
            return View();
        }

        // GET: PerfilUsuario/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PerfilUsuario/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: PerfilUsuario/Edit/5
        public ActionResult Edit()
        {
            if (User.Identity.IsAuthenticated)
            {
                var idUsuarioActual = User.Identity.GetUserId();

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var usuario = userManager.FindById(idUsuarioActual);
                ViewBag.Name = usuario.Name;
                ViewBag.LastName = usuario.LastName;
                ViewBag.BirthDate = usuario.BirthDate;
                ViewBag.Email = usuario.Email;
            }


            return View();
        }

        // POST: PerfilUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(string Name, string LastName, string BirthDate, string Email)
        {
            if (User.Identity.IsAuthenticated)
            {
                var idUsuarioActual = User.Identity.GetUserId();

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var usuario = userManager.FindById(idUsuarioActual);

                usuario.Name = Name;
                usuario.LastName = LastName;
                usuario.BirthDate = BirthDate;
                usuario.Email = Email;

                db.SaveChanges();

            }


                return Redirect("Details");
        }

        // GET: PerfilUsuario/Delete/5
        public ActionResult Delete()
        {
            if (User.Identity.IsAuthenticated)
            {
                var idUsuarioActual = User.Identity.GetUserId();

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var usuario = userManager.FindById(idUsuarioActual);
                ViewBag.Name = usuario.Name;
                ViewBag.LastName = usuario.LastName;
                ViewBag.BirthDate = usuario.BirthDate;
                ViewBag.Email = usuario.Email;
            }

            return View();
        }

        // POST: PerfilUsuario/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed()
        {
            if (User.Identity.IsAuthenticated)
            {
                var idUsuarioActual = User.Identity.GetUserId();

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var usuario = userManager.FindById(idUsuarioActual);

                db.Users.Remove(usuario);
                db.SaveChanges();
            }
            return View();
            
        }
    }
}
