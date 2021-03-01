using ICDataManager.Library.Data;
using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICDataManager.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientTypesController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;
        private readonly IIngredientTypeData _ingredientTypeData;

        public IngredientTypesController(IDataAccess dataAccess, IIngredientTypeData ingredientTypeData)
        {
            _dataAccess = dataAccess;
            _ingredientTypeData = ingredientTypeData;
        }

        [HttpGet]
        public async Task<List<DBIngredientTypeModel>> Get()
        {
            var typesList = await _ingredientTypeData.GetAll();

            return typesList;
        }
    }
}
