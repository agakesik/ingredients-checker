using ICDataManager.Library.Data;
using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientTypesController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public IngredientTypesController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<IngredientTypeModel>> Get()
        {
            IngredientTypeData typeData = new IngredientTypeData();
            var typesList = await typeData.GetAll(_dataAccess);

            return typesList;
        }
    }
}
