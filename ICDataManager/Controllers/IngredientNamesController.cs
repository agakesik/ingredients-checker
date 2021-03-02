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
    public class IngredientNamesController : Controller
    {
        private readonly IIngredientNameData _ingredientNameData;

        public IngredientNamesController(IIngredientNameData ingredientNameData)
        {
            _ingredientNameData = ingredientNameData;
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _ingredientNameData.DeleteName(id);

            return RedirectToAction("Index");
        }
    }
}
