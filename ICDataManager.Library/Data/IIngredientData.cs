using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public interface IIngredientData
    {
        Task<int> Create(DBIngredientModel ingredient);
        Task<int> DeleteIngredient(int id);
        Task<List<DBIngredientModel>> GetAll();
        Task<DBIngredientModel> GetById(int id);
        Task<int> Update(ManageIngredientModel editedInformation);
    }
}