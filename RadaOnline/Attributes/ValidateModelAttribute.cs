namespace RadaOnline.Attributes
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly bool notNullModelRequired;

        public ValidateModelAttribute(bool notNullModelRequired)
        {
            this.notNullModelRequired = notNullModelRequired;
        }

        public ValidateModelAttribute(): this(true)
        {
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (this.notNullModelRequired && !actionContext.ModelState.Any())
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The request is invalid. Empty model");
            }
            else if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}