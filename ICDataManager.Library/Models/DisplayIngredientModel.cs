using System;
using System.Collections.Generic;
using System.Text;

namespace ICDataManager.Library.Models
{
    public class DisplayIngredientModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public DisplayIngredientTypeModel IngredientType { get; set; }
        public bool IsItCG { get; set; }
    }
}
