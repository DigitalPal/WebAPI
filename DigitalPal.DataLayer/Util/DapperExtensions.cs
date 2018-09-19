using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Util
{
    public static class DapperExtensions
    {
        public static T Insert<T>(this IDbConnection cnn, string tableName, dynamic param)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetInsertQuery(tableName, param), param);
            return result.First();
        }

        public static void InsertMany(this IDbConnection cnn, string tableName, dynamic[] paramValues)
        {
            var result = SqlMapper.Execute(cnn, DynamicQuery.GetInsertQuery(tableName, paramValues[0]), paramValues);
        }

        public static async Task InsertManyAsync(this IDbConnection cnn, string tableName, dynamic[] paramValues)
        {
            await SqlMapper.ExecuteAsync(cnn, DynamicQuery.GetInsertQuery(tableName, paramValues[0]), paramValues);
        }

        public static int ExecuteCommands(this IDbConnection cnn, string commands, object paramValues)
        {
            var cnt = -1;
            using (var transaction = cnn.BeginTransaction())
            {
                cnt = cnn.Execute(commands, paramValues, transaction);
                transaction.Commit();
            }
            return cnt;
        }

        public static void Update(this IDbConnection cnn, string tableName, dynamic param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }

        public static void UpdateMany(this IDbConnection cnn, string tableName, dynamic[] param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param[0]), param);
        }

        public static Task UpdateManyAsync(this IDbConnection cnn, string tableName, dynamic[] param)
        {
            return SqlMapper.ExecuteAsync(cnn, DynamicQuery.GetUpdateQuery(tableName, param[0]), param);
        }

        public static IEnumerable<T> GetPaging<T>(this IDbConnection cnn, string tableName, int pageNumber, int pageSize, string sortProperty, bool sortDescending, string searchText)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetPagingQuery(tableName, pageNumber, pageSize, sortProperty, sortDescending, searchText));
            return result;
        }
    }
}