using ICDataManager.Library.Data;
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

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var model = new DBIngredientTypeModel();

            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DBIngredientTypeModel ingredientType)
        {
            int newTypeId = await _ingredientsTypeData.Create(ingredientType);

            // TO DO: redirect to display
            return RedirectToAction("Index");
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
