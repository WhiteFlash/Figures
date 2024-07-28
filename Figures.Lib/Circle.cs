using Figures.Lib.Exceptions;
using System;

namespace Figures.Lib;

public class Circle : Shape
{
    private const int RASED_POWER = 2;
    private const int ACCURACY = 2;

    private double _radius;

    public double Radius
    {
        get => _radius;
        set
        {
            CheckSideValue(value);
            _radius = value;
        }
    }

    public Circle(double radius)
    {
        CheckSideValue(radius);
        _radius = radius;
    }

    public override double CalculateSquare()
    {
        var square = Math.PI * Math.Pow(_radius, RASED_POWER);
        return Math.Round(square, ACCURACY);
    }

    public void CheckSideValue(double value)
    {
        if (value <= 0)
            throw new CircleException($"Value for the radius can not be 0 or less. Your value {value}");
    }
}
