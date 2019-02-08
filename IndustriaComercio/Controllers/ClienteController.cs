using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Model;
using IndustriaComercio.Models.Servicios;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{

    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;


        public ClienteController()
        {
            var db = new ModelServidor();
            _clienteService = new ClienteService(db);
        }
        

        // GET: Cliente
        [Route("~/Cliente/GetClienteByNoDocumento/{tipoDocumento:int}/{noDocumento}")]
        public JsonResult GetClienteByNoDocumento(
            int tipoDocumento,
            string noDocumento
            )
        {
            try
            {
                var model = _clienteService.FindClienteByNoDocumento(tipoDocumento, noDocumento);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.AllowGet);
            }
        }



    }
}