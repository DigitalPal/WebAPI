using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IPlantDA
    {
        Task AddPlantAsync(Plant[] Plants);
        Plant[] AddPlants(Plant[] Plants);

        Plant GetPlant(string id);

        Dictionary<string, Plant> GetPlants(string[] ids);

        Plant[] GetPlants(IEnumerable<Guid?> ids);

        Plant[] GetAll();

        Plant[] GetByIds(IEnumerable<Guid> Ids);

        Plant[] UpdatePlants(Plant[] Plants);

        Plant[] DeletePlants(string id);
    }
}
