using System;

namespace IndustriaComercio.Models.Model
{

    public class DeclaracionDeudaCuotaModel
    {
        public int DeclaracionDeudaCuotaId { get; set; }
        public int DeclaracionPreviaId { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int PersonaId { get; set; }
        public int AnioDeclaracion { get; set; }



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

        public double InteresesMora { get; set; }
        public string NombreCompleto { get; set; }
        public string NoIdentificacionCompleto { get; set; }
    }
}