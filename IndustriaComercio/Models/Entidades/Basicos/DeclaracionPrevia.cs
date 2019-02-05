using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Entidades.Persona;
using IndustriaComercio.Models.Enum;
using System.Collections.Generic;

namespace IndustriaComercio.Models.Entidades.Basicos
{
    public class DeclaracionPrevia
    {


        #region Propiedades


        // --------------------------------------------------------------------

        #region Vista Encabezado #1

        public int DeclaracionPreviaId { get; set; }

        public int Año { get; set; }

        public TipoDeclaracion TipoDeclaracion { get; set; }

        public int TipoContribuyenteId { get; set; }

        public bool TienePagoVoluntario { get; set; }

        public bool PagaAvisoTablero { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Datos Personales Sección "A" #2


        public int PersonaId { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #3

        public int IngresosEnElPais { get; set; }

        public int IngresosFueraDelMunicipio { get; set; }

        public int TotalIngresosMunicipio { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #4

        public int IngresosDevoluciones { get; set; }

        public int IngresosExportaciones { get; set; }

        public int IngresosActivosFijos { get; set; }

        public int IngresosNoGravados { get; set; }

        public int IngresosActividadesExentas { get; set; }

        public int TotalIngresosGravables { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Actividades Gravadas Sección "C" #5
            
        /// <summary>
        /// Se obtiene de la sumatoria de tarifas de Actividades Gravadas
        /// </summary>
        public int TotalTarifa { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Actividades Gravadas Impuesto Generación Energía Sección "C" #6

        public int CapacidadInstalada { get; set; }


        /// <summary>
        /// Se obtiene de la multiplicación de CapacidadInstalada * ValorPorKiloVatio
        /// NO LO SÉ
        /// </summary
        public int TotaImpuestoEnergiaElectrica { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Liquidación Privada Sección "D" #7

        public int TotalImpuestoIndustriaComercio { get; set; }


        /// <summary>
        /// A TotalImpuestoIndustriaComercio se le saca el 15% y se redondea por múltiplo de 1000
        /// </summary
        public int ImpuestoAvisosTableros { get; set; }

        public int PagoUnidadesComerciales { get; set; }

        public int SobretasaBomberil { get; set; }

        public int SobretasaSeguridad { get; set; }

        public int TotalImpuestoCargo { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Liquidación Privada Total Sección "D" #8


        public int ValorExoneracionImpuesto { get; set; }

        public int RetencionesDelMunicipio { get; set; }

        public int AutoretencionesDelMunicipio { get; set; }

        public string DocumentoRetencion { get; set; }

        public int AnticipoAnioAnterior { get; set; }

        public int AnticipoAnioSiguiente { get; set; }

        public int TipoSancionId { get; set; }

        public int SaldoFavorPeriodoAnterior { get; set; }

        public int TotalSaldoCargo { get; set; }

        public int TotalSaldoFavor { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista De Pago Sección "E" #9


        public int ValorPagar { get; set; }

        public double PorcentajeDescuento { get; set; }

        public double Descuento => ValorPagar - (ValorPagar * (PorcentajeDescuento * 0.01));

        public double PorcentajeIntereses { get; set; }

        public double Interes => ValorPagar + (ValorPagar * (PorcentajeIntereses * 0.01));

        public int TotalPagar { get; set; }


        #endregion


        #endregion

        public virtual ICollection<ActividadGravablePorDeclaracion> ActividadesGravadas { get; set; }
        public virtual ClasificacionContribuyente ClasificacionContribuyente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public TipoSancion TipoSancion { get; set; }
    }


}