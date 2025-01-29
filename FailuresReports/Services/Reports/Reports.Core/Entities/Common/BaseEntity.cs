using System;

namespace Reports.Core.Common;

public class BaseEntity
{
    public int UserId { get; set; }
    public string UserName { get; set;} = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string BU { get; set; } = string.Empty;

}

