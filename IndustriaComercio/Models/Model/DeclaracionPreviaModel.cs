using IndustriaComercio.Common.Utils;
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
        [Display(Name = "Año Gravable", Description = "Escriba el año al cual corresponden los ingresos que está declarando. El período gravable del Impuesto de Industria y Comercio es el año calendario inmediatamente anterior a aquel en que se debe presentar la declaración")]
        public int Año { get; set; }


        [Required(ErrorMessage = "Clase de declaración es requerido")]
        [Display(Name = "Elija la clase de declaración", Description = "Si es la primera declaración de este período gravable, marque Declaración Inicial")]
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
            Description = "Registre la totalidad de ingresos ordinarios y extraordinarios obtenidos en todo el país, durante el período gravable, incluyendo los ingresos por rendimientos financieros, comisiones, obtenidos dentro y fuera del municipio"
        )]
        [Range(0, double.MaxValue)]
        public double IngresosEnElPais { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Fuera Del Municipio",
            Description = "Registre el total de ingresos obtenidos fuera del municipio. Para el efecto, tenga en cuenta las reglas de territorialidad aplicables a cada actividad; en general los ingresos se entienden percibidos en el municipio donde se realiza la respectiva actividad."
        )]
        [Range(0, double.MaxValue)]
        public double IngresosFueraDelMunicipio { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Ingresos Del Municipio",
            Description = "Es el resultado de restar el total de ingresos obtenidos fuera de este municipio al total de ingresos en todo el país"
        )]
        [Range(0, double.MaxValue)]
        public double TotalIngresosMunicipio => IngresosEnElPais - IngresosFueraDelMunicipio;


        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #4


        [Required]
        [Display(
            Name = "Ingresos Por Devoluciones, Rebajas, Descuentos",
            Description = "Escriba el valor de ingresos registrados en el municipio de concepto de devolucionens, rebajas, descuentos"
        )]
        [Range(0, double.MaxValue)]
        public double IngresosDevoluciones { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Por Exportaciones",
            Description = "Escriba el valor de ingresos registrados en este municipio por concepto de exportaciones"
        )]
        [Range(0, double.MaxValue)]
        public double IngresosExportaciones { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Por Activos Fijos",
            Description = "Escriba el valor de ingresos registrados en este municipio o distrito por concepto de venta de activos fijos"
        )]
        [Range(0, double.MaxValue)]
        public double IngresosActivosFijos { get; set; }


        [Required]
        [Display(
            Name = "Ingresos No Gravados",
            Description = "Escriba el valor de ingresos registradoos en este municipio o distrito por concepto de actividades excluidas o no sujetas y otros ingresos no gravados de conformidad con las normas que regulan el impuesto de Industria y Comercio"
        )]
        [Range(0, double.MaxValue)]
        public double IngresosNoGravados { get; set; }


        [Required]
        [Display(
            Name = "Ingresos Actividades Exentas",
            Description = "Escriba el valor de ingresos registrados en el municipio por concepto de actividades que gozan de tratamiento de exención, de conformidad con las normas propias del municipio"
        )]
        [Range(0, double.MaxValue)]
        public double IngresosActividadesExentas { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Ingresos Gravables",
            Description = "Es el resultado del Renglón 10 menos 11, 12, 13, 14 y 15"
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
            Description = "En el caso de la actividad de generación de energía eléctrica en cabeza de los propietarios de las obras para ese fin, escriba en kilovatios la capacidad instalada de la generadora en el municipio."
        )]
        [Range(0, double.MaxValue)]
        public double CapacidadInstalada { get; set; }


        /// <summary>
        /// Se obtiene de la multiplicación de CapacidadInstalada * ValorPorKiloVatio
        /// NO LO SÉ
        /// </summary>
        [NotMapped]
        [Display(
            Name = "Total Impuesto de Energía",
            Description = "Multiplique el total de capacidad instalada de la planta generadora, en kilovatios, por valor de impuesto que por cada kilovatio ordena la Ley 57 de 1981, actualizado"
        )]
        public double TotaImpuestoEnergiaElectrica => CapacidadInstalada * 5; // No es 5$, hay que preguntar eso


        #endregion

        // --------------------------------------------------------------------

        #region Vista Liquidación Privada Sección "D" #7


        [NotMapped]
        [Display(
            Name = "Total Impuesto Industria Comercio",
            Description = "Es el resultado de sumar el renglón 17 y el renglón 19"
        )]
        [Range(0, double.MaxValue)]
        public double TotalImpuestoIndustriaComercio => TotalTarifa + TotaImpuestoEnergiaElectrica;


        /// <summary>
        /// A TotalImpuestoIndustriaComercio se le saca el 15% y se redondea por múltiplo de 1000
        /// </summary>
        [NotMapped]
        [Display(
            Name = "Total Impuesto Avisos Tableros",
            Description = "Es el 15% del renglón 20"
        )]
        [Range(0, double.MaxValue)]
        public double ImpuestoAvisosTableros { get; set; }


        [Required]
        [Display(
            Name = "Pago Unidades Comerciales",
            Description = "Registre el valor resultante de multiplicar el nùmero de sucursales, agencias u oficinas adicionales abiertas al público, de Establecimientos de Crédito, Instituciones Financieras y Compañías de Seguro y Reaseguro, por el valor establecido como pago adicional en la norma de municipio, de conformidad con el Artículo 209 del Decreto Ley 1333 de 1986."
        )]
        [Range(0, double.MaxValue)]
        public double PagoUnidadesComerciales { get; set; }


        [Required]
        [Display(
            Name = "Sobretasa Bomberil",
            Description = "El municipio de Piedecuesta no tiene establecida la Sobretasa Bomberil para el impuesto de Industria y Comercio"
        )]
        [Range(0, double.MaxValue)]
        public double SobretasaBomberil { get; set; }


        [Required]
        [Display(
            Name = "Sobretasa Seguridad",
            Description = "El municipio de Piedecuesta no tiene establecida la Sobretasa de Seguridad para el Impuesto de Industria y Comercio"
        )]
        [Range(0, double.MaxValue)]
        public double SobretasaSeguridad { get; set; }


        [NotMapped]
        [Display(
            Name = "Total Impuesto Cargo",
            Description = "Es la suma de los renglones 20+21+22+23+24"
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
            Description = "Si tiene derecho a disminuir el valor del impuesto liquidado, por existir una exención o beneficio que así lo autorice, escriba aquí el valor exento o exonerado. Tenga en cuenta que este beneficio tributario es diferente al que se aplica sobre los ingresos por actividades exentas"
        )]
        [Range(0, double.MaxValue)]
        public double ValorExoneracionImpuesto { get; set; }


        [Required]
        [Display(
            Name = "Retenciones que le practicaron a favor del municipio",
            Description = "Registre el valor que le retuvieron a favor del municipio durante el período gravable declarado, por los conceptos que sean objeto de esta declaración (ICA, Avisos, Sobretasas)"
        )]
        [Range(0, double.MaxValue)]
        public double RetencionesDelMunicipio { get; set; }

        
        [Display(
            Name = "Autorretencionens Practicadas a favor del municipio",
            Description = "Si tiene la calidad de autorretenedor (Artículo 106 del Acuerdo 009 de 2018), registre el valor que pagó a favor de este municipio, durante el período gravable declarado, que no hayan sido previamente descontadas"
        )]
        public HttpPostedFileBase ArchivoRetencion { get; set; }

        [NotMapped]
        public string RutaArchivoRetencion { get; set; }


        [Required]
        [Display(
            Name = "Autorretenciones Practicadas a favor del municipio",
            Description = "Si tiene la calidad de autorretenedor (Artículo 106 del Acuerdo 009 de 2018), registre el valor que pagó a favor de este municipio, durante el período gravable declarado, que no hayan sido previamente descontadas"
        )]
        [Range(0, double.MaxValue)]
        public double AutoretencionesDelMunicipio { get; set; }


        [Required]
        [Display(
            Name = "Anticipo Liquidado en el Año Anterior",
            Description = "Si en el municipio existe el anticipo del impuesto de Industria y Comercio, registre el valor liquidado por ese concepto en la declaración del año inmediatamente anterior"
        )]
        [Range(0, double.MaxValue)]
        public double AnticipoAnioAnterior { get; set; }


        [Required]
        [Display(
            Name = "Anticipo del Año Siguiente",
            Description = "Si en el municipio existe el anticipo del impuesto de Industria y Comercio, registre el valor de anticipo para el año siguiente según la regulación"
        )]
        [Range(0, double.MaxValue)]
        public double AnticipoAnioSiguiente { get; set; }

        
        [Display(
            Name = "Tipo de Sanción",
            Description = ""
        )]
        public int? TipoSancion { get; set; }


        [Display(
            Name = "Valor de la Sanción",
            Description = "Es el 5% del total del impuesto a cargo (si es diferente de cero) multiplicado por el número de meses o fracción de mes calendario de retardo "
        )]
        [Range(0, double.MaxValue)]
        public double ValorSancion { get; set; }


        [Display(
            Name = "Saldo a favor Período Anterior",
            Description = "Si cuenta con un saldo a favor en acto administrativo que autorice su compensación con esta declaración, diligencia aquí ese valor"
        )]
        [Range(0, double.MaxValue)]
        public double SaldoFavorPeriodoAnterior { get; set; }


        [Display(
            Name = "Total Saldo a Cargo",
            Description = "Es el resultado de la siguiente operación: 25-26-27-28-29+30+31-32"
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
            Description = "Es el resultado de la siguiente operación: 25-26-27-28-29+30+31-32"
        )]
        public double TotalSaldoFavor => TotalSaldoCargo < 0 ? Math.Abs(TotalSaldoFavor) : 0;


        #endregion

        // --------------------------------------------------------------------

        #region Vista De Pago Sección "E" #9


        [Required]
        [Display(
            Name = "Valor A Pagar",
            Description = ""
        )]
        [Range(0, double.MaxValue)]
        public double ValorPagar => TotalSaldoCargo;


        public double PorcentajeDescuento { get; set; }


        [Required]
        [Display(
            Name = "Descuento Por Pronto Pago",
            Description = "Lorem ipsum"
        )]
        public double Descuento => ValorPagar * (PorcentajeDescuento * 0.01);


        public double PorcentajeInteres { get; set; }
        [Required]
        [Display(
            Name = "Intereses de Mora",
            Description = "Lorem ipsum"
        )]
        public double Interes => ValorPagar * (PorcentajeInteres * 0.01);



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

        public string Codigo { get; set; }

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

        public double Valor { get; set; }

        [Display(
            Name = "Impuestos Industria Comercio",
            Description = "Lorem ipsum"
        )]
        public double Impuesto => (IngresosGravados * Tarifa) / 1000;


    }
}