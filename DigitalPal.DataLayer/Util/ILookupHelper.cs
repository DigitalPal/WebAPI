namespace DigitalPal.DataAccess.Util
{
    public interface ILookupHelper
    {
        dynamic[] GetFilteredEntities(int limit, string sortProperty, bool sortDescending, string searchProperty, string searchText, string tableName, string[] columns);
    }
}