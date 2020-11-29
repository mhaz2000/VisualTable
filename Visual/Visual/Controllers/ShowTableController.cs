using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTOs;
using Services.ShowingTableService;

namespace Visual.Controllers
{
    public class ShowTableController : Controller
    {
        //A service for showing table operations.
        private readonly IShowingService _servcie;

        //maje an instance of our service
        public ShowTableController(IShowingService service)
        {
            _servcie = service;
        }

        // GET: Show full Table
        public ActionResult ShowFullTable()
        {
            return View(_servcie.GetTableNames());
        
        }
         
        [HttpPost]
        public ActionResult ShowFullTable([Bind(Include = "ChosenName")] ShowTableDto table)
        {
            table = _servcie.GetFullTable(table);
            return View(table);
        }
    }
}