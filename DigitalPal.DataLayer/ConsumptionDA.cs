using DigitalPal.DataAccess.Interface;
using DigitalPal.DataAccess.Util;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess
{
    public class ConsumptionDA : DataAccessBase<Consumption>, IConsumptionDA
    {

        public ConsumptionDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Consumption;
        }

        public async Task AddConsumptionAsync(Consumption[] Consumptions)
        {
            await base.AddAsync(Consumptions);
        }

        public Consumption[] AddConsumptions(Consumption[] Consumptions)
        {
            for (int i = 0; i < Consumptions.Length; i++)
            {
                Consumptions[i].Id = Guid.NewGuid();
            }
            return base.Add(Consumptions);
        }

        public Consumption GetConsumption(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Consumption> GetConsumptions(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Consumption[] GetConsumptions(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Consumption[] GetAll()
        {
            List<Consumption> _Consumption = new List<Consumption>();
            var sql = String.Format("SELECT CON.Id, RMD.Title AS RawMaterial, CON.RawMaterialId, CON.ConsumptionDate, CON.Quantity, CON.Remark FROM {0} CON " +
                                    " INNER JOIN {1} RMD ON CON.RawMaterialId = RMD.Id " +
                                    " WHERE RMD.IsActive = 1 AND CON.IsActive = 1 ",
                                    GetTableName(), TableNameConstants.dp_RawMaterialDetails);

            var dynamicConsumption = base.FindDynamic(sql, new { });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Consumption), new List<string> { "Id" });

            _Consumption = (Slapper.AutoMapper.MapDynamic<Consumption>(dynamicConsumption) as IEnumerable<Consumption>).ToList();

            return _Consumption.ToArray();
        }

        public ConsumptionReport[] Search(ConsumptionReport consumptionReport)
        {
            List<ConsumptionReport> _consumption = new List<ConsumptionReport>();
            var sql = String.Format("SELECT ROW_NUMBER() OVER (ORDER BY Consumption.Id) As [SrNum], Consumption.[ConsumptionDate], RawMaterial.[Title] AS RawMaterial, " +
                                    " Consumption.[Quantity],RawMaterial.[MeasureType] FROM {0} Consumption INNER JOIN {1} RawMaterial ON " +
                                    " Consumption.RawMaterialId = RawMaterial.Id WHERE Consumption.IsActive = 1 ",
                                    GetTableName(), TableNameConstants.dp_RawMaterialDetails);
            #region Filters

            if (!string.IsNullOrEmpty(consumptionReport.RawMaterial))
            {
                sql += " AND RawMaterial.Title  LIKE '%" + consumptionReport.RawMaterial + "%' ";
            }
            if (consumptionReport.StartDate != null)
            {
                sql += " AND Consumption.[ConsumptionDate] >= '" + consumptionReport.StartDate + "'";
            }
            if (consumptionReport.EndDate != null)
            {
                sql += " AND  Consumption.[ConsumptionDate] <= '" + consumptionReport.EndDate + "'";
            }

            #endregion

            var dynamicConsumption = base.FindDynamic(sql, new { });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(ConsumptionReport), new List<string> { "SrNum" });
            _consumption = (Slapper.AutoMapper.MapDynamic<ConsumptionReport>(dynamicConsumption) as IEnumerable<ConsumptionReport>).ToList();
            return _consumption.ToArray();
        }

        public Consumption[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new Consumption()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Consumption item)
        {
            return new
            {
                item.Id,
                item.ConsumptionDate,
                item.RawMaterialId,
                item.Remark,
                item.Quantity,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId
            };
        }

        public Consumption[] UpdateConsumptions(Consumption[] Consumptions)
        {
            if (Consumptions.Any())
            {
                base.Update(Consumptions);
            }

            return Consumptions;
        }

        public Consumption[] DeleteConsumptions(string id)
        {
            if (id != null)
            {
                string[] ids = { id };
                base.DeleteByDbId(ids);
            }

            return null;
        }
    }
}
