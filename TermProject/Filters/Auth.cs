using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TermProject.Entities;
using TermProject.Extensions;

namespace TermProject.Filters
{
    public class Auth:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<Users>("loggedUser") == null)
                context.Result = new RedirectResult("/Home/Login");

            


        }
    }
   
}
