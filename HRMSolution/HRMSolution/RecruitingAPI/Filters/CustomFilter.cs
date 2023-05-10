using Microsoft.AspNetCore.Mvc.Filters;

namespace RecruitingAPI.Filters;

public class CustomFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        throw new NotImplementedException();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }
}