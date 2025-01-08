using System;

namespace Reports.Application.Dtos;

public class FailiureDtoGeneric : BaseDto
{  

    
    public string TestArea { get; set; } = string.Empty;
    public string TestStation { get; set; } = string.Empty;
    public string Failure { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public string Solution { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;


}
