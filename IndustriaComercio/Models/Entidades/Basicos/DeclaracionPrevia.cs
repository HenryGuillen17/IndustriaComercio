using IndustriaComercio.Entidades.Basicos;
using IndustriaComercio.Entidades.Persona;
using IndustriaComercio.Models.Enum;
using System;
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

        public DateTime FechaDeclaracion { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Datos Personales Sección "A" #2


        public int PersonaId { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #3

        public double IngresosEnElPais { get; set; }

        public double IngresosFueraDelMunicipio { get; set; }

        public double TotalIngresosMunicipio { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Base Gravable Sección "B" #4

        public double IngresosDevoluciones { get; set; }

        public double IngresosExportaciones { get; set; }

        public double IngresosActivosFijos { get; set; }

        public double IngresosNoGravados { get; set; }

        public double IngresosActividadesExentas { get; set; }

        public double TotalIngresosGravables { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Actividades Gravadas Sección "C" #5
            
        /// <summary>
        /// Se obtiene de la sumatoria de tarifas de Actividades Gravadas
        /// </summary>
        public double TotalTarifa { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Actividades Gravadas Impuesto Generación Energía Sección "C" #6

        public double CapacidadInstalada { get; set; }


        /// <summary>
        /// Se obtiene de la multiplicación de CapacidadInstalada * ValorPorKiloVatio
        /// NO LO SÉ
        /// </summary
        public double TotaImpuestoEnergiaElectrica { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Liquidación Privada Sección "D" #7

        public double TotalImpuestoIndustriaComercio { get; set; }


        /// <summary>
        /// A TotalImpuestoIndustriaComercio se le saca el 15% y se redondea por múltiplo de 1000
        /// </summary
        public double ImpuestoAvisosTableros { get; set; }

        public double PagoUnidadesComerciales { get; set; }

        public double SobretasaBomberil { get; set; }

        public double SobretasaSeguridad { get; set; }

        public double TotalImpuestoCargo { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Liquidación Privada Total Sección "D" #8


        public double ValorExoneracionImpuesto { get; set; }

        public double RetencionesDelMunicipio { get; set; }

        public double AutoretencionesDelMunicipio { get; set; }

        public string DocumentoRetencion { get; set; }

        public double AnticipoAnioAnterior { get; set; }

        public double AnticipoAnioSiguiente { get; set; }

        public int? TipoSancionId { get; set; }

        public double ValorSancion { get; set; }

        public double SaldoFavorPeriodoAnterior { get; set; }

        public double TotalSaldoCargo { get; set; }

        public double TotalSaldoFavor { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista De Pago Sección "E" #9


        public double ValorPagar { get; set; }

        public double PorcentajeDescuento { get; set; }

        public double Descuento { get; set; }

        public double PorcentajeIntereses { get; set; }

        public double Interes { get; set; }

        public double TotalPagar { get; set; }


        #endregion


        #endregion

        public virtual ICollection<ActividadGravablePorDeclaracion> ActividadesGravadas { get; set; }
        public virtual ICollection<DeclaracionDeudaCuota> DeclaracionDeudasCuotas { get; set; }
        public virtual Cliente Cliente { get; set; }
        public TipoSancion TipoSancion { get; set; }
    }


}