using Demo_1.Data;
using Demo_1.Entities;
using System;

namespace Demo_1.Services
{
    public class RepositoryService
    {
        private readonly DemoDbContext db;

        public RepositoryService()
        {
            db = new DemoDbContext();

            db.Database.EnsureCreated();
        }

        public bool UpdateModels(IList<CoronaModel> actualModels)
        {
            var savedModels = db.CoronaModels.ToList();

            foreach (var actualModel in actualModels)
            {
                var savedModel = savedModels.FirstOrDefault(m => m.Country == actualModel.Country);

                if (savedModel == null)
                {
                    db.CoronaModels.Add(actualModel);
                }
                else
                {
                    savedModel.TotalCases = actualModel.TotalCases;
                    savedModel.ActiveCases = actualModel.ActiveCases;
                    savedModel.TotalTests = actualModel.TotalTests;
                }
            }

            //DeleteOutdatedModels(savedModels, actualModels);

            var rowsAffected = db.SaveChanges();

            return rowsAffected > 0;
        }

        private void DeleteOutdatedModels(List<CoronaModel> savedModels, IList<CoronaModel> actualModels)
        {
            throw new NotImplementedException();
        }

        public IList<CoronaModel> GetModelsForRegion(string regionName = "")
        {
            var models = db.CoronaModels.AsQueryable();

            if (!string.IsNullOrEmpty(regionName) && regionName != Region.All.Name)
            {
                models = models.Where(m => m.Continent == regionName);
            }

            var result = models.ToList();

            return result;
        }

        public IList<CoronaModel> _GetModelsForRegion(string region = "")
        {
            var models = db.CoronaModels.ToList();

            return models;
        }

    }
}

