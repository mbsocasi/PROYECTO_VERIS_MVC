using PROYECTO_VERIS_MVC.Controllers;
using PROYECTO_VERIS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROYECTO_VERIS_MVC.Filtros
{
    public class Filtro : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var objUser = (ApplicationUser)HttpContext.Current.Session["User"];
            if (objUser == null)
            {
                if (filterContext.Controller is AccountController == false)
                {
                    filterContext.HttpContext.Response.RedirectToRoute("Default", new { controller = "Account", action = "Login" });
                    filterContext.HttpContext.Response.RedirectToRoute("Default", new { controller = "Account", action = "Register" });
                    filterContext.HttpContext.Response.RedirectToRoute("Default", new { controller = "Account", action = "Mostrar" });


                    filterContext.HttpContext.Response.RedirectToRoute("Default", new { controller = "Account", action = "Inicio" });
                    
                   

                }
            }
            else
            {
                if (filterContext.Controller is AccountController == true)
                {
                    filterContext.HttpContext.Response.RedirectToRoutePermanent("Default", new { controller = "Home", action = "Index" });
                }
            }
            base.OnActionExecuting(filterContext);

        }
    }
}