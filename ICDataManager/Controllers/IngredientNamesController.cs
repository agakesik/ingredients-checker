using ICDataManager.Library.Data;
using ICDataManager.Library.Models;
using ICDataManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICDataManager.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("Admin/[controller]")]
    public class IngredientNamesController : Controller
    {
        private readonly IIngredientNameData _ingredientNameData;
        private readonly IIngredientData _ingredientData;

        public IngredientNamesController(IIngredientNameData ingredientNameData, IIngredientData ingredientData)
        {
            _ingredientNameData = ingredientNameData;
            _ingredientData = ingredientData;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var names = await _ingredientNameData.GetAll();
            var ingredients = await _ingredientData.GetAll();

            var namesForDisplay = new List<ManageIngredientNamesModel>();
            foreach (var name in names)
            {
                var newName = new ManageIngredientNamesModel
                {
                    Id = name.Id,
                    Name = name.Name,
                    IngredientId = name.IngredientId
                };

                if (name.IngredientId > 0)
                {
                    var assignedIngredient = await _ingredientNameData.GetById(ingredients.Where(x => x.Id == name.IngredientId).FirstOrDefault().MainNameId);
                    newName.IngredientMainName = assignedIngredient.Name;
                }

                namesForDisplay.Add(newName);

            }

            namesForDisplay.Sort(delegate (ManageIngredientNamesModel x, ManageIngredientNamesModel y)
            {
                return x.IngredientId.CompareTo(y.IngredientId);
            });
            return View(namesForDisplay);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create(int id)
        {
            var ingredients = await _ingredientData.GetAll();
            IngredientNameCreateModel model = new IngredientNameCreateModel();

            foreach (var ingredient in ingredients)
            {
                var ingredientMainName = await _ingredientNameData.GetById(ingredient.MainNameId);
                model.Ingredients.Add(new SelectListItem { Value = ingredient.Id.ToString(), Text = ingredientMainName.Name });
            }

            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientNameCreateModel createModel)
        {
            int newIngredientNameId = await _ingredientNameData.Create(createModel.IngredientName);
            return RedirectToAction("Details", new { id = newIngredientNameId });
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(int id)
        {
            var ingredients = await _ingredientData.GetAll();
            var ingredientName = await _ingredientNameData.GetById(id);
            IngredientNameEditModel model = new IngredientNameEditModel();

            model.IngredientName = new ManageIngredientNamesModel
            {
                Id = ingredientName.Id,
                Name = ingredientName.Name,
                IngredientId = ingredientName.IngredientId
            };


            // TO DO: there must be cleaner way to do this
            if (model.IngredientName.IngredientId > 0)
            {
                var assignedIngredient = await _ingredientNameData.GetById(ingredients.Where(x => x.Id == model.IngredientName.IngredientId).FirstOrDefault().MainNameId);
                model.IngredientName.IngredientMainName = assignedIngredient.Name;
            }

            foreach (var ingredient in ingredients)
            {
                var ingredientMainName = await _ingredientNameData.GetById(ingredient.MainNameId);
                model.Ingredients.Add(new SelectListItem { Value = ingredient.Id.ToString(), Text = ingredientMainName.Name });
            }

            return View(model);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(IngredientNameEditModel editModel)
        {
            await _ingredientNameData.Update(editModel.IngredientName);
            return RedirectToAction("Details", new { id = editModel.IngredientName.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _ingredientNameData.DeleteName(id);

            return RedirectToAction("Index");
        }
    }
}
