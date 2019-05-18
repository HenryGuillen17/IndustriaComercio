using System;
using System.Linq;

namespace IndustriaComercio.Common.Utils
{
    public class ApiFilter<T> where T : class, new()
    {
        public ApiFilter() {} 

        public ApiFilter(string sort, int page, int perPage, string filter)
        {
            var formato = sort.Split('|');
            if (!formato.Any() || formato.Count() != 2)
                throw new Exception("El formato de ordenamiento no es correcto");

            OrdenarPor = formato[0];
            EsAscendente = formato[1] == "asc";
            FiltrosStr = filter;
            PaginaNo = page;
            PorPagina = perPage;
        }


        // private T filter;

        public string OrdenarPor { get; set; }
        public bool EsAscendente { get; set; }
        public string FiltrosStr { get; set; }
        public int PaginaNo { get; set; }
        public int PorPagina { get; set; }
        public T Filtros {
            get {
                return string.IsNullOrWhiteSpace(FiltrosStr)
                    ? new T()
                    : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(FiltrosStr);
            }
        }
    }
}