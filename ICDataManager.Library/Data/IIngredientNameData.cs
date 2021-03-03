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
        Task<DBIngredientNameModel> GetByName(string name);
        Task<int> SaveName(string name);
        Task<int> Update(ManageIngredientNamesModel editedInformation);
    }
}