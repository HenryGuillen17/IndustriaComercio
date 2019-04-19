namespace IndustriaComercio.Models.Enum
{
    public enum Menu
    {
        Inicio=1,
        Despacho=2,
        Personas=3,
        UsuariosPermisos=4,
        TablasBasicas=5
    }

    public enum MenuSubMenu
    {
        Citas = 1,
        Procesos = 2,
        Consulta = 3,

        Clientes = 1,
        Abogados = 2,
        Entidades=3,

        Usuarios = 1,
        Perfiles = 2,
        Permisos = 3,

        TipoCliente = 1,
        TipoEntidades = 2,
        TipoDocumento = 3,
        Tramites = 4,
        Asuntos = 5,
        Procedimientos = 6
    }

    public enum Permiso
    {
        Index = 1,
        Create = 2,
        CreatePost = 3,
        Edit = 4,
        EditPost = 5,
        Details = 6,
        Delete = 7
    }
}