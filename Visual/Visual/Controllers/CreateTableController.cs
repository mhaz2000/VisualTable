using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Visual.DTOs;
using Visual.Services.TableCreationService;

namespace Visual.Controllers
{
    public class CreateTableController : Controller
    {
        //A service for creating table operations.
        private readonly ICreationService _service;

        //make an instance of our service.
        public CreateTableController()
        {
            _service = new CreationService();
        }
        // GET: CreateTable
        public ActionResult CreateTable()
        {
            return View(new TableStructionDto());
        }

        [HttpPost]
        public ActionResult CreateTable([Bind(Include = "FieldNumber, tableName, FieldTypes, FieldNames")] TableStructionDto table)
        {
            if(table.FieldNames is null)
                return View(_service.CheckNewTable(table));

            _service.AddTable(table);
            return RedirectToAction("Index", "Home");

        }

    }
}