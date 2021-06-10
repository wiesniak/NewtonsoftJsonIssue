using Microsoft.AspNetCore.Mvc;

using ModelValidationIssueDemo.Models;

namespace ModelValidationIssueDemo.Controllers
{
    [Route("[controller]")]
    public class SurpriseController : ControllerBase
    {
        [HttpPost]
        public void Surprise([FromBody] SurpriseModel surpriseModel)
        {
        }
    }
}