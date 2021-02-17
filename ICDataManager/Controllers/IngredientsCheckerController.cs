using ICDataManager.Library.Data;
using ICDataManager.Library.Helpers;
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
    public class IngredientsCheckerController : ControllerBase
    {
        private readonly IIngredientData _ingredientData;
        private readonly IDisplayHelper _displayHelper;
        private readonly IIngredientTypeData _ingredientsTypeData;

        public IngredientsCheckerController(IIngredientData ingredientData, IDisplayHelper displayHelper, IIngredientTypeData ingredientsTypeData)
        {
            _ingredientData = ingredientData;
            _displayHelper = displayHelper;
            _ingredientsTypeData = ingredientsTypeData;
        }

        [HttpGet]
        public async Task<List<DisplayIngredientModel>> GetIngredientsCheckByName(string[] ingredientsNames)
        {
            if (ingredientsNames.Length == 0)
            {
                throw new ArgumentNullException("ingredientName", "list to check is empty");
            }

            var dbIngredientsList = new List<DBIngredientModel>();
            foreach (var name in ingredientsNames)
            {
                var dbIngredient = await _ingredientData.GetByName(name);
                dbIngredientsList.Add(dbIngredient);
            }

            var typesList = await _ingredientsTypeData.GetAll();

            List<DisplayIngredientModel> detailedIngredientsList = _displayHelper.GetIngrediensListForDisplay(dbIngredientsList, typesList);


            return detailedIngredientsList;

        }
    }
}
