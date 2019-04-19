using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using IndustriaComercio.Models.Enum;
using IndustriaComercio.Models.Model;
using Microsoft.Ajax.Utilities;

namespace IndustriaComercio.Models.Tools
{
    public static class SessionHelper
    {
        public static int GetUser()
        {
            return (int)HttpContext.Current.Session["user_id"]; ;
        }
        public static byte GetPerfil()
        {
            var perfil = HttpContext.Current.Session["perfil_id"];
            if (perfil == null)
                return 0;
            
            return (byte)perfil;
        }

        //public static bool TienePermiso(byte menu, byte menuSubMenu, byte permiso)
        //{
        //    return UnitOfWork.PerfilPermisoRepository.TienePermiso(GetPerfil(), menu, menuSubMenu, permiso);
        //}

        public static UsuarioModel GetPersonaSession()
        {
            return (UsuarioModel)HttpContext.Current.Session["PersonaSession"];
        }

        public static void Logout()
        {
            HttpContext.Current.Session["PersonaSession"] = null;
        }

        public static void SetPersonaSession(UsuarioModel usuarioPoco)
        {
            HttpContext.Current.Session["PersonaSession"] = usuarioPoco;
        }

        public static bool GetPermiso(Menu menuId, MenuSubMenu submenuId, Permiso permisoId)
        {
            var session = GetPersonaSession();

            var menu = session.UsuarioMenus.FirstOrDefault(x => x.MenuId == (byte)menuId);
            var submenu = menu?.UsuarioSubMenus.FirstOrDefault(x => x.SubMenuId == (byte)submenuId);
            var permiso = submenu?.UsuarioPermisos.FirstOrDefault(x => x.PermisoId == (byte)permisoId);

            return permiso != null && permiso.Permiso;
        }
    }
}