using ICDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public interface IIngredientNameData
    {
        Task<int> DeleteName(int id);
        Task<List<DBIngredientNameModel>> GetAll();
        Task<DBIngredientNameModel> GetById(int id);
        Task<List<DBIngredientNameModel>> GetByIngredient(int ingredientId);
        Task<DBIngredientNameModel> GetByName(string name);
        Task<int> Create(string name);
        Task<int> Create(DBIngredientNameModel nameModel);
        Task<int> Update(ManageIngredientNamesModel editedInformation);
        Task<int> UpdateIngredientId(int id);
        Task<int> UpdateIngredientId(int id, int ingredientId);
    }
}