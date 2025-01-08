namespace Reports.Application.Dtos;

public class PendingValidationDto : BaseDto
{    
    public string Reason { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

}
