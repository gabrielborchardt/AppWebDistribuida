using Models.Parameter.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Service;

namespace Web.Controllers
{
    [AuthorizeWithSession]
    public class HomeController : Controller
    {
        private readonly IHomeService _service;

        public HomeController(IHomeService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FConsult(string cep, decimal tamanho = 0, decimal peso = 0)
        {
            FreightConsult model = null;

            if(!string.IsNullOrEmpty(cep) && tamanho > 0 && peso > 0)
            {
                model = _service.FreightConsult(cep, tamanho, peso, Session["Token"].ToString());
            }

            ViewBag.Message = "Consulta de Fretes";
            return View(model);
        }

        public ActionResult CConsult(string cpf)
        {
            CreditConsult model = null;

            if (!String.IsNullOrEmpty(cpf))
            {
                model = _service.CreditConsult(cpf, Session["Token"].ToString());
            }

            ViewBag.Message = "Consulta de Crédito";
            return View(model);
        }
    }
}