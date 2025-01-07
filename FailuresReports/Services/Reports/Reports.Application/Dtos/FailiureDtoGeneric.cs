using System;

namespace Reports.Application.Dtos;

public class FailiureDtoGeneric
{
    //This wrappler is only to be sure that InsertAllByFailiure only recive SysFT and SysVF classes

    public int UserId { get; set; }
    public string UserName { get; set;} = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string BU { get; set; } = string.Empty;
    public string TestArea { get; set; } = string.Empty;
    public string TestStation { get; set; } = string.Empty;
    public string Failure { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public string Solution { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;


}
