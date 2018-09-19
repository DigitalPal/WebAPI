using DigitalPal.DataAccess.Interface;

namespace DigitalPal.DataAccess.Util
{
    public class SqlDatabaseSettings : ISqlDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string SchemaName { get; set; }
    }
}
