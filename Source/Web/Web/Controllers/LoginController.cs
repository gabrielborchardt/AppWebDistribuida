using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Service;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        public ActionResult Index(string email, string senha)
        {
            if(!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(senha))
            {
                var apiResult = _service.Login(email, senha);

                switch (apiResult.StatusCode)
                {
                    case HttpStatusCode.OK:
                        Session["Token"] = apiResult.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Index", "Home");
                    default:
                        ViewBag.Message = apiResult.Content.ReadAsStringAsync().Result;
                        break;
                }

            }

            return View();
        }
    }
}
