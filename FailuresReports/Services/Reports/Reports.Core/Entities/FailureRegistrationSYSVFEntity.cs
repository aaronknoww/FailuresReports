namespace Reports.Core.Entities;

public class FailureRegistrationSYSVFEntity : FailureRegistrationGeneric
{
    public string Master { get; set; } = string.Empty;
    public byte Slot { get; set; }
    public byte SubSlot { get; set; }
}
