using System;
using System.Collections.Generic;
using AllSpiceCSharp.Models;
using AllSpiceCSharp.Services;
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
    }
}