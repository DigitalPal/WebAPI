using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class PlantRepository : IPlantRepository
    {
        private IPlantDA _PlantDA;

        public PlantRepository(IPlantDA PlantDA)
        {
            _PlantDA = PlantDA;
        }

        public async Task AddPlantAsync(Plant[] Plants)
        {
            await _PlantDA.AddPlantAsync(Plants);
        }
        public Plant[] AddPlants(Plant[] Plants)
        {
            return _PlantDA.AddPlants(Plants);
        }

        public Plant GetPlant(string id)
        {
            return _PlantDA.GetPlant(id);
        }

        public Dictionary<string, Plant> GetPlants(string[] ids)
        {
            return _PlantDA.GetPlants(ids);
        }

        public Plant[] GetPlants(IEnumerable<Guid?> ids)
        {
            return _PlantDA.GetPlants(ids);
        }

        public Plant[] GetAll()
        {
            return _PlantDA.GetAll();
        }


        public Plant[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _PlantDA.GetByIds(Ids);
        }

        public Plant[] UpdatePlants(Plant[] Plants)
        {
            return _PlantDA.UpdatePlants(Plants);
        }

        public Plant[] DeletePlants(string id)
        {
            return _PlantDA.DeletePlants(id);
        }
    }
}
