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
using static Nop.Services.Common.NopLinksDefaults;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;

namespace Nop.Plugin.Payments.ToDo.Controllers
{
 
    public class ToDoesController : Controller
    {
        private readonly NopCommerceContext _context;
        /* private readonly NopCommerceContext _context = new NopCommerceContext();*/

        public ToDoesController(NopCommerceContext context)
        {
            _context = context;
        }

        // GET: ToDoes
        public IActionResult Index()
        {
  
            return View("~/Plugins/Payments.ToDo/Views/ToDoes/Index.cshtml" , _context.ToDos.ToList());
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_context.ToDos, loadOptions);
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var employee = _context.ToDos.First(a => a.Id == key);
            JsonConvert.PopulateObject(values, employee);

            /*if (!TryValidateModel(employee))
                return BadRequest(ModelState.GetFullErrorMessage());*/

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var todo = new ToDeo();
            JsonConvert.PopulateObject(values, todo);

          /*  if (!TryValidateModel(newEmployee))
                return BadRequest(ModelState.GetFullErrorMessage());*/

            _context.ToDos.Add(todo);
            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        public void Delete(int key)
        {
            var employee = _context.ToDos.First(a => a.Id == key);
            _context.ToDos.Remove(employee);
            _context.SaveChanges();
        }

        public object List(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_context.ToDos, loadOptions);
        }


        // GET: ToDoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = _context.ToDos
                .FirstOrDefault(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View("~/Plugins/Payments.ToDo/Views/ToDoes/Details.cshtml", toDo);
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
        public IActionResult Create([Bind("Id,ToDoName,ToDoDescription")] ToDeo toDo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDo);
                _context.SaveChanges();
                return RedirectToAction("Index", "ToDoes");
            }
            return View("~/Plugins/Payments.ToDo/Views/ToDoes/New.cshtml", toDo);
        }

        // GET: ToDoes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = _context.ToDos.Find(id);
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
        public IActionResult Edits(int id, [Bind("Id,ToDoName,ToDoDescription")] ToDeo toDo)
        {
            if (id != toDo.Id)
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
                    if (!ToDoExists(toDo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "ToDoes");
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

            var toDo = _context.ToDos
                .FirstOrDefault(m => m.Id == id);
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
            var toDo = _context.ToDos.Find(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "ToDoes");
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
