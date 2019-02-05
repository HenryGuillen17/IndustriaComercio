using IndustriaComercio.Entidades.Basicos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace IndustriaComercio.Models.Context.Mapping.Declaracion
{
    public class DescuentoMapping : EntityTypeConfiguration<Descuento>
    {
        public DescuentoMapping()

        {
            // llave primaria.
            HasKey(t => new
            {
                t.Anio,
                t.Mes
            });
            
            // Tabla y esquema de la base de datos.
            ToTable("DescuentosPago", "dbo");
        }
    }
}