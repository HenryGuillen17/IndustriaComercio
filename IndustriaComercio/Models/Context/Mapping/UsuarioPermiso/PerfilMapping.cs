using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using IndustriaComercio.Entidades.UsuarioPermisos;

namespace IndustriaComercio.Context.mapping.UsuarioPermiso
{
    public class PerfilMapping: EntityTypeConfiguration<Perfil>
    {
        public PerfilMapping()
        {
            // Tabla y esquema
            ToTable("Perfiles", "dbo");

            //Llave
            HasKey(x => x.PerfilId);

            //Propiedades
            Property(x => x.PerfilId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // No Autoincrementable
            Property(x => x.Descripcion).IsRequired().HasMaxLength(50);

        }

    }
}
