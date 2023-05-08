using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Domain.Security;
using Nop.Services.Plugins;
using Nop.Web.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework;
using Nop.Web.Models;

namespace Nop.Plugin.Payments.ToDo.Controllers
{
   
    public class MangosController : BasePublicController
    {
        public MangosController() { }

        public IActionResult pick()
        
        {
            return View("~/Plugins/Payments.ToDo/Views/pick.cshtml");
        }

    }
}
