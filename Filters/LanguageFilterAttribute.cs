using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Middlware.Exceptions;

namespace Middlware.Filters;

public class LanguageFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        RequestCulture.RequestLanguage = 
            context.HttpContext.Request.Headers.First(h => h.Key == "Language").Value;
    
       if(RequestCulture.RequestLanguage != "uz" && RequestCulture.RequestLanguage != "en")
       {
            throw new LanguageNotSupportedException();
       }
    }
}