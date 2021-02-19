using ICDataManager.Library.Models;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public interface IIngredientNameData
    {
        Task<DBIngredientNameModel> GetById(int id);
        Task<DBIngredientNameModel> GetByName(string name);
    }
}