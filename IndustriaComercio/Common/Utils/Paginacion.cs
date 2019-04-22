using System.Collections.Generic;

namespace IndustriaComercio.Common.Utils
{
    public class Paginacion<T> where T : class
    {
        public int total { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
        public int last_page { get; set; }
        public string next_page_url { get; set; }
        public string prev_page_url { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public IEnumerable<T> data { get; set; }

    }
}