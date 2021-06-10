using ModelValidationIssueDemo.Models;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ModelValidationIssueDemo
{
    public class ModelStateValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid)
            {
                return;
            }

            var validationErrors = new List<ErrorDetailsModel>();
            var modelProblems = actionContext.ModelState.Where(x => x.Value.Errors != null && x.Value.Errors.Any());

            foreach (var problem in modelProblems)
            {
                var error = problem.Value.Errors.First();

                var errorMessage = string.IsNullOrEmpty(error.ErrorMessage)
                    ? error.Exception.Message
                    : error.ErrorMessage;

                var otherErrorDetails = new ErrorDetailsModel
                {
                    Property = problem.Key,
                    Message = errorMessage,
                    AttemptedValue = problem.Value?.Value?.AttemptedValue
                };

                validationErrors.Add(otherErrorDetails);
            }

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, validationErrors);
        }
    }
}