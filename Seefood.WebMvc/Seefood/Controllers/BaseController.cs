﻿using Service.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seefood.Controllers
{
    public class BaseController : Controller
    {
        protected IProvider provider = new Provider();
    }
}