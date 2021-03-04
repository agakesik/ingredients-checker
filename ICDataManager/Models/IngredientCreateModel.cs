using ICDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICDataManager.Models
{
    public class IngredientCreateModel
    {
        public DBIngredientModel Ingredient { get; set; }
        public List<SelectListItem> IngredientTypes { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> IngredientNames { get; set; } = new List<SelectListItem>();
    }
}
