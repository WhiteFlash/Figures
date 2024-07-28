using Figures.Lib.Exceptions;
using System;
using System.Linq;

namespace Figures.Lib;

public class Triangle : Shape
{
    private const int RASED_TO_POWER = 2;
    private const int ACCURACY = 0;

    private double _sideA;
    private double _sideB;
    private double _sideC;

    public double SideA
    {
        get => _sideA;
        set
        {
            CheckSideValue(value);
            CheckSides(SideB, SideC, value);
            _sideA = value;
        }
    }
    public double SideB
    {
        get => _sideB;
        set
        {
            CheckSideValue(value);
            CheckSides(SideC, SideB, value);
            _sideB = value;
        }
    }
    public double SideC
    {
        get => _sideC;
        set
        {
            CheckSideValue(value);
            CheckSides(_sideC, SideC, value);
            _sideC = value;
        }
    }

    public Triangle(double sideA, double sideB, double sideC)
    {
        CheckSideValues([sideA, sideB, sideC]);
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
        IsRightAngled();
    }

    public override double CalculateSquare()
    {
        var sidesSum = SideA + SideB + SideC;
        var perimeter = (double)sidesSum / 2;
        var square = Math.Sqrt(perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - SideC));
        return Math.Round(square, ACCURACY);
    }

    public virtual bool IsRightAngled()
    {
        var sortedSides = new double[] { SideA, SideB, SideC };
        Array.Sort(sortedSides);

        var powerSideA = Math.Pow(sortedSides[0], RASED_TO_POWER);
        var powerSideB = Math.Pow(sortedSides[1], RASED_TO_POWER);
        var powerSideC = Math.Pow(sortedSides[2], RASED_TO_POWER);

        return powerSideC == powerSideA + powerSideB;
    }

    private void CheckSideValues(double[] values)
    {
        if (values.Any(x => x <= 0))
            throw new TriangleException($"Value for the side can not be 0 or less. Your value {values}");

        if (values[0] + values[1] < values[2]
            && values[0] + values[2] < values[1]
            && values[1] + values[2] < values[0])
            throw new TriangleException("Triangle does not exist as sum of 2 sides is less then than the length of 3-d side");
    }

    private void CheckSideValue(double value)
    {
        if (value <= 0)
            throw new TriangleException($"Value for the side can not be 0 or less. Your value {value}");
    }

    private void CheckSides(double firstSide, double secondSide, double sideToUpdate)
    {
        if (!((firstSide + secondSide) > sideToUpdate))
            throw new TriangleException($"Side can not be updated as its value: {sideToUpdate} greate than sum of values for the rest of the sides");
    }
}
