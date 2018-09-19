using Dapper;
using DigitalPal.DataAccess.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DigitalPal.DataAccess.Util
{
    public class LookupHelper : ILookupHelper
    {
        private readonly ISqlDatabaseSettings _sqlDataBaseSettings;

        internal IDbConnection _sqlConnection
        {
            get { return new SqlConnection(_sqlDataBaseSettings.ConnectionString); }
        }

        public LookupHelper(ISqlDatabaseSettings sqlDataBaseSettings)
        {
            _sqlDataBaseSettings = sqlDataBaseSettings;
        }

        public dynamic[] GetFilteredEntities(int limit, string sortProperty, bool sortDescending, string searchProperty, string searchText, string tableName, string[] columns)
        {
            var columnSelection = string.Join(" ,", columns);
            var query = string.Format(" SELECT TOP {0} {1} FROM {2} WHERE Active = 1 AND {3} LIKE '{4}%' ", limit, columnSelection, tableName, searchProperty, searchText);

            if (!string.IsNullOrEmpty(sortProperty))
            {
                query += " ORDER BY " + sortProperty;
            }

            if (sortDescending)
            {
                query += " DESC ";
            }

            using (var dbConnection = _sqlConnection)
            {
                dbConnection.Open();
                return dbConnection.Query(query).ToArray();
            }
        }
    }
}