using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp1.Filtters
{
    public class MyFiltterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //write code
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //write code

        }
    }
}
