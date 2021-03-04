using ICDataManager.Library.Data;
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

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var model = new IngredientCreateModel();

            var ingredientTypes = await _ingredientsTypeData.GetAll();
            foreach (var type in ingredientTypes)
            {
                model.IngredientTypes.Add(new SelectListItem { Value = type.Id.ToString(), Text = type.Name });
            }

            // TO DO: przy tworzeniu nowego powinno pozwolić wybrać tylko z nieprzypisanych
            var names = await _ingredientNameData.GetAll();
            foreach (var name in names)
            {
                model.IngredientNames.Add(new SelectListItem { Value = name.Id.ToString(), Text = name.Name });
                model.SelectedNames.Add(name.Name, false);
                System.Diagnostics.Debug.WriteLine (model.SelectedNames[name.Name]);
            }

            return View(model);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngredientCreateModel createModel)
        {
            // TO DO: create validation in Models
            if (createModel.Ingredient.MainNameId == 0)
            {
                Console.WriteLine("you have to specify main name");
                return RedirectToAction("create");
            }

            int newIngredientId = await _ingredientData.Create(createModel.Ingredient);
            // TO DO: update IngredientName - add IgredientId when assigned
            await _ingredientNameData.UpdateIngredientId(createModel.Ingredient.MainNameId, newIngredientId);
            foreach (var name in createModel.SelectedNames)
            {
                if (name.Value == true)
                {
                    var nameInformation = await _ingredientNameData.GetByName(name.Key);
                    await _ingredientNameData.UpdateIngredientId(nameInformation.Id, newIngredientId);
                }
            }

            return RedirectToAction("Details", new { id = newIngredientId });
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

            var names = await _ingredientNameData.GetByIngredient(model.Ingredient.Id);
            foreach (var name in names)
            {
                model.IngredientNames.Add(new SelectListItem { Value = name.Id.ToString(), Text = name.Name });
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
            // TO DO: update associated IngredientName to have null IngredientID 
            var ingredientNames = await _ingredientNameData.GetByIngredient(id);
            foreach (var name in ingredientNames)
            {
                await _ingredientNameData.UpdateIngredientId(name.Id);
            }
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
