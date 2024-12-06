using System;
using Reports.Core.Common;

namespace Reports.Core.Entities;

public class ToMrb : BaseEntity
{
    public string Component { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty ;
    public DateTime RegistrationDate { get; set; } = DateTime.Now ;
}
