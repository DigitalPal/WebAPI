using Dapper;
using DigitalPal.DataAccess.Interface;
using DigitalPal.DataAccess.Util;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess
{
    public class ProductionDA : DataAccessBase<Production>, IProductionDA
    {

        public ProductionDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Production;
        }

        public async Task AddProductionAsync(Production[] Productions)
        {
            await base.AddAsync(Productions);
        }

        public Production[] AddProduction(Production[] Productions)
        {
            return base.Add(Productions);
        }

        public Production GetProduction(string id)
        {
            List<Production> _production = new List<Production>();
            var sql = String.Format("SELECT Production.[Id], Production.[ProductionNumber], Production.[ProductionDate], Production.[NoOfMouldsCasted], Production.[Breakage], Production.[Remark]," +
                                    " Production.[CreatedOn], Production.[CreatedBy], Production.[ModifiedOn], Production.[ModifiedBy], Production.[PlantId], Production.[TenantId]," +
                                    " Production.[IsActive], ProductionDetails.ProductId AS ProductionDetails_ProductId, ProductionDetails.Quantity AS ProductionDetails_Quantity,"+
                                    " Product.Name AS ProductionDetails_ProductName, ProductionDetails.Breakage AS ProductionDetails_Breakage FROM {0} Production " +
                                    " INNER JOIN {1} ProductionDetails ON Production.Id = ProductionDetails.ProductionId LEFT OUTER JOIN"+
                                    " {2} Product ON Product.Id = ProductionDetails.ProductID WHERE ProductionDetails.IsActive = 1 AND Production.IsActive = 1 " +
                                    " AND Production.[Id] = @id",
                                    GetTableName(), TableNameConstants.dp_ProductionDetails, TableNameConstants.dp_Product);

            var dynamicProduction = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Production), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(ProductionDetails), new List<string> { "ProductId" });
            _production = (Slapper.AutoMapper.MapDynamic<Production>(dynamicProduction) as IEnumerable<Production>).ToList();
            return _production.FirstOrDefault();
        }

        public Dictionary<string, Production> GetProduction(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Production[] GetProduction(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Production[] GetAll()
        {
            List<Production> _production = new List<Production>();
            var sql = String.Format("SELECT Production.[Id], Production.[ProductionNumber], Production.[ProductionDate], Production.[NoOfMouldsCasted], " +
                                    " Production.[Remark], Production.[Breakage], Production.[CreatedOn], Production.[CreatedBy], Production.[ModifiedOn], Production.[ModifiedBy], " +
                                    " Production.[IsActive], ProductionDetails.ProductId AS ProductionDetails_ProductId, ProductionDetails.Quantity AS ProductionDetails_Quantity, " +
                                    " Product.Name AS ProductionDetails_ProductName, ProductionDetails.Breakage AS ProductionDetails_Breakage FROM {0} Production " +
                                    " INNER JOIN {1} ProductionDetails ON Production.Id = ProductionDetails.ProductionId LEFT OUTER JOIN {2} Product ON "+
                                    " Product.Id = ProductionDetails.ProductID WHERE " +
                                    " ProductionDetails.IsActive = 1 AND Production.IsActive = 1 ",
                                    GetTableName(), TableNameConstants.dp_ProductionDetails, TableNameConstants.dp_Product);

            var dynamicProduction = base.FindDynamic(sql, new { });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Production), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(ProductionDetails), new List<string> { "ProductId" });
            _production = (Slapper.AutoMapper.MapDynamic<Production>(dynamicProduction) as IEnumerable<Production>).ToList();

            return _production.ToArray();
        }

        public ProductionReport[] Search(ProductionReport productionReport)
        {
            List<ProductionReport> _production = new List<ProductionReport>();
            var sql = String.Format("SELECT ROW_NUMBER() Over (Order by Production.Id) As [SrNum], Production.[Id], Production.[ProductionNumber], Production.[ProductionDate], Production.[NoOfMouldsCasted], " +
                                    " Production.[Remark], ProductionDetails.[Breakage], Production.[CreatedOn], Production.[CreatedBy], Production.[ModifiedOn], Production.[ModifiedBy], " +
                                    " Production.[IsActive], ProductionDetails.ProductId AS ProductionDetails_ProductId, ProductionDetails.Quantity AS ProductionDetails_Quantity, " +
                                    " Product.Name AS ProductionDetails_ProductName, ProductionDetails.Breakage AS ProductionDetails_Breakage FROM {0} Production " +
                                    " INNER JOIN {1} ProductionDetails ON Production.Id = ProductionDetails.ProductionId LEFT OUTER JOIN {2} Product ON " +
                                    " Product.Id = ProductionDetails.ProductID WHERE " +
                                    " ProductionDetails.IsActive = 1 AND Production.IsActive = 1 ",
                                    GetTableName(), TableNameConstants.dp_ProductionDetails, TableNameConstants.dp_Product);
            #region Filters
            
            if(!string.IsNullOrEmpty(productionReport.ProductName))
            {
                sql += " AND Product.Name LIKE '%" + productionReport.ProductName + "%' ";
            }
            if(productionReport.StartDate != null)
            {
                sql += " AND Production.[ProductionDate] >= '" + productionReport.StartDate + "'";
            }
            if (productionReport.EndDate != null)
            {
                sql += " AND Production.[ProductionDate] <= '" + productionReport.EndDate + "'";
            }

            #endregion

            var dynamicProduction = base.FindDynamic(sql, new { });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(ProductionReport), new List<string> { "SrNum" });
            _production = (Slapper.AutoMapper.MapDynamic<ProductionReport>(dynamicProduction) as IEnumerable<ProductionReport>).ToList();
            return _production.ToArray();
        }

        public Production[] GetByIds(IEnumerable<Guid> Ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsActive = 1", GetTableName());
            return base.FindByTempTableIds(sql, Ids).ToArray();
        }

        public string GetEntityName()
        {
            return GetTableName();
        }

        public string[] GetColumns()
        {
            PropertyInfo[] props = Mapping(new Production()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Production item)
        {
            return new
            {
                item.Id,
                item.ProductionNumber,
                item.Breakage,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.NoOfMouldsCasted,
                item.ProductionDate,
                item.Remark,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.PlantId
            };
        }

        public Production[] UpdateProduction(Production[] Productions)
        {
            if (Productions.Any())
            {
                base.Update(Productions);
            }

            return Productions;
        }

        public Production[] DeleteProduction(string id)
        {
            if (id != null)
            {
                string[] ids = { id };
                base.DeleteByDbId(ids);
            }

            return null;
        }

        public string GetMaxNumber()
        {
            string result = string.Empty;
            using (var dbConnection = _sqlConnection)
            {
                var sql = string.Format("SELECT MAX(Id) FROM {0}", TableNameConstants.dp_Production);

               var output =  dbConnection.Query(sql);
                result = output.ToString();
            }

                return result;
        }
    }
}
