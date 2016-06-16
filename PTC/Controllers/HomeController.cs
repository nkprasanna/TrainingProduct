﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTCData;

namespace PTC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TrainingProductViewModel vm = new TrainingProductViewModel();
            // vm.EventCommand = "list";
            vm.HandleRequest();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(TrainingProductViewModel vm )
        {
            vm.HandleRequest();
            ModelState.Clear();
            return View(vm);

        }

    }
}