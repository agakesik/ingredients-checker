﻿using ICDataManager.Library.Data;
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
            names.Sort(delegate (DBIngredientNameModel x, DBIngredientNameModel y)
            {
                return x.IngredientId.CompareTo(y.IngredientId);
            });
            return View(names);
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(int id)
        {
            var ingredients = await _ingredientData.GetAll();

            IngredientNameEditModel model = new IngredientNameEditModel();
            model.IngredientName = await _ingredientNameData.GetById(id);


            // TO DO: there must be cleaner way to do this
            if (model.IngredientName.IngredientId > 0)
            {
                var assignedIngredient = await _ingredientNameData.GetById(ingredients.Where(x => x.Id == model.IngredientName.IngredientId).FirstOrDefault().MainNameId);
                model.AssignedIngredientMainName = assignedIngredient.Name;
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
            return RedirectToAction("Details", new { editModel.IngredientName.Id });
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