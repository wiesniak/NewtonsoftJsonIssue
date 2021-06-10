namespace ModelValidationIssueDemo.Models
{
    public class ErrorDetailsModel
    {
        public string Message { get; set; }
        public string Property { get; set; }
        public string AttemptedValue { get; set; }
    }
}