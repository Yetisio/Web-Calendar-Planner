using WebCalendar.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace WebCalendar.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDAL
    {
        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <returns></returns>
        public List<Event> GetEvents();
        /// <summary>
        /// Gets my events.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public List<Event> GetMyEvents(string userid);
        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Event GetEvent(int id);
        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="form">The form.</param>
        public void CreateEvent(IFormCollection form);
        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="form">The form.</param>
        public void UpdateEvent(IFormCollection form);
        /// <summary>
        /// Deletes the event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteEvent(int id);
        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations();
        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Location GetLocation(int id);
        /// <summary>
        /// Creates the location.
        /// </summary>
        /// <param name="location">The location.</param>
        public void CreateLocation(Location location);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WebCalendar.Data.IDAL" />
    public class DAL : IDAL
    {
        /// <summary>
        /// The database
        /// </summary>
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <returns></returns>
        public List<Event> GetEvents()
        {
            return db.Events.ToList();
        }

        /// <summary>
        /// Gets my events.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public List<Event> GetMyEvents(string userid)
        {
            return db.Events.Where(x => x.User.Id == userid).ToList();
        }

        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Event GetEvent(int id)
        {
            return db.Events.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="form">The form.</param>
        public void CreateEvent(IFormCollection form)
        {
            var locname = form["Location"].ToString();
            var user = db.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            var newevent = new Event(form, db.Locations.FirstOrDefault(x => x.Name == locname), user);
            db.Events.Add(newevent);
            db.SaveChanges();
        }

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="form">The form.</param>
        public void UpdateEvent(IFormCollection form)
        {
            var locname = form["Location"].ToString();
            var eventid = int.Parse(form["Event.Id"]);
            var myevent = db.Events.FirstOrDefault(x => x.Id == eventid);
            var location = db.Locations.FirstOrDefault(x => x.Name == locname);
            var user = db.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            myevent.UpdateEvent(form, location, user);
            db.Entry(myevent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Deletes the event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteEvent(int id)
        {
            var myevent = db.Events.Find(id);
            db.Events.Remove(myevent);
            db.SaveChanges();
        }

        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            return db.Locations.ToList();
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Location GetLocation(int id)
        {
            return db.Locations.Find(id);
        }

        /// <summary>
        /// Creates the location.
        /// </summary>
        /// <param name="location">The location.</param>
        public void CreateLocation(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
        }
    }
}
