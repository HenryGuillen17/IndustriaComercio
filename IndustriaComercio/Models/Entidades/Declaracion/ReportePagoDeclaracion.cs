using IndustriaComercio.Entidades.Basicos;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Entidades.Declaracion
{
    public class ReportePagoDeclaracion
    {
        public long ReportePagoDeclaracionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool HaSidoCancelado { get; set; }

        public class Map : EntityTypeConfiguration<ReportePagoDeclaracion>
        {
            public Map()
            {

                HasKey(t => t.ReportePagoDeclaracionId);

                Property(a => a.ReportePagoDeclaracionId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No autoIncremental

                Property(x => x.FechaCreacion).IsRequired();
                Property(x => x.FechaVencimiento).IsRequired();
                Property(x => x.HaSidoCancelado).IsRequired();

                // Tabla y esquema de la base de datos.
                ToTable("ReportesPagosDeclaraciones", "dbo");
            }
        }
    }

    public class ReportePagoDeclaracionDetalle
    {
        public int DeclaracionDeudaCuotaId { get; set; }
        public long ReportePagoDeclaracionId { get; set; }

        public virtual DeclaracionDeudaCuota DeclaracionDeudaCuota { get; set; }



        public class Map : EntityTypeConfiguration<ReportePagoDeclaracionDetalle>
        {
            public Map()
            {

                HasKey(t => new { t.DeclaracionDeudaCuotaId, t.ReportePagoDeclaracionId });


                // DeclaracionDeudaCuotaId
                HasRequired(p => p.DeclaracionDeudaCuota)
                    .WithMany(p => p.ReportePagoDeclaracionesDetalles)
                    .HasForeignKey(p => p.DeclaracionDeudaCuotaId)
                    .WillCascadeOnDelete(false);

                // Tabla y esquema de la base de datos.
                ToTable("ReportesPagosDeclaracionesDetalles", "dbo");
            }
        }
    }
}