using ICDataManager.Library.Data;
using ICDataManager.Library.Helpers;
using ICDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICDataManager.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin/[controller]")]
    public class IngredientsController : Controller
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
        public async Task<IActionResult> Index()
        {

            var ingredientsList = await _ingredientData.GetAll();
            var typesList = await _ingredientsTypeData.GetAll();

            List<DisplayIngredientModel> detailedIngredientsList = await _displayHelper.GetIngrediensListForDisplay(ingredientsList, typesList);
            return View(ingredientsList);
        }
    }
}
