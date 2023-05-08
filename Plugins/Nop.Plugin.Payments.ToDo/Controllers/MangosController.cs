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
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace Nop.Plugin.Payments.ToDo.Controllers
{
   
    public class MangosController : BasePublicController
    {
        public MangosController() { }

        public IActionResult Pick()
        
        {
            int x = 10;
            ViewData["Title"] = x;
            return View("~/Plugins/Payments.ToDo/Views/Mangos/pick.cshtml" , x);
        }

    }
}
