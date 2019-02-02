namespace IndustriaComercio.Models.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using IndustriaComercio.Context.mapping.UsuarioPermiso;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using IndustriaComercio.Models.Context.mapping.Persona;
    using IndustriaComercio.Models.Context.mapping.TablasBasicas;
    using IndustriaComercio.Entidades.Basicos;
    using IndustriaComercio.Models.Context.Mapping.Declaracion;
    using IndustriaComercio.Models.Entidades.Basicos;

    public partial class ModelServidor : DbContext
    {
        public ModelServidor()
            : base("name=ModelServidor")
        {
        }

        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<TipoContribuyente> TipoContribuyente { get; set; }
        public DbSet<DeclaracionPrevia> DeclaracionPrevia { get; set; }
        public DbSet<ActividadGravablePorDeclaracion> ActividadGravablePorDeclaracion { get; set; }
        public DbSet<ActividadGravada> ActividadGravada { get; set; }
        public DbSet<ClasificacionContribuyente> ClasificacionContribuyente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OpcionesMenuMapping());
            modelBuilder.Configurations.Add(new OpcionesSubMenuMapping());
            modelBuilder.Configurations.Add(new OpcionesPermisoMapping());
            //
            modelBuilder.Configurations.Add(new PerfilMapping());
            modelBuilder.Configurations.Add(new PerfilMenuMapping());
            modelBuilder.Configurations.Add(new PerfilSubMenuMapping());
            modelBuilder.Configurations.Add(new PerfilPermisoMapping());

            modelBuilder.Configurations.Add(new UsuarioMapping());
            modelBuilder.Configurations.Add(new UsuarioMenuMapping());
            modelBuilder.Configurations.Add(new UsuarioSubMenuMapping());
            modelBuilder.Configurations.Add(new UsuarioPermisoMapping());

            //persona
            modelBuilder.Configurations.Add(new PersonaMapping());
            modelBuilder.Configurations.Add(new ClienteMapping());
            modelBuilder.Configurations.Add(new TipoDocumentoMapping());
            modelBuilder.Configurations.Add(new TipoContribuyenteMapping());

            modelBuilder.Configurations.Add(new DeclaracionPreviaMapping());
            modelBuilder.Configurations.Add(new ActividadGravablePorDeclaracionMapping());
            modelBuilder.Configurations.Add(new ActividadGravadaMapping());
            modelBuilder.Configurations.Add(new ClasificacionContribuyenteMapping());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
