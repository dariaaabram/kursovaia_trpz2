using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using PL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    [HandleError(ExceptionType = typeof(Exception),
             View = "Error")]
    public class IngredientController:Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var ingredients = _ingredientService.GetAll();
            ViewBag.Ingredients = ingredients;
            return View();
        }

       [HttpGet]
        public ActionResult GetById(int id)
        {
            var ingredient = _ingredientService.Get(id);
            ViewBag.Ingredient = ingredient;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(IngredientDTO ingredient)
        {
            _ingredientService.Create(ingredient);
                return Redirect("/Ingredient/GetAll");
           
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public RedirectResult Edit(IngredientDTO ingredient)
        {
            _ingredientService.EditIngredient(ingredient.Id, ingredient);
                return Redirect("/Ingredient/GetAll");
            
        }

        [HttpGet]
        public RedirectResult Delete(int id)
        {
             _ingredientService.Delete(id);
                return Redirect("/Ingredient/GetAll");
          

        }

       [HttpGet]
        public ActionResult GetByWord()
        {
            return View("InputWord");
        }


        [HttpPost]
        public ActionResult GetByWord(string word)
        {
            var ingredients = _ingredientService.GetByWord(word);
            ViewBag.Ingredients = ingredients;
            ViewBag.Word = word;
            return View();
        }
    }
}