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
        public async Task<List<DisplayIngredientModel>> GetAllIngredientsWithTheirTypes()
        {
            IngredientData ingredientData = new IngredientData();
            var  ingredientsList = await ingredientData.GetAll(_dataAccess);

            IngredientTypeData typeData = new IngredientTypeData();
            var typesList = await typeData.GetAll(_dataAccess);

            List<DisplayIngredientModel> detailedIngredientsList = GetIngrediensListForDisplay(ingredientsList, typesList);

            

            return detailedIngredientsList;
        }

        private List<DisplayIngredientModel> GetIngrediensListForDisplay(List<DBIngredientModel> ingredientsList, List<DBIngredientTypeModel> typesList)
        {
            List<DisplayIngredientModel> detailedIngredientsList = new List<DisplayIngredientModel>();

            foreach (var ingredient in ingredientsList)
            {
                DBIngredientTypeModel ingredientType = FindIngredientTypeByID(typesList, ingredient.IngredientTypeId);
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

        private DBIngredientTypeModel FindIngredientTypeByID(List<DBIngredientTypeModel> typesList, int id)
        {
            return typesList.Where(type => type.Id == id).FirstOrDefault();
        }
    }
}
