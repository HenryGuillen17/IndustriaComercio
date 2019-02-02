using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IndustriaComercio.Common.Extensions
{
    public static class SqlExtensions
    {


        /// <summary>
        /// Metodo generico para obtener el valor maximo + 1 de un campo
        /// </summary>
        /// <param name="dbset"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int Consecutivo<TEntity>(
            this DbSet<TEntity> dbset,
            Expression<Func<TEntity, int?>> predicate,
            Expression<Func<TEntity, bool>> whereExp = null
            ) where TEntity : class
        {
            try
            {
                int? valor;
                if (whereExp != null)
                    valor = dbset.Where(whereExp).Max(predicate);
                else
                    valor = dbset.Max(predicate);

                if (valor == null)
                    return 1;

                return (int)(valor + 1);
            }
            catch (Exception err)
            {
                var messageError = err.InnerException?.InnerException?.Message ?? (err.InnerException?.Message ?? err.Message);
                throw new Exception(messageError, err);
            }
        }



    }
}