using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalendar.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        //Relational data
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public virtual ICollection<Event> Events { get; set; }
    }
}