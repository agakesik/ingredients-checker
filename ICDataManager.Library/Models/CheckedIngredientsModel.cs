using System;
using System.Collections.Generic;
using System.Text;

namespace ICDataManager.Library.Models
{
    public class CheckedIngredientsModel
    {
        public List<DisplayIngredientModel> IngredientsList { get; set; }
        public List<string> NotFoundNames { get; set; }
    }
}
