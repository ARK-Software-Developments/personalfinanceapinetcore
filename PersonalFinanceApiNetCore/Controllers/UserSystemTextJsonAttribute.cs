namespace PersonalFinanceApiNetCore.Controllers
{
    using System.Text.Json;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.Formatters;

    /// <summary>
    /// Clase UserSystemTextJsonAttribute.
    /// </summary>
    public class UserSystemTextJsonAttribute : ActionFilterAttribute
    {
        /// <inheritdoc/>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context != null && context.Result is ObjectResult objectResult)
            {
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                objectResult.Formatters.Add(new SystemTextJsonOutputFormatter(jsonOptions));
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}