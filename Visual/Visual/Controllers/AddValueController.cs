using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Visual.DTOs;
using Visual.Services.TableAddingValueService;

namespace Visual.Controllers
{
    public class AddValueController : Controller
    {
        //A srevice for adding operations
        private readonly IAddValueTableService _service;

        //create an instance of the service
        public AddValueController(IAddValueTableService service)
        {
            _service = service;
        }
        // GET: AddValue

        public ActionResult AddValue()
        {
            return View(new AddNewValueDto(_service.GetAllTableName()));
        }

        [HttpPost]
        public ActionResult AddValue([Bind(Include = "ChosenName,FieldValues")] AddNewValueDto table)
        {
            //Check if users choose a table name or not.
            if (table.ChosenName is null)
                return View();
            else if (table.FieldValues is null)
            {
                table.FieldNames = _service.GetAllFieldNames(table.ChosenName);
                table.TableNames = _service.GetAllTableName();
                return View(table);
            }

            _service.AddValueToTable(table);
            return RedirectToAction("Index", "Home");
        }
    }
}