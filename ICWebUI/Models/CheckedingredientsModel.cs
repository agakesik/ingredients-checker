using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICWebUI.Models
{
    public class CheckedingredientsModel
    {
        public List<IngredientModel> IngredientsList { get; set; }
        public List<string> NotFoundNames { get; set; }
    }
}
