using Figures.Lib;
using Figures.Lib.Exceptions;

namespace Figures.Test;

[Trait("Circle", "Circle")]
public class CircleTest
{
    [Theory]
    [InlineData(1, 3.14)]
    [InlineData(2, 12.57)]
    [InlineData(10, 314.16)]
    public void CalculateSquareTest_WhenValuesCorrect(double radius, double expectedSquare)
    {
        var actualSquare = new Circle(radius).CalculateSquare();
        Assert.Equal(expectedSquare, actualSquare);
    }

    [Fact]
    public void CalculateSquareTest_ThrowErrorWhenUpdatesRadiusValue()
    {
        var triangle = new Circle(1);
        Assert.Throws<CircleException>(() => triangle.Radius = -15);
    }
}
