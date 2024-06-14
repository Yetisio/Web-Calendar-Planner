using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalendar.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class JSONListHelper
    {
        /// <summary>
        /// Gets the event list json string.
        /// </summary>
        /// <param name="events">The events.</param>
        /// <returns></returns>
        public static string GetEventListJSONString(List<Models.Event> events)
        {
            var eventlist = new List<Event>();
            foreach (var model in events)
            {
                var myevent = new Event()
                {
                    id = model.Id,
                    start = model.StartTime,
                    end = model.EndTime,
                    resourceId = model.Location.Id,
                    description = model.Description,
                    title = model.Name
                };
                eventlist.Add(myevent);
            }
            return System.Text.Json.JsonSerializer.Serialize(eventlist);
        }

        /// <summary>
        /// Gets the resource list json string.
        /// </summary>
        /// <param name="locations">The locations.</param>
        /// <returns></returns>
        public static string GetResourceListJSONString(List<Models.Location> locations)
        {
            var resourcelist = new List<Resource>();

            foreach (var loc in locations)
            {
                var resource = new Resource()
                {
                    id = loc.Id,
                    title = loc.Name
                };
                resourcelist.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourcelist);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string title { get; set; }
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public DateTime start { get; set; }
        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public DateTime end { get; set; }
        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>
        /// The resource identifier.
        /// </value>
        public int resourceId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string description { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string title { get; set; }

    }
}
