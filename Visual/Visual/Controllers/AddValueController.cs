using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;
using Services.AddValueToTableService;

namespace Visual.Controllers
{
    public class AddValueController : Controller
    {
        //A srevice for adding operations
        private readonly IAddingService _service;

        //create an instance of the service
        public AddValueController(IAddingService service)
        {
            _service = service;
        }
        // GET: AddValue

        public ActionResult AddValue()
        {
            return View(_service.GetTableNames());
        }

        [HttpPost]
        public ActionResult AddValue([Bind(Include = "ChosenName,FieldValues")] AddValueDto table)
        {
            //Check if users choose a table name or not.
            if (table.ChosenName is null)
                return View();
            else if (table.FieldValues is null)
            {
                return View(_service.TableStructure(table));
            }

            _service.AddValueToTable(table);
            return RedirectToAction("Index", "Home");
        }
    }
}