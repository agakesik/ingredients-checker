using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public interface IIngredientTypeData
    {
        Task<List<DBIngredientTypeModel>> GetAll();
    }
}