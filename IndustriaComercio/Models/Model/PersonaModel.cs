using IndustriaComercio.Common.Tools;
using IndustriaComercio.Entidades.Persona;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public string NoIdentificacionCompleto => $"{TipoDocumentoNombre} {NoIdentificacion}";
        [NotMapped]
        public string DigitoChequeo => Tool.CalcularDigito(NoIdentificacion.Split('-')[0]);

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

        public int MunicipioId { get; set; }
        [Display(
            Name = "Municipio Notificacion",
            Description = "Lorem ipsum"
        )]
        public string Municipio { get; set; }

        public int DepartamentoId { get; set; }

        [Display(
            Name = "Departamento Notificacion",
            Description = "Lorem ipsum"
        )]
        public string Departamento { get; set; }

        public string Telefono { get; set; }




        public string GetNombreCompeto()
        {
            var list = new List<string>();

            list.Add(PrimerNombre);
            if (!string.IsNullOrWhiteSpace(SegundoNombre)) list.Add(SegundoNombre);
            list.Add(PrimerApellido);
            if (!string.IsNullOrWhiteSpace(SegundoApellido)) list.Add(SegundoApellido);

            return string.Join(" ", list);
        }





        public Persona PersonaFactory()
        {
            return new Persona
            {
                PersonaId = PersonaId,
                TipoDocumentoId = TipoDocumentoId,
                NoIdentificacion = NoIdentificacion,
                DigitoChequeo = DigitoChequeo,
                PrimerNombre = PrimerNombre,
                SegundoNombre = SegundoNombre,
                PrimerApellido = PrimerApellido,
                SegundoApellido = SegundoApellido,
                NombreCompleto = GetNombreCompeto(),
                FotoPerfil = FotoPerfil,
                Correo = Correo,
                Celular = Celular,
                Direccion = Direccion,
                MunicipioId = MunicipioId,
                Telefono = Telefono,
                IsCliente = false,
                IsUsuario = false
            };
        }

    }
}