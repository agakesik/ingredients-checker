using ICDataManager.Library.Data;
using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public IngredientsController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task<List<DisplayIngredientModel>> GetAllIngredients()
        {
            IngredientData ingredientData = new IngredientData();
            var  ingredientsList = await ingredientData.GetAll(_dataAccess);

            IngredientTypeData typeData = new IngredientTypeData();
            var typesList = await typeData.GetAll(_dataAccess);

            List<DisplayIngredientModel> detailedIngredientsList = new List<DisplayIngredientModel>();

            foreach (var ingredient in ingredientsList)
            {
                DBIngredientTypeModel ingredientType = typesList.Where(type => type.Id == ingredient.IngredientTypeId)
                                                                .FirstOrDefault();
                if (ingredientType == null)
                {
                    ingredientType = new DBIngredientTypeModel()
                    {
                        Id = ingredient.Id,
                        Name = "",
                        Details = "",
                        Color = "",
                    };
                }

                //detailedIngredientsList.Add(new DisplayIngredientModel
                //{
                //    Name = ingredient.Name,
                //    Details = ingredient.Details,
                //    IngredientType = new DisplayIngredientTypeModel()
                //    {
                //        Name = "name",
                //        Details = "szczegóły",
                //        Color = "color"
                //    },
                //    IsItCG = ingredient.IsItCG
                //});

                detailedIngredientsList.Add(new DisplayIngredientModel
                {
                    Name = ingredient.Name,
                    Details = ingredient.Details,
                    IngredientType = new DisplayIngredientTypeModel()
                    {
                        Name = ingredientType.Name,
                        Details = ingredientType.Details,
                        Color = ingredientType.Color
                    },
                    IsItCG = ingredient.IsItCG
                });
            }

            return detailedIngredientsList;
        }
    }
}
