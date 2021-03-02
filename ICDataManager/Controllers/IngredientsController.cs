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
        private readonly IIngredientNameData _ingredientNameData;

        public IngredientsController(IIngredientData ingredientData,
                                     IIngredientTypeData ingredientsTypeData,
                                     IDisplayHelper displayHelper,
                                     IIngredientNameData ingredientNameData)
        {
            _ingredientData = ingredientData;
            _ingredientsTypeData = ingredientsTypeData;
            _displayHelper = displayHelper;
            _ingredientNameData = ingredientNameData;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var ingredientsList = await _ingredientData.GetAll();
            var typesList = await _ingredientsTypeData.GetAll();

            List<ManageIngredientModel> detailedIngredientsList = new List<ManageIngredientModel>();
            foreach (var ingredient in ingredientsList)
            {
                ManageIngredientModel manageIngredient = new ManageIngredientModel
                {
                    Id = ingredient.Id,
                    MainNameId = ingredient.MainNameId,
                    Details = ingredient.Details,
                    IngredientTypeId = ingredient.IngredientTypeId,
                    IsItCG = ingredient.IsItCG
                };

                var mainNameDetails = await _ingredientNameData.GetById(ingredient.MainNameId);
                manageIngredient.MainName = mainNameDetails.Name;

                if (ingredient.IngredientTypeId != 0)
                {
                    var type = typesList.Where(type => type.Id == ingredient.IngredientTypeId).FirstOrDefault();
                    if (type == null)
                    {
                        continue;
                    }
                    manageIngredient.IngredientType = type.Name;
                }

                detailedIngredientsList.Add(manageIngredient);
            }
            return View(detailedIngredientsList);
        }

        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _ingredientData.DeleteIngredient(id);

            return RedirectToAction("Index");
        }
    }
}
