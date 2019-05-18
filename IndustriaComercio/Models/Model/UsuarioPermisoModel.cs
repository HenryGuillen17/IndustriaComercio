namespace IndustriaComercio.Models.Model
{
    public class UsuarioPermisoModel
    {
        public int PersonaId { get; set; }
        public byte MenuId { get; set; }
        public byte SubMenuId { get; set; }
        public byte PermisoId { get; set; }
        public string Descripcion { get; set; }
        public bool Permiso { get; set; }
    }
}