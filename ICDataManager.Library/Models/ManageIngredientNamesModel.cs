using System;
using System.Collections.Generic;
using System.Text;

namespace ICDataManager.Library.Models
{
    public class ManageIngredientNamesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IngredientId { get; set; }
        public string IngredientMainName{ get; set; }
    }
}
