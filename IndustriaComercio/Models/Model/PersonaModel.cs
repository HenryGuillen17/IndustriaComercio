﻿using IndustriaComercio.Models.Entidades.Basicos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IndustriaComercio.Models.Model
{
    public class PersonaModel
    {
     
        public int PersonaId {get; set; }
        [Required]
        [Display(Name = "Tipo Documento *")]
        public int TipoDocumentoId { get; set; }
        [Required]
        [Display(Name = "Tipo Documento Nombre")]
        public string TipoDocumentoNombre { get; set; }
        [Required]
        [Display(Name = "Numero Identificacion *")]
        public string NoIdentificacion { get; set; }
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
        public string Telefono { get; set; }
        

        public ClasificacionContribuyente ClasificacionContribuyente { get; set; }
        public int ClasificacionContribuyenteId { get; set; }
        public string ClasificacionContribuyenteNombre { get; set; }
    }
}