﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ICDataManager.Library.Models
{
    public class DBIngredientModel
    {
        public int Id { get; set; }
        public int MainNameId { get; set; }
        public string Details { get; set; }
        public int IngredientTypeId { get; set; }
        public bool IsItCG { get; set; }
    }
}
