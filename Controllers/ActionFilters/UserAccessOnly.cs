using WebCalendar.Data;
using WebCalendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalendar.Controllers.ActionFilters
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IActionFilter" />
    public class UserAccessOnly : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute, Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    {
        /// <summary>
        /// The dal
        /// </summary>
        private DAL _dal = new DAL();

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <inheritdoc />
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
            if (context.RouteData.Values.ContainsKey("id"))
            {
                int id = int.Parse((string)context.RouteData.Values["id"]);
                if (context.HttpContext.User != null)
                {
                    var username = context.HttpContext.User.Identity.Name;
                    if (username != null)
                    {
                        var myevent = _dal.GetEvent(id);
                        if (myevent.User != null)
                        {
                            if (myevent.User.UserName != username)
                            {
                                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "NotFound" }));
                            }
                        }
                    }
                    
                }
            }
        }
    }
}
