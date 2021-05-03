using System;
using System.Collections.Generic;
using System.Text;

namespace ICDataManager.Library.Models
{
    public class ManageIngredientModel
    {
        public int Id { get; set; }
        public int MainNameId { get; set; }
        public string MainName { get; set; }
        public string Details { get; set; }
        public int IngredientTypeId { get; set; }
        public string IngredientType { get; set; }
        public bool IsItCG { get; set; }
    }
}
