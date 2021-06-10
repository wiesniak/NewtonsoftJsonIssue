using ModelValidationIssueDemo.Models;

using System.Web.Http;

namespace ModelValidationIssueDemoNetFramework48.Controllers
{
    public class SurpriseController : ApiController
    {
        [HttpPost]
        public void Surprise([FromBody] SurpriseModel surpriseModel)
        {
        }
    }
}