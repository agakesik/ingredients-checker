using ICDataManager.Library.Data;
using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Helpers;
using ICDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public IngredientsController(IIngredientData ingredientData,
                                     IIngredientTypeData ingredientsTypeData,
                                     IDisplayHelper displayHelper)
        {
            _ingredientData = ingredientData;
            _ingredientsTypeData = ingredientsTypeData;
            _displayHelper = displayHelper;
        }

        [HttpGet]
        public async Task<List<DisplayIngredientModel>> GetAllIngredientsWithTheirTypes()
        {

            var  ingredientsList = await _ingredientData.GetAll();
            var typesList = await _ingredientsTypeData.GetAll();

            List<DisplayIngredientModel> detailedIngredientsList = _displayHelper.GetIngrediensListForDisplay(ingredientsList, typesList);



            return detailedIngredientsList;
        }

    }
}
