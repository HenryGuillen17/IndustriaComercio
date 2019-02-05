﻿
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Entidades.UsuarioPermisos;
using Newtonsoft.Json;

namespace IndustriaComercio.Entidades.Persona
{
   public class Persona
    {
     
       public int PersonaId{get; set;}
        [Required]
        [Display(Name = "Tipo Documento *")]
        public int TipoDocumentoId { get; set; }
        [Required]
        [Display(Name = "Numero Identificacion *")]
        public string NoIdentificacion { get; set; }
        [Display(Name = "DigitoChequeo",Description = "Dígito de Chequeo")]
        public string DigitoChequeo { get; set; }
        [Required]
        [Display(Name = "Primer Nombre *")]
        public string PrimerNombre { get; set; }
       
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }
        [Required]
        [Display(Name = "Primer Apellido *")]
        public string PrimerApellido { get; set; }
        
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [Display(Name = "Foto")]
        public string FotoPerfil { get; set; }
   
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
  
        [Display(Name = "Telefono Celular")]
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }
     
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        
        [Display(
            Name = "Municipio Notificacion",
            Description = "Lorem ipsum"
        )]
        public string Municipio { get; set; }
        
        [Display(
            Name = "Departamento Notificacion",
            Description = "Lorem ipsum"
        )]
        public string Departamento { get; set; }

        [Display(
            Name = "Clasificacion Contribuyente",
            Description = "Lorem ipsum"
        )]
        [Range(1, 999, ErrorMessage = "Debe elegir Tipo Clasificación")]
        public int ClasificacionContribuyenteId { get; set; }

        public bool IsCliente { get; set; }
 
        public bool IsUsuario { get; set; }


        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}