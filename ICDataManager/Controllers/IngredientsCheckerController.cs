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
        private readonly IIngredientNameData _ingredientNameData;

        public IngredientsCheckerController(IIngredientData ingredientData, IDisplayHelper displayHelper, IIngredientTypeData ingredientsTypeData, IIngredientNameData ingredientNameData)
        {
            _ingredientData = ingredientData;
            _displayHelper = displayHelper;
            _ingredientsTypeData = ingredientsTypeData;
            _ingredientNameData = ingredientNameData;
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
                // TODO: tutaj trzeba zmienić szukanie po nazwie
                var ingredientName = await _ingredientNameData.GetByName(name);


                if (ingredientName == null)
                {
                    notFoundNames.Add(name);
                    continue;
                }

                var dbIngredient = await _ingredientData.GetById(ingredientName.IngredientId);
                dbIngredientsList.Add(dbIngredient);
            }

            var typesList = await _ingredientsTypeData.GetAll();

            List<DisplayIngredientModel> detailedIngredientsList = await _displayHelper.GetIngrediensListForDisplay(dbIngredientsList, typesList);

            var output = new CheckedIngredientsModel
            {
                IngredientsList = detailedIngredientsList,
                NotFoundNames = notFoundNames
            };


            return output;

        }
    }
}
