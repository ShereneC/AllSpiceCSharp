using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpiceCSharp.Models;
using AllSpiceCSharp.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;

namespace AllSpiceCSharp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;

        public RecipesController(RecipesService recipesService) 
        {
            _recipesService = recipesService;
        }

        [HttpGet]

        public ActionResult<List<Recipe>> Get() {
            try
            {
              List<Recipe> recipes =_recipesService.Get();
              return Ok(recipes);   
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(int id)
        {
            try
            {
                 Recipe recipe = _recipesService.Get(id);
                 return Ok(recipe);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
         {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newRecipe.CreatorId = userInfo.Id;
                Recipe recipe = _recipesService.Create(newRecipe);
              return Ok(recipe);   
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    [HttpPut("{id}")]
    public ActionResult<Recipe> Edit([FromBody] Recipe updatedRecipe, int id)
    {
        try
        {
             updatedRecipe.Id = id;
             Recipe recipe = _recipesService.Edit(updatedRecipe);
             return Ok(recipe);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    }
}