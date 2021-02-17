using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICWebUI.Models
{
    public class IngredientModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public IngredientTypeModel IngredientType { get; set; }
        public bool IsItCG { get; set; }
    }
}
