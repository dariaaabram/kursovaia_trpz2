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
    public class DishController : Controller
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var dishes = _dishService.GetAll();
            ViewBag.Dishes = dishes;
            return View();
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
             var dish = _dishService.Get(id);
                ViewBag.Dish = dish;
                return View();
            
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(DishDTO dish)
        {
           _dishService.Create(dish);
                return Redirect("/Dish/GetAll");
           
        }

       
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

      
        [HttpPost]
        public RedirectResult Edit(DishDTO dish)
        {
           if (dish.Name != " ") _dishService.EditDishName(dish.Id, dish);
                if (dish.Price != 0) _dishService.EditDishPrice(dish.Id, dish);
                if (dish.Weight != 0) _dishService.EditDishWeight(dish.Id, dish);
                if (dish.Time != 0) _dishService.EditDishTime(dish.Id, dish);
                return Redirect("/Dish/GetAll");
           
        }

        [HttpGet]
        public ActionResult AddIngredient(int id)
        {
            ViewBag.Id = id;
            return View("InputDishId");
        }

       
        [HttpPost]
        public RedirectResult AddIngredient(int Id, int childId)
        {
             _dishService.AddDishIngredient(Id, childId);
                return Redirect("/Dish/GetAll");
          
        }

        [HttpGet]
        public ActionResult RemoveIngredient(int id)
        {
            ViewBag.Id = id;
            return View("InputDishId");
        }

      
        [HttpPost]
        public RedirectResult RemoveIngredient(int Id, int childId)
        {
             _dishService.DeleteDishIngredient(Id, childId);
                return Redirect("/Dish/GetAll");
           
        }

        [HttpGet]
        public RedirectResult Delete(int id)
        {
             _dishService.Delete(id);
                return Redirect("/Dish/GetAll");
             }
    }
}