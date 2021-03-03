using ICDataManager.Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICDataManager.Models
{
    public class IngredientNameEditModel
    {
        public ManageIngredientNamesModel IngredientName { get; set; }
        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
    }
}
