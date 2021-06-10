using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using ModelValidationIssueDemo.Models;

using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ModelValidationIssueDemo
{
    public class ModelStateValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
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
                    AttemptedValue = problem.Value?.AttemptedValue
                };

                validationErrors.Add(otherErrorDetails);
            }

            actionContext.Result = new ObjectResult(validationErrors)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}