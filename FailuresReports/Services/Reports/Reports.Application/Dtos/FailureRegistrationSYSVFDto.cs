namespace Reports.Application.Dtos;

public class FailureRegistrationSYSVFDto
{
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
    public string Master { get; set; } = string.Empty;
    public byte Slot { get; set; }
    public byte SubSlot { get; set; }

}