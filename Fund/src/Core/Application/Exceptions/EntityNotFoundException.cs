namespace Fund.Core.Application.Exceptions;

public class EntityNotFoundException : Exception
{
    public string EnityType { get; }
    public string Id { get; }

    public EntityNotFoundException(string enityType, string id) : base()
    {
        EnityType = enityType;
        Id = id;
    }
}