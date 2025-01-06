using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TermProject.Entities;
using TermProject.Extensions;

namespace TermProject.Filters
{

    public class Admin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<Users>("loggedUser")?.Role?.ToLower() != "admin")
            {
                context.Result = new RedirectResult("/Home/Index");
            }
        }

    }

}
