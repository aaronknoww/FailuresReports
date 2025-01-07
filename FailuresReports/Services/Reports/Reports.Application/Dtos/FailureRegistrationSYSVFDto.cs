namespace Reports.Application.Dtos;

public class FailureRegistrationSYSVFDto :  FailiureDtoGeneric
{
    public string Master { get; set; } = string.Empty;
    public byte Slot { get; set; }
    public byte SubSlot { get; set; }

}
