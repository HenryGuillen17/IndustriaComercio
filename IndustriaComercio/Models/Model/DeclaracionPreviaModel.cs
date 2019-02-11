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


        [Required(ErrorMessage = "Año Gravable es Requerido")]
        [Display(Name = "Año Gravable", Description = "Lorem ipsum")]
        public int Año { get; set; }


        [Required(ErrorMessage = "Clase de declaración es requerido")]
        [Display(Name = "Elija la clase de declaración", Description = "Lorem ipsum")]
        public TipoDeclaracion TipoDeclaracion { get; set; } = TipoDeclaracion.DeclaracionInicial;
        

        [Required(ErrorMessage = "Tipo de Documento es Requerido")]
        [Display(Name = "Tipo de Contribuyente", Description = "Lorem ipsum")]
        public int TipoContribuyenteId { get; set; }


        [Display(Name = "¿Tiene Pago Voluntario?", Description = "Lorem ipsum")]
        public bool TienePagoVoluntario { get; set; }


        [Display(Name = "¿Paga Avisos y Tableros?", Description = "Lorem ipsum")]
        public bool PagaAvisoTablero { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Datos Personales Sección "A" #2


        [Required]
        [Display(Name = "Tipo Identificacion")]
        public int TipoDocumentoId { get; set; }


        [Required]
        [Display(Name = "Numero Identificacion")]
        public string NoIdentificacion { get; set; }


        [Required]
        public int PersonaId { get; set; }


        [NotMapped]
        public ClienteModel Cliente { get; set; }



        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #3


        [Required]
        [Display(
            Name = "Ingresos Del Periodo En Todo El Pais",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double IngresosEnElPais { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Fuera Del Municipio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double IngresosFueraDelMunicipio { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Ingresos Del Municipio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double TotalIngresosMunicipio => IngresosEnElPais - IngresosFueraDelMunicipio;


        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #4


        [Required]
        [Display(
            Name = "Ingresos Por Devoluciones, Rebajas, Descuentos",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double IngresosDevoluciones { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Por Exportaciones",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double IngresosExportaciones { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Por Activos Fijos",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double IngresosActivosFijos { get; set; }


        [Required]
        [Display(
            Name = "Ingresos No Gravados",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double IngresosNoGravados { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Actividades Exentas",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double IngresosActividadesExentas { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Ingresos Gravables",
            Description = "Lorem ipsum"
        )]
        public double TotalIngresosGravables => (
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
        public double TotalTarifa => ActividadesGravadas?.Sum(x => x.Impuesto) ?? 0;


        #endregion

        // --------------------------------------------------------------------

        #region Vista Actividades Gravadas Impuesto Generación Energía Sección "C" #6


        [Required]
        [Display(
            Name = "Capacidad de Energía Instalada (En KiloVatios)",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double CapacidadInstalada { get; set; }


        /// <summary>
        /// Se obtiene de la multiplicación de CapacidadInstalada * ValorPorKiloVatio
        /// NO LO SÉ
        /// </summary>
        [NotMapped]
        [Display(
            Name = "Total Impuesto de Energía",
            Description = "Lorem ipsum"
        )]
        public double TotaImpuestoEnergiaElectrica => CapacidadInstalada * 5; // No es 5$, hay que preguntar eso


        #endregion

        // --------------------------------------------------------------------

        #region Vista Liquidación Privada Sección "D" #7


        [NotMapped]
        [Display(
            Name = "Total Impuesto Industria Comercio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double TotalImpuestoIndustriaComercio => TotalTarifa + TotaImpuestoEnergiaElectrica;


        /// <summary>
        /// A TotalImpuestoIndustriaComercio se le saca el 15% y se redondea por múltiplo de 1000
        /// </summary>
        [NotMapped]
        [Display(
            Name = "Total Impuesto Avisos Tableros",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double ImpuestoAvisosTableros => (int)(Math.Round(TotalImpuestoIndustriaComercio * 0.00015) * 1000);


        [Required]
        [Display(
            Name = "Pago Unidades Comerciales",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double PagoUnidadesComerciales { get; set; }


        [Required]
        [Display(
            Name = "Sobretasa Bomberil",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double SobretasaBomberil { get; set; }


        [Required]
        [Display(
            Name = "Sobretasa Seguridad",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double SobretasaSeguridad { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Impuesto Cargo",
            Description = "Lorem ipsum"
        )]
        public double TotalImpuestoCargo => (
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
        public double ValorExoneracionImpuesto { get; set; }


        [Required]
        [Display(
            Name = "Retención Practicada Por El Municipio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double RetencionesDelMunicipio { get; set; }

        
        [Display(
            Name = "Archivo Retención Practicada Por El Municipio",
            Description = "Lorem ipsum"
        )]
        public HttpPostedFileBase ArchivoRetencion { get; set; }

        [NotMapped]
        public string RutaArchivoRetencion { get; set; }


        [Required]
        [Display(
            Name = "Autoretención Practicada Por El Municipio",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double AutoretencionesDelMunicipio { get; set; }


        [Required]
        [Display(
            Name = "Anticipo Año Anterior",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double AnticipoAnioAnterior { get; set; }


        [Required]
        [Display(
            Name = "Anticipo Año Siguiente",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double AnticipoAnioSiguiente { get; set; }

        
        [Display(
            Name = "Tipo de Sanción",
            Description = "Lorem ipsum"
        )]
        public int? TipoSancion { get; set; }


        [Display(
            Name = "Valor de la Sanción",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double ValorSancion { get; set; }


        [Display(
            Name = "Saldo a favor Período Anterior",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double SaldoFavorPeriodoAnterior { get; set; }


        [Display(
            Name = "Total Saldo a Cargo",
            Description = "Lorem ipsum"
        )]
        public double TotalSaldoCargo => (
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
        public double TotalSaldoFavor => TotalSaldoCargo < 0 ? Math.Abs(TotalSaldoFavor) : 0;


        #endregion

        // --------------------------------------------------------------------

        #region Vista De Pago Sección "E" #9


        [Required]
        [Display(
            Name = "Valor A Pagar",
            Description = "Lorem ipsum"
        )]
        [Range(0, int.MaxValue)]
        public double ValorPagar => TotalSaldoCargo;


        public double PorcentajeDescuento { get; set; }


        [Required]
        [Display(
            Name = "Descuento Por Pronto Pago",
            Description = "Lorem ipsum"
        )]
        public double Descuento => ValorPagar - (ValorPagar * (PorcentajeDescuento * 0.01));


        public double PorcentajeInteres { get; set; }
        [Required]
        [Display(
            Name = "Intereses de Mora",
            Description = "Lorem ipsum"
        )]
        public double Interes => ValorPagar + (ValorPagar * (PorcentajeInteres * 0.01));



        [NotMapped]
        [Display(
            Name = "Total a Pagar",
            Description = "Lorem ipsum"
        )]
        public double TotalPagar => (ValorPagar + Interes - Descuento);


        #endregion

        // --------------------------------------------------------------------


        public ICollection<ComboBox> TipoDocumentos { get; set; }
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
        public ICollection<ActividadGravadaModel> ListaActividadesGravadas { get; set; }
        public ICollection<ComboBox> ListaClasificacionesContribuyentes { get; set; }
        public ICollection<TipoSancionModel> ListaTipoSanciones { get; internal set; }


        #endregion
    }


    public class ActividadGravadaModel
    {

        public int ActividadId { get; set; }

        [NotMapped]
        public string Descripcion { get; set; }


        [Display(
            Name = "Ingresos Gravados",
            Description = "Lorem ipsum"
        )]
        public double IngresosGravados { get; set; }


        [Display(
            Name = "Ingresos Gravados",
            Description = "Lorem ipsum"
        )]
        public double Tarifa { get; set; }


        [Display(
            Name = "Impuestos Industria Comercio",
            Description = "Lorem ipsum"
        )]
        public double Impuesto => (IngresosGravados * Tarifa) / 1000;


    }
}