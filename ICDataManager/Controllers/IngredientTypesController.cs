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
    [Route("admin/[controller]")]
    public class IngredientTypesController : Controller
    {
        private readonly IIngredientTypeData _ingredientsTypeData;
        private readonly IIngredientData _ingredientData;

        public IngredientTypesController(IIngredientTypeData ingredientsTypeData, IIngredientData ingredientData)
        {
            _ingredientsTypeData = ingredientsTypeData;
            _ingredientData = ingredientData;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var typesList = await _ingredientsTypeData.GetAll();

            return View(typesList);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var model = new DBIngredientTypeModel();

            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DBIngredientTypeModel ingredientType)
        {
            int newTypeId = await _ingredientsTypeData.Create(ingredientType);

            return RedirectToAction("Details", new { id = newTypeId });
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(int id)
        {
            var type = await _ingredientsTypeData.GetById(id);

            return View(type);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(DBIngredientTypeModel type)
        {
            await _ingredientsTypeData.Update(type);
            return RedirectToAction("Details", new { type.Id });
        }


        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            var ingredients = await _ingredientData.GetByType(id);
            foreach (var ingredient in ingredients)
            {
                await _ingredientData.UpdateTypeId(ingredient.Id);
            }

            await _ingredientsTypeData.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
