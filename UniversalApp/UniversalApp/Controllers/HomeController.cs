using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UniversalApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.Cookies["UserNameEDRMVC"] == null)
            {
                //Response.Cookies.Add(CreateStudentCookie("pepito"));
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "naughty");
            }
           

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

        private HttpCookie CreateStudentCookie(string Userx)
        {
            HttpCookie LoginCookie = new HttpCookie("UserNameEDRMVC");
            LoginCookie.Value = Userx;
            LoginCookie.Expires = DateTime.Now.AddMinutes(999);
            return LoginCookie;
        }
    }
}