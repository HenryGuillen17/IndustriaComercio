using IndustriaComercio.Common;
using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndustriaComercio.Models.Model
{
    public class DeclaracionPreviaModel
    {
        #region Constructor

        public DeclaracionPreviaModel()
        {

        }
        #endregion

        #region Propiedades


        // --------------------------------------------------------------------

        #region Vista Encabezado #1


        [Required(ErrorMessage = "Año Gravableo es Requerido")]
        [Display(Name = "Año Gravable", Description = "Lorem ipsum")]
        public int Año { get; set; }


        [Required(ErrorMessage = "Clase de declaración es requerido")]
        [Display(Name = "Elija la clase de declaración", Description = "Lorem ipsum")]
        public TipoDeclaracion TipoDeclaracion { get; set; }


        [Required(ErrorMessage = "Tipo de Documento es Requerido")]
        [Display(Name = "Tipo de Contribuyente", Description = "Lorem ipsum")]
        public int TipoContribuyenteId { get; set; }


        [Display(Name = "¿Tiene Pago Voluntario?", Description = "Lorem ipsum")]
        public bool TienePagoVoluntario { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Datos Personales Sección "A" #2


        [Required(ErrorMessage = "Nombre es Requerido")]
        [Display(
            Name = "Nombres y Apellidos o Razon social",
            Description = "Lorem ipsum"
        )]
        public string NombreCompleto { get; set; }


        [Required(ErrorMessage = "Tipo de Documento es Requerido")]
        [Display(
            Name = "Tipo de Documento",
            Description = "Lorem ipsum"
        )]
        public int TipoDocumentoId { get; set; }


        [Required(ErrorMessage = "Identificacion es Requerido")]
        [Display(
            Name = "Identificacion",
            Description = "Lorem ipsum"
        )]
        public string NoIdentificacion { get; set; }


        [Required(ErrorMessage = "DigitoChequeo es Requerido")]
        [Display(
            Name = "DigitoChequeo",
            Description = "Lorem ipsum"
        )]
        public string DigitoChequeo { get; set; }


        [Required(ErrorMessage = "Direccion es Requerido")]
        [Display(
            Name = "Direccion",
            Description = "Lorem ipsum"
        )]
        public string Direccion { get; set; }


        [Required(ErrorMessage = "Municipio de notificacion es Requerido")]
        [Display(
            Name = "Municipio Notificacion",
            Description = "Lorem ipsum"
        )]
        public string MunicipioNotificacion { get; set; }


        [Required(ErrorMessage = "Departamento de notificacion es Requerido")]
        [Display(
            Name = "Departamento Notificacion",
            Description = "Lorem ipsum"
        )]
        public string DepartamentoNotificacion { get; set; }


        [Required(ErrorMessage = "Teléfono es Requerido")]
        [Display(
            Name = "Telefono",
            Description = "Este es un teléfono casero"
        )]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Correo es Requerido")]
        [Display(
            Name = "Correo",
            Description = "Lorem ipsum"
        )]
        public string Correo { get; set; }


        [Required(ErrorMessage = "Numero Establecimientos es Requerido")]
        [Display(
            Name = "Numero Establecimientos",
            Description = "Lorem ipsum"
        )]
        [Range(1, 999)]
        public int NumeroEstablecimientos { get; set; }


        [Required(ErrorMessage = "Clasificacion Contribuyente es Requerido")]
        [Display(
            Name = "Clasificacion Contribuyente",
            Description = "Lorem ipsum"
        )]
        [Range(1, 999, ErrorMessage = "Debe elegir Tipo Clasificación")]
        public int? ClasificacionContribuyenteId { get; set; } = 0;


        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #3


        [Required]
        [Display(
            Name = "Ingresos Del Periodo En Todo El Pais",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int IngresosEnElPais { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Fuera Del Municipio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int IngresosFueraDelMunicipio { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Ingresos Del Municipio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int TotalIngresosMunicipio => IngresosEnElPais - IngresosFueraDelMunicipio;


        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #4


        [Required]
        [Display(
            Name = "Ingresos Por Devoluciones, Rebajas, Descuentos",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int IngresosDevoluciones { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Por Exportaciones",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int IngresosExportaciones { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Por Activos Fijos",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int IngresosActivosFijos { get; set; }


        [Required]
        [Display(
            Name = "Ingresos No Gravados",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int IngresosNoGravados { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Actividades Exentas",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int IngresosActividadesExentas { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Ingresos Gravables",
            Description = "Lorem ipsum"
        )]
        public int TotalIngresosGravables => (
            TotalIngresosMunicipio
            - IngresosDevoluciones
            - IngresosExportaciones
            - IngresosActivosFijos
            - IngresosNoGravados
            - IngresosActividadesExentas
            );


        #endregion

        // --------------------------------------------------------------------

        #region Vista Actividades Gravadas Sección "C" #5

        private ICollection<ActividadGravadaModel> actividadesGravadas;

        public ICollection<ActividadGravadaModel> ActividadesGravadas
        {
            get { return actividadesGravadas ?? new List<ActividadGravadaModel>(); }
            set { actividadesGravadas = value; }
        }



        /// <summary>
        /// Se obtiene de la sumatoria de tarifas de Actividades Gravadas
        /// </summary>
        [NotMapped]
        public int TotalTarifa => ActividadesGravadas?.Sum(x => x.Impuesto) ?? 0;


        #endregion

        // --------------------------------------------------------------------

        #region Vista Actividades Gravadas Impuesto Generación Energía Sección "C" #6


        [Required]
        [Display(
            Name = "Capacidad de Energía Instalada (En KiloVatios)",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int CapacidadInstalada { get; set; }


        /// <summary>
        /// Se obtiene de la multiplicación de CapacidadInstalada * ValorPorKiloVatio
        /// NO LO SÉ
        /// </summary>
        [NotMapped]
        [Display(
            Name = "Total Impuesto de Energía",
            Description = "Lorem ipsum"
        )]
        public int TotaImpuestoEnergiaElectrica => CapacidadInstalada * 5; // No es 5$, hay que preguntar eso


        #endregion

        // --------------------------------------------------------------------

        #region Vista Liquidación Privada Sección "D" #7


        [NotMapped]
        [Display(
            Name = "Total Impuesto Industria Comercio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int TotalImpuestoIndustriaComercio => TotalTarifa + TotaImpuestoEnergiaElectrica;


        /// <summary>
        /// A TotalImpuestoIndustriaComercio se le saca el 15% y se redondea por múltiplo de 1000
        /// </summary>
        [NotMapped]
        [Display(
            Name = "Total Impuesto Avisos Tableros",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int ImpuestoAvisosTableros => (int)(Math.Round(TotalImpuestoIndustriaComercio * 0.00015) * 1000);


        [Required]
        [Display(
            Name = "Pago Unidades Comerciales",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int PagoUnidadesComerciales { get; set; }


        [Required]
        [Display(
            Name = "Sobretasa Bomberil",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int SobretasaBomberil { get; set; }


        [Required]
        [Display(
            Name = "Sobretasa Seguridad",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int SobretasaSeguridad { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Impuesto Cargo",
            Description = "Lorem ipsum"
        )]
        public int TotalImpuestoCargo => (
            TotalImpuestoIndustriaComercio
            + ImpuestoAvisosTableros
            + PagoUnidadesComerciales
            + SobretasaBomberil
            + SobretasaSeguridad
            );


        #endregion

        // --------------------------------------------------------------------

        #region Vista Liquidación Privada Total Sección "D" #8


        [Required]
        [Display(
            Name = "Valor Exoneración Sobre Impuesto",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int ValorExoneracionImpuesto { get; set; }


        [Required]
        [Display(
            Name = "Retención Practicada Por El Municipio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int RetencionesDelMunicipio { get; set; }


        [Required]
        [Display(
            Name = "Autoretención Practicada Por El Municipio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int AutoretencionesDelMunicipio { get; set; }


        [Required]
        [Display(
            Name = "Anticipo Año Anterior",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int AnticipoAnioAnterior { get; set; }


        [Required]
        [Display(
            Name = "Anticipo Año Siguiente",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int AnticipoAnioSiguiente { get; set; }


        [Required]
        [Display(
            Name = "Tipo de Sanción",
            Description = "Lorem ipsum"
        )]
        public TipoSancion TipoSancion { get; set; }


        [NotMapped]
        [Display(
            Name = "Otro Tipo de Sanción",
            Description = "Lorem ipsum"
        )]
        public string OtroTipoSancion { get; set; }


        [Display(
            Name = "Valor de la Sanción",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int ValorSancion { get; set; }


        [Display(
            Name = "Saldo a favor Período Anterior",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int SaldoFavorPeriodoAnterior { get; set; }


        [Display(
            Name = "Total Saldo a Cargo",
            Description = "Lorem ipsum"
        )]
        public int TotalSaldoCargo => (
            TotalImpuestoCargo
            - ValorExoneracionImpuesto
            - RetencionesDelMunicipio
            - AutoretencionesDelMunicipio
            - AnticipoAnioAnterior
            + AnticipoAnioSiguiente
            + ValorSancion
            - SaldoFavorPeriodoAnterior
            );


        [Display(
            Name = "Total Saldo a Favor",
            Description = "Lorem ipsum"
        )]
        public int TotalSaldoFavor => TotalSaldoCargo < 0 ? Math.Abs(TotalSaldoFavor) : 0;


        #endregion

        // --------------------------------------------------------------------

        #region Vista De Pago Sección "E" #9


        [Required]
        [Display(
            Name = "Valor A Pagar",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int ValorPagar => TotalSaldoCargo;


        [Required]
        [Display(
            Name = "Descuento Por Pronto Pago",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int DescuentoProntoPago { get; set; }


        [Required]
        [Display(
            Name = "Intereses de Mora",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public int InteresesDeMora { get; set; }


        [NotMapped]
        [Display(
            Name = "Total a Pagar",
            Description = "Lorem ipsum"
        )]
        public int TotalPagar => (ValorPagar + InteresesDeMora - DescuentoProntoPago);


        #endregion

        // --------------------------------------------------------------------


        public List<SelectListItem> TipoDocumentos { get; set; }
        public List<SelectListItem> TipoContribuyentes { get; set; }
        public List<SelectListItem> Años
        {
            get
            {
                var años = new List<SelectListItem>();
                for (var i = 1; i <= 10; i++)
                {
                    var val = new SelectListItem
                    {
                        Text = (DateTime.Now.Year - i).ToString(),
                        Value = (DateTime.Now.Year - i).ToString()
                    };
                    años.Add(val);
                }
                return años;
            }
        }
        public ICollection<ComboBox> ListaActividadesGravadas { get; set; }
        public ICollection<ComboBox> ListaClasificacionesContribuyentes { get; set; }


        #endregion
    }


    public class ActividadGravadaModel
    {
        private int tarifa;

        public int ActividadId { get; set; }

        [NotMapped]
        public string Descripcion { get; set; }

        [Required]
        [Display(
            Name = "Ingresos Gravados",
            Description = "Lorem ipsum"
        )]
        public int IngresosGravados { get; set; }

        [Required]
        [Display(
            Name = "Ingresos Gravados",
            Description = "Lorem ipsum"
        )]
        public int Tarifa
        {
            get { return (int)(Math.Round(tarifa * 0.001) * 1000); }
            set { tarifa = value; }
        }

        [Required]
        [Display(
            Name = "Impuestos Industria Comercio",
            Description = "Lorem ipsum"
        )]
        public int Impuesto { get; set; }


    }
}