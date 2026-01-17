using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace studentMangementSystem.Data
{
    public class StudentAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = context.HttpContext.Session.GetString("Role");

            if (role != "Student")
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Account",
                    null
                );
            }
        }
    }
}
