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
    public class IngredientNamesController : Controller
    {
        private readonly IIngredientNameData _ingredientNameData;

        public IngredientNamesController(IIngredientNameData ingredientNameData)
        {
            _ingredientNameData = ingredientNameData;
        }
        
        public async Task<IActionResult> Index()
        {
            var names = await _ingredientNameData.GetAll();
            return View(names);
        }
    }
}
