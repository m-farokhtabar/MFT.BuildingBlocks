using System.Runtime.CompilerServices;

namespace MFT.BuildingBlocks.Domain.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string message, Type callerType, string callerMethod) : base(message)
    {
        RaisedFrom = $"{callerType.FullName}.{callerMethod}";
    }
    protected DomainException(Exception innerException,string message, Type callerType, string callerMethodName) : base(message, innerException)
    {
        RaisedFrom = $"{callerType.FullName}.{callerMethodName}";
    }

    public string RaisedFrom { get; init; }

    public override string ToString()
    {
        return $"RaisedFrom[{RaisedFrom}]: {Message}";
    }
}