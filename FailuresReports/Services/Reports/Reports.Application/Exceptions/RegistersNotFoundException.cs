namespace Reports.Application.Exceptions;

public class RegistersNotFoundException : ApplicationException
{
    public RegistersNotFoundException(string name, Object key) : base($"Entity {name} - {key} is not found.")
    {
        
    }
    public RegistersNotFoundException(string massege) : base(massege)
    {
        
    } 

}