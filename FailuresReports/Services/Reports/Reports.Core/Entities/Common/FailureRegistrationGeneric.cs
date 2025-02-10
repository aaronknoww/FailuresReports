using System;
using Reports.Core.Common;

namespace Reports.Core.Entities;

public class FailureRegistrationGeneric : BaseEntity
{
    public string TestArea { get; set; } = string.Empty;
    public string TestStation { get; set; } = string.Empty;
    public string FailureName { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public string Solution { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    

}
