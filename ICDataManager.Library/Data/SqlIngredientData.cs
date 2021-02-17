using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public class SqlIngredientData : IIngredientData
    {
        private readonly IDataAccess _dataAccess;

        public SqlIngredientData(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<List<DBIngredientModel>> GetAll()
        {
            var ingredientsList = _dataAccess.LoadData<DBIngredientModel, dynamic>("spIngredient_GetAll", new { }, "ICData");

            return ingredientsList;

        }

        public async Task<DBIngredientModel> GetByName(string name)
        {
            var ingredient = await _dataAccess.LoadData<DBIngredientModel, dynamic>("spIngredient_GetByName", new { Name = name }, "ICData");

            return ingredient.FirstOrDefault();
        }
    }
}
