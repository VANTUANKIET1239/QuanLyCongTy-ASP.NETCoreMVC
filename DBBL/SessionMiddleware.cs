using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DBBL
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.TryGetValue("username", out byte[] value))
            {
                context.Result = new RedirectResult("/Admin/User/Login");
            }

            base.OnActionExecuting(context);
        }
    }
}

