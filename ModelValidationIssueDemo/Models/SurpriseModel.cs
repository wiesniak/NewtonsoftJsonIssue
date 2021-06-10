using System;

namespace ModelValidationIssueDemo.Models
{
    public class SurpriseModel
    {
        public DateTime? SurpriseTime { get; set; }
        public SurpriseDetailsModel Details { get; set; }
    }
}