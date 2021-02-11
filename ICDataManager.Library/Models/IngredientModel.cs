using System;
using System.Collections.Generic;
using System.Text;

namespace ICDataManager.Library.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int IngredientTypeId { get; set; }
        public bool isItCG { get; set; }
    }
}
