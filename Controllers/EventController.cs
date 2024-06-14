using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCalendar.Data;
using WebCalendar.Models;
using WebCalendar.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebCalendar.Controllers.ActionFilters;

namespace WebCalendar.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class EventController : Controller
    {
        /// <summary>
        /// The dal
        /// </summary>
        private readonly IDAL _dal;
        /// <summary>
        /// The usermanager
        /// </summary>
        private readonly UserManager<ApplicationUser> _usermanager;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventController"/> class.
        /// </summary>
        /// <param name="dal">The dal.</param>
        /// <param name="usermanager">The usermanager.</param>
        public EventController(IDAL dal, UserManager<ApplicationUser> usermanager)
        {
            _dal = dal;
            _usermanager = usermanager;
        }

        // GET: Event
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetMyEvents(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        // GET: Event/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View(new EventViewModel(_dal.GetLocations(), User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified vm.
        /// </summary>
        /// <param name="vm">The vm.</param>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(EventViewModel vm, IFormCollection form)
        {
            try
            {
                _dal.CreateEvent(form);
                TempData["Alert"] = "Success! You created a new event for: " + form["Event.Name"];
                return RedirectToAction("Index");
            } catch(Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                return View(vm);
            }
        }

        // GET: Event/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [UserAccessOnly]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            var vm = new EventViewModel(@event, _dal.GetLocations(), User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(vm);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            try
            {
                _dal.UpdateEvent(form);
                TempData["Alert"] = "Success! You modified an event for: " + form["Event.Name"];
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new EventViewModel(_dal.GetEvent(id), _dal.GetLocations(), User.FindFirstValue(ClaimTypes.NameIdentifier));
                return View(vm);
            }
        }

        // GET: Event/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dal.DeleteEvent(id);
            TempData["Alert"] = "You deleted an event.";
            return RedirectToAction(nameof(Index));
        }
    }
}
