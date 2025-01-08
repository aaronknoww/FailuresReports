namespace Reports.Application.Dtos;

public class ToMrbDto : BaseDto
{
    
    public string Component { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty ;
    public DateTime RegistrationDate { get; set; } = DateTime.Now ;

}
