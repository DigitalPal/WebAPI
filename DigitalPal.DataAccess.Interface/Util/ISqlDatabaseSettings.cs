using System;

namespace DigitalPal.DataAccess.Interface
{
    public interface ISqlDatabaseSettings
    {
        string ConnectionString { get;set;}

        string SchemaName { get; set; }
    }
}
