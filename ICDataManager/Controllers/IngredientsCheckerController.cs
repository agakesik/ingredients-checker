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

        [HttpPost]
        public async Task<CheckedIngredientsModel> PostIngredientsNameForChecking(string[] ingredientsNames)
        {
            if (ingredientsNames.GetLength(0) == 0)
            {
                throw new ArgumentNullException("ingredientName", "list of names to check is empty");
            }

            var dbIngredientsList = new List<DBIngredientModel>();
            var notFoundNames = new List<string>();
            foreach (var name in ingredientsNames)
            {
                var dbIngredient = await _ingredientData.GetByName(name);

                if (dbIngredient == null)
                {
                    notFoundNames.Add(name);
                    continue;
                }
                dbIngredientsList.Add(dbIngredient);
            }

            var typesList = await _ingredientsTypeData.GetAll();

            List<DisplayIngredientModel> detailedIngredientsList = _displayHelper.GetIngrediensListForDisplay(dbIngredientsList, typesList);

            var output = new CheckedIngredientsModel
            {
                IngredientsList = detailedIngredientsList,
                NotFoundNames = notFoundNames
            };


            return output;

        }
    }
}
