using System;

namespace Figures.Lib.Exceptions;

public class CircleException : Exception
{
    public CircleException() : base() { }

    public CircleException(string message) : base(message) { }

    public CircleException(string message, Exception innerException) : base(message, innerException) { }
}
