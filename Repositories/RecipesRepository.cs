using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpiceCSharp.Models;
using Dapper;

namespace AllSpiceCSharp.Repositories
{
  public class RecipesRepository
  {

      private readonly IDbConnection _db;

      public RecipesRepository(IDbConnection db)
      {
          _db = db;
      }
    internal List<Recipe> Get()
    {
      string sql = @"
      SELECT 
        a.*,
        r.*
      FROM recipes r
      JOIN accounts a ON r.creatorId = a.id
      ";
      // data type 1, data type 2, return type
      return _db.Query<Profile, Recipe, Recipe>(sql, (profile, recipe) =>
      {
        recipe.Creator = profile;
        return recipe;
      }, splitOn: "id").ToList();
  }
  internal Recipe Get(int id)
    {
      string sql = @"
      SELECT 
        a.*,
        r.*
      FROM recipes r
      JOIN accounts a ON r.creatorId = a.id
      WHERE r.id = @id
      ";
      // data type 1, data type 2, return type
      return _db.Query<Profile, Recipe, Recipe>(sql, (profile, recipe) =>
      {
        recipe.Creator = profile;
        return recipe;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal Recipe Create(Recipe newRecipe)
    {
      string sql = @"
      INSERT INTO recipes
      (description, title, cookTime, prepTime, creatorId)
      VALUES 
      (@Description, @Title, @CookTime, @PrepTime, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newRecipe);
      return Get(id);
    }

    internal Recipe Update(Recipe updatedRecipe)
    {
      string sql = @"
      UPDATE recipes 
      SET 
      title = @Title,
      description = @Description,
      cookTime = @CookTime,
      prepTime = @PrepTime
      WHERE id = @Id;
      ";
      _db.Execute(sql, updatedRecipe);
      return updatedRecipe;
    }
  }
}