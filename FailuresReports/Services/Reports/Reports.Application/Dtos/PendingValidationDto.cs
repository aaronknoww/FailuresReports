namespace Reports.Application.Dtos;

public class PendingValidationDto
{
    public int UserId { get; set; }
    public string UserName { get; set;} = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string BU { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

}
