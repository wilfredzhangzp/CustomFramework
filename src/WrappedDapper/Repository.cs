using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DapperExtensions;
using DapperExtensions.Mapper;

namespace WrappedDapper
{
    public class Repository <T> where T:class 
    {
        protected IDatabase Db;

        private IDbBaseFixture _dbBaseFixture;

        public Repository()
        {
            _dbBaseFixture = new SqliteBaseFixture();
            Db = _dbBaseFixture.Db;
        }


        public bool HasActiveTransaction
        {
            get { throw new NotImplementedException(); }
        }

        public IDbConnection Connection
        {
            get { return Db.Connection; }
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            Db.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            Db.Commit();
        }

        public void Rollback()
        {
            Db.Rollback();
        }

        public void RunInTransaction(Action action)
        {
            Db.RunInTransaction(action);
        }

        public T RunInTransaction(Func<T> func)
        {
            return Db.RunInTransaction(func);
        }

        public T Get(dynamic id, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Db.Get<T>(id, transaction, commandTimeout);
        }

        public T Get(dynamic id, int? commandTimeout = null) 
        {
            return Db.Get<T>(id, commandTimeout);
        }

        public void Insert(IEnumerable<T> entities, IDbTransaction transaction, int? commandTimeout = null) 
        {
            Db.Insert<T>(entities, transaction, commandTimeout);
        }

        public void Insert(IEnumerable<T> entities, int? commandTimeout = null) 
        {
            Db.Insert<T>(entities, commandTimeout);
        }

        public dynamic Insert(T entity, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Db.Insert(entity, transaction, commandTimeout);
        }

        public dynamic Insert(T entity, int? commandTimeout = null)
        {
            return Db.Insert(entity, commandTimeout);
        }

        public bool Update(T entity, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Db.Update(entity, transaction, commandTimeout);
        }

        public bool Update(T entity, int? commandTimeout = null) 
        {
            return Db.Update<T>(entity, commandTimeout);
        }

        public bool Delete(T entity, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Db.Delete(entity, transaction, commandTimeout);
        }

        public bool Delete(T entity, int? commandTimeout = null)
        {
            return Db.Delete(entity, commandTimeout);
        }

        public bool Delete(object predicate, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Db.Delete(predicate, transaction, commandTimeout);
        }

        public bool Delete(object predicate, int? commandTimeout = null)
        {
            return Db.Delete(predicate, commandTimeout);
        }

        public IEnumerable<T> GetList(object predicate, IList<ISort> sort, IDbTransaction transaction, int? commandTimeout = null,
            bool buffered = true)
        {
            return Db.GetList<T>(predicate, sort, transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetList(object predicate = null, IList<ISort> sort = null, int? commandTimeout = null, bool buffered = true)
        {
            return Db.GetList<T>(predicate, sort, commandTimeout, buffered);
        }

        public IEnumerable<T> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, IDbTransaction transaction,
            int? commandTimeout = null, bool buffered = true) 
        {
            return Db.GetPage<T>(predicate, sort, page, resultsPerPage, transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage, int? commandTimeout = null,
            bool buffered = true)
        {
            return Db.GetPage<T>(predicate, sort, page, resultsPerPage, commandTimeout, buffered);
        }

        public IEnumerable<T> GetSet(object predicate, IList<ISort> sort, int firstResult, int maxResults, IDbTransaction transaction,
            int? commandTimeout, bool buffered)
        {
            return Db.GetSet<T>(predicate, sort, firstResult, maxResults, transaction, commandTimeout, buffered);
        }

        public IEnumerable<T> GetSet(object predicate, IList<ISort> sort, int firstResult, int maxResults, int? commandTimeout, bool buffered)
        {
            return Db.GetSet<T>(predicate, sort, firstResult, maxResults, commandTimeout, buffered);
        }

        public int Count(object predicate, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Db.Count<T>(predicate, transaction, commandTimeout);
        }

        public int Count(object predicate, int? commandTimeout = null) 
        {
            return Db.Count<T>(predicate, commandTimeout);
        }

        public IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, IDbTransaction transaction, int? commandTimeout = null)
        {
            return Db.GetMultiple(predicate, transaction, commandTimeout);
        }

        public IMultipleResultReader GetMultiple(GetMultiplePredicate predicate, int? commandTimeout = null)
        {
            return Db.GetMultiple(predicate, commandTimeout);
        }

        public void ClearCache()
        {
            Db.ClearCache();
        }

        public Guid GetNextGuid()
        {
            return Db.GetNextGuid();
        }

        public IClassMapper GetMap() 
        {
            return Db.GetMap<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Db.GetList<T>();
        }
    }
}
