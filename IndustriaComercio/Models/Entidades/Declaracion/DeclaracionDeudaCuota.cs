
using IndustriaComercio.Models.Entidades.Basicos;
using IndustriaComercio.Models.Entidades.Declaracion;
using System;
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{

    public class DeclaracionDeudaCuota
    {
        public int DeclaracionDeudaCuotaId { get; set; }
        public int DeclaracionPreviaId { get; set; }
        public DateTime FechaVencimiento { get; set; }


        

        public double TotalImpuestoIndustriaComercio { get; set; }

        public double ImpuestoAvisosTableros { get; set; }

        public double PagoUnidadesComerciales { get; set; }

        public double SobretasaBomberil { get; set; }

        public double SobretasaSeguridad { get; set; }

        public double TotalImpuestoCargo { get; set; }

        public double ValorExoneracionImpuesto { get; set; }

        public double RetencionesDelMunicipio { get; set; }

        public double AutoretencionesDelMunicipio { get; set; }

        public double AnticipoAnioAnterior { get; set; }

        public double AnticipoAnioSiguiente { get; set; }

        public double ValorSancion { get; set; }

        public double SaldoFavorPeriodoAnterior { get; set; }

        public double TotalSaldoCargo { get; set; }

        public double TotalSaldoFavor { get; set; }



        public virtual DeclaracionPrevia DeclaracionPrevia { get; set; }
        public virtual ICollection<ReportePagoDeclaracionDetalle> ReportePagoDeclaracionesDetalles { get; set; }
    }
}