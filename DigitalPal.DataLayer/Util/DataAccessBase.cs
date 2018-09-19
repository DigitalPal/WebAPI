using Dapper;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Util
{
    public abstract class DataAccessBase<T> : IDataAccessBase<T> where T : BaseEntity
    {
        protected readonly ISqlDatabaseSettings _sqlDataBaseSettings;

        public DataAccessBase(ISqlDatabaseSettings sqlDataBaseSettings)
        {
            _sqlDataBaseSettings = sqlDataBaseSettings;
        }

        internal IDbConnection _sqlConnection
        {
            get { return new SqlConnection(string.Format("Server={0};Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Connection Timeout=300;", "localhost\\SQLEXPRESS", "POC", "Apttusadmin", "Apttu$admin123")); }
        }

        private string _tableName
        {
            get { return GetTableName(); }
        }

        public virtual T[] Add(T[] items)
        {
            if (items == null || items.Length == 0)
                return items;

            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                dbConnection.InsertMany(_tableName, items.Select(x => (dynamic)Mapping(x)).ToArray());
            }
            return items;
        }

        public virtual S ExecuteScalar<S>(string query, object paramValues)
        {
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.ExecuteScalar<S>(query, paramValues);
            }
        }

        public virtual void Update(T item)
        {
            var parameters = (object)Mapping(item);
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                dbConnection.Update(_tableName, parameters);
            }
        }

        public virtual void Remove(T item)
        {
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE " + _tableName + " SET IsActive = 0 WHERE ID=@ID", new { ID = item.Id });
            }
        }

        public virtual List<T> FindByIds(List<Guid> ids)
        {
            if (ids == null || ids.Count == 0)
                return new List<T>();

            ids = ids.Distinct().ToList();

            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                var filter = string.Empty;
                foreach (var id in ids)
                {
                    filter += "'" + id + "'";
                    if (ids.Last() != id)
                        filter += ",";
                }

                return dbConnection.Query<T>(string.Format("SELECT * FROM {0} WHERE ID in ({1}) AND IsActive = 1", _tableName, filter))
                        .ToList();
            }
        }

        public virtual T FindById(Guid id)
        {
            return FindByIds(new List<Guid> { id }).SingleOrDefault();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> items;

            // extract the dynamic sql query and parameters from predicate
            var result = DynamicQuery.GetDynamicQuery(_tableName, predicate);

            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.Query<T>(result.Sql, (object)result.Param);
            }

            return items;
        }

        public async Task AddAsync(T[] items)
        {
            if (items == null || items.Length == 0)
                return;

            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                await dbConnection.InsertManyAsync(_tableName, items.Select(x => (dynamic)Mapping(x)).ToArray());
            }
        }

        public virtual int Count(string query)
        {
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                var res = dbConnection.ExecuteScalar<int>(query);
                return res;
            }

            return 0;
        }

        public virtual IEnumerable<T> Find(string query)
        {
            IEnumerable<T> items;
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.Query<T>(query);
            }

            return items;
        }

        public virtual IEnumerable<T> Find(string query, object paramValues)
        {
            IEnumerable<T> items;
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.Query<T>(query, paramValues, commandTimeout: 9999);
            }

            return items;
        }

        public virtual IEnumerable<T> FindByTempTableIds(string query, IEnumerable<Guid> Ids)
        {
            IEnumerable<T> items;
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                dbConnection.Execute("CREATE TABLE #tempIds(Id uniqueidentifier not null);");
                while (Ids.Any())
                {
                    var idsToInsert = Ids.Take(1000);
                    Ids = Ids.Skip(1000).ToList();

                    StringBuilder insertQuery = new StringBuilder("INSERT INTO #tempIds VALUES ('");
                    insertQuery.Append(string.Join("'),('", idsToInsert));
                    insertQuery.Append("');");

                    dbConnection.Execute(insertQuery.ToString());
                }
                query = query.Replace("@Ids", "select distinct Id from #tempIds");
                items = dbConnection.Query<T>(query, null, commandTimeout: 9999);
            }

            return items;
        }

        public virtual IEnumerable<dynamic> FindDynamic(string query, object paramValues)
        {
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.Query(query, paramValues);
            }
        }

        public virtual IEnumerable<T> FindAll()
        {
            IEnumerable<T> items;

            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.Query<T>("SELECT * FROM WHERE IsActive = 1" + _tableName);
            }

            return items;
        }

        public virtual void DeleteByGuid(Guid[] dbIds)
        {
            using (IDbConnection dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                var items = dbIds.Select(x => new { ID = x });
                SqlMapper.Execute(dbConnection, "UPDATE " + _tableName + " SET IsActive = 0 WHERE ID=@ID", items);
            }
        }

        public virtual IEnumerable<T> FindPage(int pageNumber, int pageSize, string sortProperty, bool sortDescending,
            Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> items;

            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                var queryResult = DynamicQuery.GetDynamicPageQuery(_tableName, pageNumber, pageSize, sortProperty,
                    sortDescending, expression);
                items = dbConnection.Query<T>(queryResult.Sql, (object)queryResult.Param);
            }

            return items;
        }

        internal abstract string GetTableName();

        internal virtual dynamic Mapping(T item)
        {
            // override this method in specific implementation to select data which needs to be sent to SQL DB
            return item;
        }

        public virtual int ExecuteCommands(string commands, object paramValus)
        {
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.ExecuteCommands(commands, paramValus);
            }
        }

        public virtual IEnumerable<dynamic> ExecuteQuery(string query, object paramValus)
        {
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.Query(query, paramValus);
            }
        }

        public virtual IEnumerable<T> ExecuteQuery<T>(string query, object paramValus)
        {
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                var result = dbConnection.Query<T>(query, paramValus);
                return result;
            }
        }

        private static string GetColumnQueryForIndex(string[] columns, int index)
        {
            return string.Concat("( ", string.Join(", ", columns.Select(col => string.Concat("@", col, index))), "  )");
        }

        private static PropertyInfo[] GetEntityProperties(dynamic entity)
        {
            return entity.GetType().GetProperties();
        }

        private dynamic[] GetEntities(T[] items)
        {
            return items.Select(x => Mapping(x)).ToArray();
        }

        private static string[] GetColumnNames(PropertyInfo[] eProperties)
        {
            return eProperties.Select(prop => prop.Name).Where(name => name != "Id").ToArray();
        }

        public virtual void Update(T[] item)
        {
            var parameters = item.Select(x => Mapping(x)).ToArray();
            if (parameters.Count() > 0)
            {
                using (var dbConnection = _sqlConnection)
                {
                    dbConnection.Open();
                    dbConnection.UpdateMany(_tableName, parameters);
                }
            }
        }

        public virtual async Task UpdateAsync(T[] item)
        {
            try
            {
                await UpdateWithTask(item);
            }
            catch (SqlException)
            {
                await UpdateWithTask(item);
            }
        }

        private async Task UpdateWithTask(T[] item)
        {
            var parameters = item.Select(x => Mapping(x)).ToArray();
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                await dbConnection.UpdateManyAsync(_tableName, parameters);
            }
        }

        public virtual void DeleteByDbId(string[] dbIds)
        {
            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                var items = dbIds.Select(x => new { ID = x });
                dbConnection.Execute("UPDATE " + _tableName + " SET IsActive = 0 WHERE ID=@ID", items);
            }
        }

        public virtual IEnumerable<T> GetPaging(int pageNumber, int pageSize, string sortProperty, bool sortDescending, string searchText)
        {
            IEnumerable<T> items = null;

            using (IDbConnection dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                items = dbConnection.GetPaging<T>(_tableName, pageNumber, pageSize, sortProperty, sortDescending, searchText);
            }

            return items;
        }
    }
}
