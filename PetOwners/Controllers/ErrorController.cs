﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetOwners.Controllers
{
    public class ErrorController : Controller
    {
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }

    }
}