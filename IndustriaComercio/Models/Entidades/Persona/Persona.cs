
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Entidades.UsuarioPermisos;
using IndustriaComercio.Models.Entidades.Basicos;
using Newtonsoft.Json;

namespace IndustriaComercio.Entidades.Persona
{
   public class Persona
    {
     
       public int PersonaId {get; set;}

        public int TipoDocumentoId { get; set; }

        public string NoIdentificacion { get; set; }

        public string DigitoChequeo { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto { get; set; }

        public string FotoPerfil { get; set; }

        public string Correo { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Municipio { get; set; }
        
        public string Departamento { get; set; }

        public string Telefono { get; set; }

        public bool IsCliente { get; set; }
 
        public bool IsUsuario { get; set; }
        

        //_____________Propiedades
        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
       
        
    }
}