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
  }
}