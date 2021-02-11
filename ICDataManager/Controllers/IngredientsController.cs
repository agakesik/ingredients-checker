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
    public class IngredientsController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public IngredientsController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<IngredientModel>> Get()
        {
            IngredientData ingredientData = new IngredientData();
            var  ingredientsList = await ingredientData.GetAll(_dataAccess);

            if (ingredientsList == null)
            {
                Console.WriteLine("pusta list");
            }
            return ingredientsList;
        }
    }
}
