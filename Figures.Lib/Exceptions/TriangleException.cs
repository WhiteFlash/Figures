using System;

namespace Figures.Lib.Exceptions;

public class TriangleException : Exception
{
    public TriangleException() : base() { }

    public TriangleException(string message) : base(message) { }

    public TriangleException(string message, Exception innerException) : base(message, innerException) { }
}
