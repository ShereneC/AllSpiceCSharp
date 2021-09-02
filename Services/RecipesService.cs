using System;
using System.Collections.Generic;
using AllSpiceCSharp.Models;
using AllSpiceCSharp.Repositories;

namespace AllSpiceCSharp.Services
{
  public class RecipesService
  {
      private readonly RecipesRepository _repo;

      public RecipesService(RecipesRepository repo) 
      {
        _repo = repo;
      }
    internal List<Recipe> Get()
    {
      return _repo.Get();
    }
    internal Recipe Get(int id) 
    {
      Recipe recipe = _repo.Get(id);
      if(recipe == null)
      {
        throw new Exception("Invalid ID");
      }
      return recipe;
    }

    internal Recipe Create(Recipe newRecipe)
    {
      return _repo.Create(newRecipe);
    }

    internal Recipe Edit(Recipe updatedRecipe)
    {
      Recipe original = Get(updatedRecipe.Id);
      updatedRecipe.Title = updatedRecipe.Title != null ? updatedRecipe.Title : original.Title;
      updatedRecipe.Description = updatedRecipe.Description != null ? updatedRecipe.Description : original.Description;
      updatedRecipe.CookTime = updatedRecipe.CookTime != 1 ? updatedRecipe.CookTime : original.CookTime;
      updatedRecipe.PrepTime = updatedRecipe.PrepTime != 1 ? updatedRecipe.PrepTime : original.PrepTime;
      return _repo.Update(updatedRecipe);
    }
  }
}