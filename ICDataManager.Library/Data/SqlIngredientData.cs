﻿using Dapper;
using ICDataManager.Library.DataAccess;
using ICDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICDataManager.Library.Data
{
    public class SqlIngredientData : IIngredientData
    {
        private readonly IDataAccess _dataAccess;

        public SqlIngredientData(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<List<DBIngredientModel>> GetAll()
        {
            var ingredientsList = _dataAccess.LoadData<DBIngredientModel, dynamic>("spIngredient_GetAll", new { }, "ICData");

            return ingredientsList;

        }

        public async Task<DBIngredientModel> GetById(int id)
        {
            var ingredient = await _dataAccess.LoadData<DBIngredientModel, dynamic>("spIngredient_GetById", new { Id = id }, "ICData");

            return ingredient.FirstOrDefault();
        }

        public async Task<List<DBIngredientModel>> GetByType(int ingredientTypeId)
        {
            var ingredientsList = await _dataAccess.LoadData<DBIngredientModel, dynamic>("spIngredient_GetByType", new { IngredientTypeId = ingredientTypeId }, "ICData");

            return ingredientsList;
        }

        public async Task<int> Create(DBIngredientModel ingredient)
        {
            DynamicParameters ingredientParameter = new DynamicParameters();
            ingredientParameter.Add("MainNameId", ingredient.MainNameId);
            ingredientParameter.Add("Details", ingredient.Details);
            ingredientParameter.Add("IsItCG", ingredient.IsItCG);

            if (ingredient.IngredientTypeId > 0)
            {
                ingredientParameter.Add("IngredientTypeId", ingredient.IngredientTypeId);
            }

            ingredientParameter.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("spIngredient_Create", ingredientParameter, "ICData");

            return ingredientParameter.Get<int>("Id");
        }

        public async Task<int> Update(ManageIngredientModel editedInformation)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Id", editedInformation.Id);
            p.Add("MainNameId", editedInformation.MainNameId);
            p.Add("Details", editedInformation.Details);
            p.Add("IsItCG", editedInformation.IsItCG);
            
            if (editedInformation.IngredientTypeId > 0)
            {
                p.Add("IngredientTypeId", editedInformation.IngredientTypeId);
            }

            return await _dataAccess.SaveData("spIngredient_Update", p, "ICData");
        }

        public async Task<int> UpdateTypeId(int id)
        {
            return await _dataAccess.SaveData("spIngredient_UpdateTypeId", new { Id = id }, "ICData");
        }

        public async Task<int> DeleteIngredient(int id)
        {
            return await _dataAccess.SaveData("spIngredient_Delete", new { Id = id }, "ICData");
        }
    }
}
