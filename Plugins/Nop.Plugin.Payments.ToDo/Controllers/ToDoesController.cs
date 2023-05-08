using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nop.Core.Domain.Security;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework;
using Nop.Web.Models;
using Nop.Web.Controllers;
using Nop.Plugin.Payments.ToDo.Models;

namespace Nop.Plugin.Payments.ToDo.Controllers
{
 
    public class ToDoesController : Controller
    {
        /*private readonly NopCommerceContext _context;*/
        private readonly NopCommerceContext _context = new NopCommerceContext();

        /*public ToDoesController(NopCommerceContext context)
        {
            _context = context;
        }*/
      
        // GET: ToDoes
        public IActionResult Index()
        
        {
            return View("~/Plugins/Payments.ToDo/Views/ToDoes/Index.cshtml" , _context.ToDos.ToList());
        }

       

        // GET: ToDoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo =  _context.ToDos
                .FirstOrDefault(m => m.ID == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View("~/Plugins/Payments.ToDo/Views/ToDoes/Details.cshtml" , toDo);
        }

        // GET: ToDoes/Create
        [HttpGet]
        public IActionResult New()
        {
            return View("~/Plugins/Payments.ToDo/Views/ToDoes/New.cshtml");
        }

        // POST: ToDoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,ToDoName,ToDoDescription")] ToDeo toDo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDo);
                _context.SaveChanges();
                return RedirectToAction("~/Plugins/Payments.ToDo/Views/ToDoes/Index.cshtml");
            }
            return View("~/Plugins/Payments.ToDo/Views/ToDoes/New.cshtml" , toDo);
        }

        // GET: ToDoes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo =  _context.ToDos.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View("~/Plugins/Payments.ToDo/Views/ToDoes/Edit.cshtml", toDo);
        }

        // POST: ToDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,ToDoName,ToDoDescription")] ToDeo toDo)
        {
            if (id != toDo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("~/Plugins/Payments.ToDo/Views/ToDoes/Index.cshtml");
            }
            return View("~/Plugins/Payments.ToDo/Views/ToDoes/Edit.cshtml", toDo);
        }

        // GET: ToDoes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo =  _context.ToDos
                .FirstOrDefault(m => m.ID == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View("~/Plugins/Payments.ToDo/Views/ToDoes/Delete.cshtml", toDo);
        }

        // POST: ToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.ToDos == null)
            {
                return Problem("Entity set 'NopCommerceContext.ToDos'  is null.");
            }
            var toDo =  _context.ToDos.Find(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
            }
            
            _context.SaveChanges();
            return RedirectToAction("~/Plugins/Payments.ToDo/Views/ToDoes/Index.cshtml");
        }

        private bool ToDoExists(int id)
        {
          return _context.ToDos.Any(e => e.ID == id);
        }
    }
}
