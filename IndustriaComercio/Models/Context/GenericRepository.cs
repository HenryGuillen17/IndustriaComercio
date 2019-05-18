using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;

namespace IndustriaComercio.Models.Context
{
    /// <summary>
    /// Clase repositorio genérico para Operaciones de las Entidades
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Private member variables...

        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;
        #endregion

        #region Public Constructor...

        /// <summary>
        /// Constructor Público, inicializo y declaro variables locales privada .
        /// </summary>
        /// <param name="context"></param>
        protected GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        #endregion

        #region Public member methods...

        /// <summary>
        /// Metodo generico para obtener el valor maximo + 1 de un campo
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public long Consecutivo(Expression<Func<TEntity, long?>> predicate, Expression<Func<TEntity, bool>> filtro = null)
        {
            try
            {
                long? valor;

                if (filtro != null)
                    valor = DbSet.Where(filtro)
                                 .Max(predicate);
                else
                    valor = DbSet.Max(predicate);

                if (valor == null) return 1;

                return (long)(valor + 1);
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }

        /// <summary>
        /// Metodo generico para obtener el valor maximo + 1 de un campo
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public int Consecutivo(Expression<Func<TEntity, int?>> predicate, Expression<Func<TEntity, bool>> filtro = null)
        {
            try
            {
                int? valor;

                if (filtro != null)
                    valor = DbSet.Where(filtro)
                                 .Max(predicate);
                else
                    valor = DbSet.Max(predicate);

                if (valor == null) return 1;

                return (int)(valor + 1);
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }



        public short Consecutivo(Expression<Func<TEntity, short?>> predicate, Expression<Func<TEntity, bool>> filtro = null)
        {
            try
            {
                short? valor;

                if (filtro != null)
                    valor = DbSet.Where(filtro)
                                 .Max(predicate);
                else
                    valor = DbSet.Max(predicate);

                if (valor == null) return 1;

                return (short)(valor + 1);
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }

        public byte Consecutivo(Expression<Func<TEntity, byte?>> predicate, Expression<Func<TEntity, bool>> filtro = null)
        {
            try
            {
                byte? valor;

                if (filtro != null)
                    valor = DbSet.Where(filtro)
                                 .Max(predicate);
                else
                    valor = DbSet.Max(predicate);

                if (valor == null) return 1;

                return (byte)(valor + 1);
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }

        /// <summary>
        /// método genérico para ir a buscar todos los registros de db
        /// </summary>
        /// <returns></returns>
        public virtual IList<TEntity> GetAll()
        {
            try
            {
                return DbSet.ToList();
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ??
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }

        /// <summary>
        /// Método get genérico sobre la base de la identificación de las Entidades .
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            try
            {
                return DbSet.Find(id);
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }

        /// <summary>
        /// Filtro con include y ordenamiento
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"/> 
        /// <param name="orderBy"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        int top = 0, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = DbSet;

                //Agregar dependencias
                if (includes.Any())
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }

                //Filtrar
                if (filter != null) query = query.Where(filter);

                //Ordenar
                if (orderBy != null) query = orderBy(query);

                //Limitar
                if (top > 0) query = query.Take(top);

                return query.ToList();
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }

        /// <summary>
        /// método genérico para conseguir muchos registro sobre la base de una condición de búsqueda , pero capaz .
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = DbSet;

            //Agregar dependencias
            if (includes.Any())
            {
                query = includes.Aggregate(query, (current, item) => current.Include(item));
            }

            if (filter != null) query = query.Where(filter);

            return query;
        }

        /// <summary>
        /// Obtiene el primer registro que coincida con los criterios especificados o un valor predeterminado si no encuentra ningun elemento
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = DbSet;

                //Agregar dependencias
                if (includes.Any())
                {
                    query = includes.Aggregate(query, (current, item) => current.Include(item));
                }

                return query.FirstOrDefault(filter);
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ??
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }


        /// <summary>
        /// Obtiene el primer registro que coincida con los criterios especificados o error si no lo encuentra
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = DbSet;

                //Agregar dependencias
                query = includes.Aggregate(query, (current, include) => current.Include(include));

                return query.First(filter);
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }

        /// <summary>
        /// Método genérico para comprobar si existe la entidad
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            try
            {
                return DbSet.Find(primaryKey) != null;
            }
            catch (EntityException err)
            {
                var messageError = err.InnerException?.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.InnerException?.Message ?? 
                                   err.InnerException?.Message ?? err.Message;
                throw new Exception(messageError, err);
            }
        }

        /// <summary>
        /// método Insert genérico para las entidades
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        // Insercion multiple a una entidad
        public virtual void InsertAll(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }

        /// <summary>
        /// Método Delete genérico para las entidades
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Método Delete genérico para las entidades
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
                DbSet.Attach(entityToDelete);

            DbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// método delete genérico, borra los datos para las entidades sobre la base de la condición .
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            var entities = DbSet.Where(where).ToList();
            entities.ForEach(x => Context.Entry(x).State = EntityState.Deleted);
        }

        /// <summary>
        /// Método de actualización Genérico para las entidades
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Merge(TEntity persisted, TEntity current)
        {
            Context.Entry(persisted).CurrentValues.SetValues(current);
        }


        #endregion
    }
}
