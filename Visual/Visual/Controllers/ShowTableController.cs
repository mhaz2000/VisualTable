using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Visual.DTOs;
using Visual.Services.TableShowingService;

namespace Visual.Controllers
{
    public class ShowTableController : Controller
    {
        //A service for showing table operations.
        private readonly IShowTableService _servcie;

        //maje an instance of our service
        public ShowTableController()
        {
            _servcie = new ShowTableService();
        }

        // GET: Show full Table
        public ActionResult ShowFullTable()
        {
            return View(new ShowTableDto(_servcie.GetAllTableNames()));
        
        }
         
        [HttpPost]
        public ActionResult ShowFullTable([Bind(Include = "ChosenName")] ShowTableDto table)
        {
            table.TableNames = _servcie.GetAllTableNames();
            table = _servcie.GetFullTable(table);
            return View(table);
        }
    }
}