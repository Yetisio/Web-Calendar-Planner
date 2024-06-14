using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCalendar.Data;
using WebCalendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebCalendar.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class LocationController : Controller
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
        /// Initializes a new instance of the <see cref="LocationController"/> class.
        /// </summary>
        /// <param name="idal">The idal.</param>
        /// <param name="usermanager">The usermanager.</param>
        public LocationController(IDAL idal, UserManager<ApplicationUser> usermanager)
        {
            _dal = idal;
            _usermanager = usermanager;
        }

        // GET: Location
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
            return View(_dal.GetLocations());
        }

        // GET: Location/Details/5
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

            var location = _dal.GetLocation((int)id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Location/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Location location)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dal.CreateLocation(location);
                    TempData["Alert"] = "Success! You created a location for: " + location.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewData["Alert"] = "An error occurred: " + ex.Message;
                    return View(location);
                }
                
            }
            return View(location);
        }
    }
}
