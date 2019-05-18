using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace IndustriaComercio.Common.Extensions
{
    /// <summary>
    /// Sumatoria de varias soluciones para ordenar código
    /// Ordenar: https://stackoverflow.com/a/233505
    /// </summary>
    public static class SqlExtensions
    {


        #region Private Methods

        private static IOrderedQueryable<T> ApplyOrder<T>(
            IQueryable<T> source,
            string property,
            string methodName
            )
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }


        #endregion


        #region Public Methods

        public static IOrderedQueryable<T> OrderBy<T>(
            this IQueryable<T> source,
            string property, bool asc
            )
        {
            if (asc)
                return ApplyOrder(source, property, "OrderBy");
            return ApplyOrder(source, property, "OrderByDescending");
        }


        public static IOrderedQueryable<T> ThenBy<T>(
            this IOrderedQueryable<T> source,
            string property, bool asc
            )
        {
            if (asc)
                return ApplyOrder(source, property, "ThenBy");
            return ApplyOrder(source, property, "ThenByDescending");
        }


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

        #endregion


    }
}