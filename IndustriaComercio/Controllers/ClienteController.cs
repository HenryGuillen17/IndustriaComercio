using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Enum;
using IndustriaComercio.Models.Model;
using IndustriaComercio.Models.Servicios;
using System;
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


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Edit(int id = 0)
        {
            return View(new ClienteModel { PersonaId = id });
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

        /// <summary>
        /// Obtiene el cliente y la persona relacionado con este Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/Cliente/FindById/{id:int}")]
        public JsonResult GetById(int id)
        {
            return Json(_clienteService.FindClienteByPersonaId(id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de clientes paginados según ciertos parámetros
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetListClientePaginado(
            string sort, int page, int perPage, string filter
            )
        {
            var apiFilter = new ApiFilter<ClienteModel>(sort, page, perPage, filter);

            return Json(_clienteService.GetListClientePaginado(apiFilter), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Trae lista de clientes por número de parámetro
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="value"></param>
        /// <param name="tipoBusqueda"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetListClienteAutocomplete(
            int limit, string value, TipoBusqueda tipoBusqueda
            )
        {
            return Json(
                _clienteService.GetListClienteAutocomplete(limit, value, tipoBusqueda), 
                JsonRequestBehavior.AllowGet
                );
        }


        [HttpGet]
        public JsonResult GetListPersonaSinClienteAutocomplete(
            int limit, string value, TipoBusqueda tipoBusqueda
            )
        {
            return Json(
                _clienteService.GetListPersonaSinClienteAutocomplete(limit, value, tipoBusqueda), 
                JsonRequestBehavior.AllowGet
                );
        }

        /// <summary>
        /// Actualiza o crea un Cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/Cliente/Save")]
        public JsonResult Save(ClienteModel model)
        {
            return Json(_clienteService.Save(model));
        }

    }
}