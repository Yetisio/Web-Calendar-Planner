using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalendar.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public virtual ICollection<Event> Events { get; set; }
    }
}