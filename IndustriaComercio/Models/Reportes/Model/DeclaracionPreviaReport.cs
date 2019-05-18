using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndustriaComercio.Models.Reportes.Model
{
    public class DeclaracionPreviaReport
    {

        #region Propiedades


        // --------------------------------------------------------------------

        #region Vista Encabezado #1

        public int DeclaracionPreviaId { get; set; }

        public int Anio { get; set; }

        public string DepartamentoReporte { get; set; }

        public string MunicipioReporte { get; set; }

        public string TipoDeclaracion { get; set; }

        public bool TienePagoVoluntario { get; set; }

        public bool PagaAvisoTablero { get; set; }

        public DateTime FechaDeclaracion { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista Datos Personales Sección "A" #2


        public int PersonaId { get; set; }

        public string NombreRazonSocial { get; set; }

        public string TipoDocumentoNombre { get; set; }

        public string NoIdentificacion { get; set; }

        public string DigitoChequeo { get; set; }

        public string DireccionNegocio { get; set; }

        public string MunicipioNegocio { get; set; }

        public string DepartamentoNegocio { get; set; }

        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public string TipoContribuyenteNombre { get; set; }

        public int NoEstablecimientos { get; set; }



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
        public double TotalImpuestrosGravados { get; set; }


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

        public string TipoSancionNombre { get; set; }

        public double ValorSancion { get; set; }

        public double SaldoFavorPeriodoAnterior { get; set; }

        public double TotalSaldoCargo { get; set; }

        public double TotalSaldoFavor { get; set; }


        #endregion

        // --------------------------------------------------------------------

        #region Vista De Pago Sección "E" #9


        public double ValorPagar { get; set; }

        public double Descuento { get; set; }

        public double Interes { get; set; }

        public double TotalPagar { get; set; }

        public ICollection<ActividadGravada> ActividadesGravadas { get; set; }


        #endregion


        #endregion


    }
}