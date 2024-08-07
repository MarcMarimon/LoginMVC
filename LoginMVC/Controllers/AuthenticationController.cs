using LoginMVC.DAL;
using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private DALLogin dal = new DALLogin();

        // GET: Authentication
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // POST: Authentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel vm)
        {

            if (ModelState.IsValid)
            {
                if (dal.IsValidUser(vm.Email, vm.Password))
                {
                    return RedirectToAction("Index", "Home");
                   
                }
                else
                {
                    ViewBag.ErrorMessage = "Nombre o contraseña incorrectos.";
                }
            }
            
            return View(vm);
        }
    }
}
