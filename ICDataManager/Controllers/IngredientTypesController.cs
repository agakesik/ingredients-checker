using ICDataManager.Library.Data;
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
    public class IngredientTypesController : Controller
    {
        private readonly IIngredientTypeData _ingredientsTypeData;

        public IngredientTypesController(IIngredientTypeData ingredientsTypeData)
        {
            _ingredientsTypeData = ingredientsTypeData;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var typesList = await _ingredientsTypeData.GetAll();

            return View(typesList);
        }

        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            // TO DO: change ingredientTypesId in Ingredients to null
            await _ingredientsTypeData.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
