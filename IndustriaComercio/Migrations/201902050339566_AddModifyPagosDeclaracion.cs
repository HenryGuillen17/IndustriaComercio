namespace IndustriaComercio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModifyPagosDeclaracion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Persona", newName: "Personas");
            RenameTable(name: "dbo.Cliente", newName: "Clientes");
            DropIndex("dbo.DeclaracionesPrevias", new[] { "ClasificacionContribuyenteId" });
            RenameColumn(table: "dbo.DeclaracionesPrevias", name: "ClasificacionContribuyenteId", newName: "ClasificacionContribuyente_ClasificacionContribuyenteId");
            CreateTable(
                "dbo.TiposSanciones",
                c => new
                    {
                        TipoSancionId = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Porcentaje = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TipoSancionId);
            
            CreateTable(
                "dbo.DescuentosPago",
                c => new
                    {
                        Anio = c.Short(nullable: false),
                        Mes = c.Byte(nullable: false),
                        Porcentaje = c.Double(nullable: false),
                        ConceptoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Anio, t.Mes });
            
            CreateTable(
                "dbo.InteresesMora",
                c => new
                    {
                        Anio = c.Short(nullable: false),
                        Mes = c.Byte(nullable: false),
                        Porcentaje = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Anio, t.Mes });
            
            AddColumn("dbo.DeclaracionesPrevias", "PagaAvisoTablero", c => c.Boolean(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "PersonaId", c => c.Int(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "DocumentoRetencion", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "TipoSancionId", c => c.Int(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "PorcentajeDescuento", c => c.Double(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "PorcentajeIntereses", c => c.Double(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "Interes_Anio", c => c.Short());
            AddColumn("dbo.DeclaracionesPrevias", "Interes_Mes", c => c.Byte());
            AddColumn("dbo.Personas", "DigitoChequeo", c => c.String());
            AddColumn("dbo.Personas", "Municipio", c => c.String());
            AddColumn("dbo.Personas", "Departamento", c => c.String());
            AddColumn("dbo.Personas", "ClasificacionContribuyenteId", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "NumeroEstablecimientos", c => c.Int(nullable: false));
            AlterColumn("dbo.DeclaracionesPrevias", "ClasificacionContribuyente_ClasificacionContribuyenteId", c => c.Int());
            CreateIndex("dbo.DeclaracionesPrevias", "PersonaId");
            CreateIndex("dbo.DeclaracionesPrevias", "TipoSancionId");
            CreateIndex("dbo.DeclaracionesPrevias", "ClasificacionContribuyente_ClasificacionContribuyenteId");
            CreateIndex("dbo.DeclaracionesPrevias", new[] { "Interes_Anio", "Interes_Mes" });
            AddForeignKey("dbo.DeclaracionesPrevias", "PersonaId", "dbo.Clientes", "PersonaId");
            AddForeignKey("dbo.DeclaracionesPrevias", "TipoSancionId", "dbo.TiposSanciones", "TipoSancionId");
            AddForeignKey("dbo.DeclaracionesPrevias", new[] { "Interes_Anio", "Interes_Mes" }, "dbo.InteresesMora", new[] { "Anio", "Mes" });
            DropColumn("dbo.DeclaracionesPrevias", "NombreCompleto");
            DropColumn("dbo.DeclaracionesPrevias", "TipoDocumentoId");
            DropColumn("dbo.DeclaracionesPrevias", "NoIdentificacion");
            DropColumn("dbo.DeclaracionesPrevias", "DigitoChequeo");
            DropColumn("dbo.DeclaracionesPrevias", "Direccion");
            DropColumn("dbo.DeclaracionesPrevias", "MunicipioNotificacion");
            DropColumn("dbo.DeclaracionesPrevias", "DepartamentoNotificacion");
            DropColumn("dbo.DeclaracionesPrevias", "Telefono");
            DropColumn("dbo.DeclaracionesPrevias", "Correo");
            DropColumn("dbo.DeclaracionesPrevias", "NumeroEstablecimientos");
            DropColumn("dbo.DeclaracionesPrevias", "TipoSancion");
            DropColumn("dbo.DeclaracionesPrevias", "OtroTipoSancion");
            DropColumn("dbo.DeclaracionesPrevias", "ValorSancion");
            DropColumn("dbo.DeclaracionesPrevias", "DescuentoProntoPago");
            DropColumn("dbo.DeclaracionesPrevias", "InteresesDeMora");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeclaracionesPrevias", "InteresesDeMora", c => c.Int(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "DescuentoProntoPago", c => c.Int(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "ValorSancion", c => c.Int(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "OtroTipoSancion", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "TipoSancion", c => c.Byte(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "NumeroEstablecimientos", c => c.Int(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "Correo", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "Telefono", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "DepartamentoNotificacion", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "MunicipioNotificacion", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "Direccion", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "DigitoChequeo", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "NoIdentificacion", c => c.String());
            AddColumn("dbo.DeclaracionesPrevias", "TipoDocumentoId", c => c.Int(nullable: false));
            AddColumn("dbo.DeclaracionesPrevias", "NombreCompleto", c => c.String());
            DropForeignKey("dbo.DeclaracionesPrevias", new[] { "Interes_Anio", "Interes_Mes" }, "dbo.InteresesMora");
            DropForeignKey("dbo.DeclaracionesPrevias", "TipoSancionId", "dbo.TiposSanciones");
            DropForeignKey("dbo.DeclaracionesPrevias", "PersonaId", "dbo.Clientes");
            DropIndex("dbo.DeclaracionesPrevias", new[] { "Interes_Anio", "Interes_Mes" });
            DropIndex("dbo.DeclaracionesPrevias", new[] { "ClasificacionContribuyente_ClasificacionContribuyenteId" });
            DropIndex("dbo.DeclaracionesPrevias", new[] { "TipoSancionId" });
            DropIndex("dbo.DeclaracionesPrevias", new[] { "PersonaId" });
            AlterColumn("dbo.DeclaracionesPrevias", "ClasificacionContribuyente_ClasificacionContribuyenteId", c => c.Int(nullable: false));
            DropColumn("dbo.Clientes", "NumeroEstablecimientos");
            DropColumn("dbo.Personas", "ClasificacionContribuyenteId");
            DropColumn("dbo.Personas", "Departamento");
            DropColumn("dbo.Personas", "Municipio");
            DropColumn("dbo.Personas", "DigitoChequeo");
            DropColumn("dbo.DeclaracionesPrevias", "Interes_Mes");
            DropColumn("dbo.DeclaracionesPrevias", "Interes_Anio");
            DropColumn("dbo.DeclaracionesPrevias", "PorcentajeIntereses");
            DropColumn("dbo.DeclaracionesPrevias", "PorcentajeDescuento");
            DropColumn("dbo.DeclaracionesPrevias", "TipoSancionId");
            DropColumn("dbo.DeclaracionesPrevias", "DocumentoRetencion");
            DropColumn("dbo.DeclaracionesPrevias", "PersonaId");
            DropColumn("dbo.DeclaracionesPrevias", "PagaAvisoTablero");
            DropTable("dbo.InteresesMora");
            DropTable("dbo.DescuentosPago");
            DropTable("dbo.TiposSanciones");
            RenameColumn(table: "dbo.DeclaracionesPrevias", name: "ClasificacionContribuyente_ClasificacionContribuyenteId", newName: "ClasificacionContribuyenteId");
            CreateIndex("dbo.DeclaracionesPrevias", "ClasificacionContribuyenteId");
            RenameTable(name: "dbo.Clientes", newName: "Cliente");
            RenameTable(name: "dbo.Personas", newName: "Persona");
        }
    }
}
