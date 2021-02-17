using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public interface IIngredientData
    {
        Task<List<DBIngredientModel>> GetAll(IDataAccess dataAccess);
    }
}