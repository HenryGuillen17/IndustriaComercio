namespace IndustriaComercio.Models.Context
{
    using IndustriaComercio.Context.mapping.UsuarioPermiso;
    using IndustriaComercio.Entidades.Basicos;
    using IndustriaComercio.Entidades.Persona;
    using IndustriaComercio.Entidades.UsuarioPermisos;
    using IndustriaComercio.Models.Context.mapping.Persona;
    using IndustriaComercio.Models.Context.mapping.TablasBasicas;
    using IndustriaComercio.Models.Context.Mapping.Declaracion;
    using IndustriaComercio.Models.Entidades.Basicos;
    using IndustriaComercio.Models.Entidades.Declaracion;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class ModelServidor : DbContext
    {
        public ModelServidor() : base("name=ModelServidor") { }

        public DbSet<ActividadGravablePorDeclaracion> ActividadGravablePorDeclaracion { get; set; }
        public DbSet<ActividadGravada> ActividadGravada { get; set; }
        public DbSet<ClasificacionContribuyente> ClasificacionContribuyente { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DeclaracionPrevia> DeclaracionPrevia { get; set; }
        public DbSet<DeclaracionDeudaCuota> DeclaracionDeudaCuota { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Establecimiento> Establecimiento { get; set; }
        public DbSet<EstablecimientoActividad> EstablecimientoActividad { get; set; }
        public DbSet<ListaCorreo> ListaCorreo { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<TipoActividad> TipoActividad { get; set; }
        public DbSet<TipoSancion> TipoSancion { get; set; }
        public DbSet<ParametroVencimiento> ParametroVencimiento { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<ReportePagoDeclaracion> ReportePagoDeclaracion { get; set; }
        public DbSet<ReportePagoDeclaracionDetalle> ReportePagoDeclaracionDetalle { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


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
            modelBuilder.Configurations.Add(new TipoActividadMapping());
            modelBuilder.Configurations.Add(new TipoSancionMapping());

            modelBuilder.Configurations.Add(new DeclaracionPreviaMapping());
            modelBuilder.Configurations.Add(new DeclaracionDeudaCuotaMapping());
            modelBuilder.Configurations.Add(new ActividadGravablePorDeclaracionMapping());
            modelBuilder.Configurations.Add(new ActividadGravadaMapping());
            modelBuilder.Configurations.Add(new ClasificacionContribuyenteMapping());

            modelBuilder.Configurations.Add(new DescuentoMapping());
            modelBuilder.Configurations.Add(new InteresMapping());

            modelBuilder.Configurations.Add(new EstablecimientoMapping());
            modelBuilder.Configurations.Add(new EstablecimientoActividadMapping());

            modelBuilder.Configurations.Add(new DepartamentoMapping());
            modelBuilder.Configurations.Add(new MunicipioMapping());

            modelBuilder.Configurations.Add(new ParametroVencimientoMapping());
            modelBuilder.Configurations.Add(new ReportePagoDeclaracion.Map());
            modelBuilder.Configurations.Add(new ReportePagoDeclaracionDetalle.Map());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
