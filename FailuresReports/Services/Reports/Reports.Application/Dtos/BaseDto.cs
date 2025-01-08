using System;

namespace Reports.Application.Dtos;

public class BaseDto
{
    public int UserId { get; set; }
    public string UserName { get; set;} = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string BU { get; set; } = string.Empty;

}
