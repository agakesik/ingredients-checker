using ExpectedObjects;
using ICDataManager.Library.Helpers;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace ICDataManager.Library.Test.Helpers
{
    public class DisplayHelperTest
    {
        //DisplayHelper _ingredientHelper;
        //List<DBIngredientTypeModel> _ingredientTypes;

        //public DisplayHelperTest()
        //{
        //    _ingredientHelper = new DisplayHelper();
        //    _ingredientTypes = new List<DBIngredientTypeModel>
        //    {
        //        new DBIngredientTypeModel
        //        {
        //            Id = 1,
        //            Name = "first",
        //            Details = "first type detils",
        //            Color = "color1"
        //        },
        //        new DBIngredientTypeModel
        //        {
        //            Id = 2,
        //            Name = "second",
        //            Details = "second type detils",
        //            Color = "color2"
        //        }
        //    };
        //}

        //public static IEnumerable<object[]> GetIngrediensListForDisplayData
        //{
        //    get
        //    {
        //        return new[]
        //    {
        //        new object[] 
        //        { 
        //            new DBIngredientModel
        //            {
        //                Id = 0,
        //                Name = "name",
        //                Details = "details",
        //                IngredientTypeId = 1,
        //                IsItCG = true
        //            },
        //            new DisplayIngredientModel()
        //            {
        //                Name = "name",
        //                Details = "details",
        //                IngredientType = new DisplayIngredientTypeModel
        //                {
        //                    Id = 1,
        //                    Name = "first",
        //                    Details = "first type detils",
        //                    Color = "color1"
        //                },
        //                IsItCG = true

        //            }
        //        },
        //        new object[]
        //        {
        //            new DBIngredientModel
        //            {
        //                Id = 0,
        //                Name = "name",
        //                Details = "details",
        //                IngredientTypeId = 0,
        //                IsItCG = true
        //            },
        //            new DisplayIngredientModel()
        //            {
        //                Name = "name",
        //                Details = "details",
        //                IngredientType = new DisplayIngredientTypeModel
        //                {
        //                    Id = 0
        //                },
        //                IsItCG = true

        //            }
        //        }
        //        //new object[] { "is fun", 2 },
        //        //new object[] { "to test with", 3 }
        //    };
        //    }
        //}


        //[Theory]
        //[MemberData(nameof(GetIngrediensListForDisplayData))]
        //public void GetIngrediensListForDisplay_ShouldTakeDBIngredientModelAndReturnDisplayIngredientModel(DBIngredientModel inputIngredient,
        //                                                                                                   DisplayIngredientModel expectedIngredient)
        //{
        //    var inputIngredientsList = new List<DBIngredientModel>()
        //    {
        //        inputIngredient
        //    };

        //    var expectedDisplayIngredientList = new List<DisplayIngredientModel>()
        //    {
        //        expectedIngredient
        //    }.ToExpectedObject();


        //    var actualIngredientList = _ingredientHelper.GetIngrediensListForDisplay(inputIngredientsList, _ingredientTypes);

        //    expectedDisplayIngredientList.ShouldEqual(actualIngredientList);
        //}

    }
}
