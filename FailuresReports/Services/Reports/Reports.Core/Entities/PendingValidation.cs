using System;
using Reports.Core.Common;

namespace Reports.Core.Entities;

public class PendingValidation : BaseEntity
{
    public string Reason { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

}
