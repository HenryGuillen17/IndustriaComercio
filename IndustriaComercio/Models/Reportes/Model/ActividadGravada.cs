namespace IndustriaComercio.Models.Reportes.Model
{
    public class ActividadGravada
    {
        public int ActividadId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double IngresosGravados { get; set; }
        public double Tarifa { get; set; }
        public double Impuesto { get; set; }
    }
}