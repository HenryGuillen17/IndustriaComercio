using IndustriaComercio.Common.Utils;
using IndustriaComercio.Models.Context;
using IndustriaComercio.Models.Enum;
using IndustriaComercio.Models.Model;
using IndustriaComercio.Models.Servicios;
using System;
using System.Web.Mvc;

namespace IndustriaComercio.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;


        public UsuarioController()
        {
            var db = new ModelServidor();
            _usuarioService = new UsuarioService(db);
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Edit(int id = 0)
        {
            return View(new UsuarioModel { PersonaId = id });
        }


        // GET: Usuario
        [Route("~/Usuario/GetUsuarioByNoDocumento/{tipoDocumento:int}/{noDocumento}")]
        public JsonResult GetUsuarioByNoDocumento(
            int tipoDocumento,
            string noDocumento
            )
        {
            try
            {
                var model = _usuarioService.FindUsuarioByNoDocumento(tipoDocumento, noDocumento);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Obtiene el Usuario y la persona relacionado con este Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/Usuario/FindById/{id:int}")]
        public JsonResult GetById(int id)
        {
            return Json(_usuarioService.FindUsuarioByPersonaId(id), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obtiene usuario por login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/Usuario/FindByLogin/{login}")]
        public JsonResult GetByLogin(string login)
        {
            return Json(_usuarioService.FindByLogin(login), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de Usuarios paginados según ciertos parámetros
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetListUsuarioPaginado(
            string sort, int page, int perPage, string filter
            )
        {
            var apiFilter = new ApiFilter<UsuarioModel>(sort, page, perPage, filter);

            return Json(_usuarioService.GetListUsuarioPaginado(apiFilter), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Trae lista de Usuarios por número de parámetro
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="value"></param>
        /// <param name="tipoBusqueda"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetListUsuarioAutocomplete(
            int limit, string value, TipoBusqueda tipoBusqueda
            )
        {
            return Json(
                _usuarioService.GetListUsuarioAutocomplete(limit, value, tipoBusqueda), 
                JsonRequestBehavior.AllowGet
                );
        }


        [HttpGet]
        public JsonResult GetListPersonaSinUsuarioAutocomplete(
            int limit, string value, TipoBusqueda tipoBusqueda
            )
        {
            return Json(
                _usuarioService.GetListPersonaSinUsuarioAutocomplete(limit, value, tipoBusqueda), 
                JsonRequestBehavior.AllowGet
                );
        }

        /// <summary>
        /// Actualiza o crea un Usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/Usuario/Save")]
        public JsonResult Save(UsuarioModel model)
        {
            return Json(_usuarioService.Save(model));
        }

    }
}