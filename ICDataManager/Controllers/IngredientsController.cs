﻿using ICDataManager.Library.Data;
using ICDataManager.Library.Helpers;
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

            List<ManageIngredientModel> detailedIngredientsList = new List<ManageIngredientModel>();
            foreach (var ingredient in ingredientsList)
            {
                ManageIngredientModel manageIngredient = await MapDbIngredientModelToManageIngredientModel(ingredient);

                detailedIngredientsList.Add(manageIngredient);
            }
            return View(detailedIngredientsList);
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(int id)
        {
            var dbIngredient = await _ingredientData.GetById(id);
            

            var model = new IngredientEditModel();
            model.Ingredient = await MapDbIngredientModelToManageIngredientModel(dbIngredient);

            var ingredientTypes = await _ingredientsTypeData.GetAll();
            foreach (var type in ingredientTypes)
            {
                model.IngredientTypes.Add(new SelectListItem { Value = type.Id.ToString(), Text = type.Name });
            }

            // TO DO: zamienić na .GetByIngredient
            var names = await _ingredientNameData.GetAll();
            foreach (var name in names)
            {
                if (name.IngredientId == model.Ingredient.Id)
                {
                    model.IngredientNames.Add(new SelectListItem { Value = name.Id.ToString(), Text = name.Name });
                }
            }

            return View(model);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(IngredientEditModel editedInformation)
        {
            await _ingredientData.Update(editedInformation.Ingredient);
            return RedirectToAction("Details", new { editedInformation.Ingredient.Id });
        }

        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _ingredientData.DeleteIngredient(id);

            return RedirectToAction("Index");
        }

        private async Task<ManageIngredientModel> MapDbIngredientModelToManageIngredientModel(DBIngredientModel ingredient)
        {
            var typesList = await _ingredientsTypeData.GetAll();

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
                if (type != null)
                {
                    manageIngredient.IngredientType = type.Name;
                }
                
            }

            return manageIngredient;
        }
    }
}
