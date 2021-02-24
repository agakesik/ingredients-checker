using ICDataManager.Library.Data;
using ICDataManager.Library.DataAccess;
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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientData _ingredientData;
        private readonly IIngredientTypeData _ingredientsTypeData;
        private readonly IDisplayHelper _displayHelper;
        private readonly IIngredientNameData _ingredientNameData;

        public IngredientsController(IIngredientData ingredientData,
                                     IIngredientTypeData ingredientsTypeData,
                                     IDisplayHelper displayHelper,
                                     IIngredientNameData _ingredientNameData)
        {
            _ingredientData = ingredientData;
            _ingredientsTypeData = ingredientsTypeData;
            _displayHelper = displayHelper;
            this._ingredientNameData = _ingredientNameData;
        }

        [HttpGet]
        public async Task<List<DisplayIngredientModel>> Get()
        {

            var  ingredientsList = await _ingredientData.GetAll();
            var typesList = await _ingredientsTypeData.GetAll();

            List<DisplayIngredientModel> detailedIngredientsList = await _displayHelper.GetIngrediensListForDisplay(ingredientsList, typesList);



            return detailedIngredientsList;
        }

        [HttpPost("checker")]
        public async Task<CheckedIngredientsModel> CheckByNames(IEnumerable<string> names)
        {
            if (names == null || !names.Any())
            {
                throw new ArgumentNullException("names", "list of names to check is empty");
            }

            var dbIngredientsList = new List<DBIngredientModel>();
            var notFoundNames = new List<string>();
            foreach (var name in names)
            {
                var ingredientName = await _ingredientNameData.GetByName(name);


                if (ingredientName == null)
                {
                    notFoundNames.Add(name);
                    await _ingredientNameData.SaveName(name);
                    continue;
                }
                else if (ingredientName.IngredientId == 0)
                {
                    notFoundNames.Add(name);
                    continue;
                }

                var dbIngredient = await _ingredientData.GetById(ingredientName.IngredientId);

                // TODO: there has to be nicer way to get back Ingredients with their searched name, not MainName
                dbIngredient.MainNameId = ingredientName.Id;

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
