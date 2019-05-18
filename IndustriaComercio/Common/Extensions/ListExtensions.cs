using IndustriaComercio.Common.Utils;
using PagedList;
using System.Linq;

namespace IndustriaComercio.Common.Extensions
{
    public static class ListExtensions
    {
        public static Paginacion<TData> Paginar<TData>(this IPagedList<TData> list)
            where TData : class
        {
            return new Paginacion<TData>
            {
                per_page = list.Count,
                data = list.ToList(),
                current_page = list.PageNumber,
                @from = list.FirstItemOnPage,
                to = list.LastItemOnPage,
                total = list.TotalItemCount,
                last_page = list.PageCount
            };
        }
    }
}