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
    public class TableController : Controller
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
           var tables = _tableService.GetAll();
           ViewBag.Tables = tables;
           return View();
        }

       
       [HttpGet]
        public ActionResult GetById(int id)
        {
            var table = _tableService.Get(id);
                ViewBag.Table = table;
                return View();                    
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public RedirectResult Add(TableDTO table)
        {
            _tableService.Create(table);
                return Redirect("/Table/GetAll");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public RedirectResult Edit(TableDTO table)
        {
          _tableService.EditTable(table.Id, table);
                return Redirect("/Table/GetAll");
        }
      
        [HttpGet]
        public RedirectResult Delete(int id)
        {
             _tableService.Delete(id);
                return Redirect("/Table/GetAll");
        }

    }
}