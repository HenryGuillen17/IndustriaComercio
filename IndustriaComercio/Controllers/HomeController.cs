using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Model;
using IndustriaComercio.Models.Servicios;
using IndustriaComercio.Models.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public HomeController()
        {
            var model = new ModelServidor();
            _usuarioService = new UsuarioService(model);
        }

        public ActionResult Index()
        {


            if (SessionHelper.GetPersonaSession() == null)
                return RedirectToAction("Login");

            // If we got this far, something failed, redisplay form  
            return View();
        }

        public ActionResult Login(UsuarioModel model)
        {
            try
            {
                if (model.Login == null && model.Contraseña == null)
                {
                    return View();
                }

                // Initialization.  
                var loginInfo = _usuarioService.Login(model.Login, model.Contraseña);
                if (loginInfo == null)
                {
                    // Setting.  
                    TempData["warning"] = "Login Fallido";
                    return View(model);
                }

                // setting.
                Session["user_id"] = loginInfo.PersonaId;
                Session["user_name"] = loginInfo.NombreCompleto;
                Session["perfil_id"] = loginInfo.PerfilId;

                Session["menu"] = loginInfo.UsuarioMenus;

                TempData["success"] = "Login OK";

                SessionHelper.SetPersonaSession(loginInfo);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
                TempData["error"] = ex.Message;
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            SessionHelper.Logout();
            // Info.  
            return RedirectToAction("Login");
        }
    }
}