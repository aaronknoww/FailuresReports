using System;

namespace Reports.Application.Exceptions;

public class EntityNotFoundException : ApplicationException
{
    public EntityNotFoundException(string name, Object key) : base($"Entity {name} - {key} is not found.")
    {
        
    }
    public EntityNotFoundException(string massege) : base(massege)
    {
        
    } 

}
