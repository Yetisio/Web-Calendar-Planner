using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalendar.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class EventViewModel
    {
        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        /// <value>
        /// The event.
        /// </value>
        public Event Event { get; set; }
        /// <summary>
        /// The location
        /// </summary>
        public List<SelectListItem> Location = new List<SelectListItem>();
        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        /// <value>
        /// The name of the location.
        /// </value>
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventViewModel"/> class.
        /// </summary>
        /// <param name="myevent">The myevent.</param>
        /// <param name="locations">The locations.</param>
        /// <param name="userid">The userid.</param>
        public EventViewModel(Event myevent, List<Location> locations, string userid)
        {
            Event = myevent;
            LocationName = myevent.Location.Name;
            UserId = userid;
            foreach (var loc in locations)
            {
                Location.Add(new SelectListItem() { Text = loc.Name });
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventViewModel"/> class.
        /// </summary>
        /// <param name="locations">The locations.</param>
        /// <param name="userid">The userid.</param>
        public EventViewModel(List<Location> locations, string userid)
        {
            UserId = userid;
            foreach (var loc in locations)
            {
                Location.Add(new SelectListItem() { Text = loc.Name });
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventViewModel"/> class.
        /// </summary>
        public EventViewModel()
        {

        }

    }
}