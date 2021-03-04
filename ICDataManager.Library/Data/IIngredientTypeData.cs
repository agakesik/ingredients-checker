using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public interface IIngredientTypeData
    {
        Task<int> Create(DBIngredientTypeModel ingredientType);
        Task<int> Delete(int id);
        Task<List<DBIngredientTypeModel>> GetAll();
    }
}