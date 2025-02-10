using System;

namespace Reports.Core.Entities;

public class FailureRegistrationSYSFTEntity : FailureRegistrationGeneric
{
    public string TestCell { get; set; } = string.Empty;

}
