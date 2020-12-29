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
    public class OrderController:Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            ViewBag.Orders = orders;
            return View();
        }


        [HttpGet]
        public ActionResult GetById(int id)
        {
            var order = _orderService.Get(id);
                ViewBag.Order = order;
                return View();
            
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(OrderDTO order)
        {
            _orderService.Create(order);
                return Redirect("/Order/GetAll");           
        }

        [HttpGet]
        public RedirectResult Delete(int id)
        {
            _orderService.Delete(id);
                return Redirect("/Order/GetAll");
            

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            ViewBag.Id = id;
            return View();
        }

       [HttpPost]
        public RedirectResult Edit(OrderDTO order)
        {
             _orderService.EditOrderTable(order.Id, order);
                return Redirect("/Order/GetAll");
            
        }

        [HttpGet]
        public ActionResult ChangeDishesAmount(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public RedirectResult ChangeDishesAmount(int Id, int childId, int amount)
        {
           _orderService.EditOrderDishesAmount(Id, childId, amount);
                return Redirect("/Order/GetAll");
           
        }

      [HttpGet]
        public ActionResult GetByWord()
        {
            return View("InputWord");
        }


        [HttpPost]
        public ActionResult GetByWord(string word)
        {
            var orders = _orderService.GetByWord(word);
            ViewBag.Orders = orders;
            ViewBag.Word = word;
            return View();
        }
    }
}