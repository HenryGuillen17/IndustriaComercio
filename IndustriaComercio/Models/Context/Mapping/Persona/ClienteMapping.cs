using IndustriaComercio.Entidades.Persona;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace IndustriaComercio.Models.Context.mapping.Persona
{
    public class ClienteMapping: EntityTypeConfiguration<Cliente>
    {
        public ClienteMapping()
        {
            // llave primaria.
            HasKey(t => t.PersonaId);

            // Tabla y esquema de la base de datos.
            ToTable("Clientes", "dbo");
            
            HasRequired(x => x.Persona).WithOptional(x => x.Cliente);
            

        } 
    }
}