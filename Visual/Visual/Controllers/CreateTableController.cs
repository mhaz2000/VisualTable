using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;
using Services.CreatingTableService;


namespace Visual.Controllers
{
    public class CreateTableController : Controller
    {
        //A service for creating table operations.
        private readonly ICreatingService _service;

        //make an instance of our service.
        public CreateTableController(ICreatingService service)
        {
            _service = service;
        }
        // GET: CreateTable
        public ActionResult CreateTable()
        {
            return View(new TableCreatingDto());
        }

        [HttpPost]
        public ActionResult CreateTable(TableCreatingDto table)
        {
            if(table.FieldNames is null)
                return View(_service.CheckNewTable(table));

            _service.AddTable(table);
            return RedirectToAction("Index", "Home");

        }

    }
}