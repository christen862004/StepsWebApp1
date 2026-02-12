using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp1.Filtters
{
    public class HandelErrorAttribute :Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult result = new ContentResult();
            //result.Content = "some Error happren";
            ViewResult result = new ViewResult();
            result.ViewName = "Error";
            
            context.Result= result;
        }
    }
}
