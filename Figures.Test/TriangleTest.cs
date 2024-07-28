using Figures.Lib;
using Figures.Lib.Exceptions;

namespace Figures.Test;

[Trait("Triangle", "Trangle")]
public class TriangleTest
{
    [Theory]
    [InlineData(3, 4, 5, 6, true)]
    [InlineData(5, 4, 3, 6, true)]
    [InlineData(3, 5, 7, 6, false)]
    [InlineData(10, 2, 9, 8, false)]
    [InlineData(13, 10, 9, 45, false)]
    [InlineData(10, 10, 9, 40, false)]
    public void CalculateSquareTest_WhenValuesCorrect(
        int sideA,
        int sideB,
        int sideC,
        double expectedSquare,
        bool expectedIsRightAngled)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        var actualSquare = triangle.CalculateSquare();
        var actualIsRightAngled = triangle.IsRightAngled();

        Assert.Equal(expectedSquare, actualSquare);
        Assert.Equal(expectedIsRightAngled, actualIsRightAngled);
    }

    [Theory]
    [InlineData(-3, 4, 5)]
    [InlineData(3, -4, 5)]
    [InlineData(3, 4, -5)]
    [InlineData(3, 4, 0)]
    public void CalculateSquareTest_ThrowErrorWhenInitiateValues(int sideA, int sideB, int sideC)
    {
        Assert.Throws<TriangleException>(() => new Triangle(sideA, sideB, sideC).CalculateSquare());
    }

    [Fact]
    public void CalculateSquareTest_ThrowErrorWhenUpdatesSideAValue()
    {
        var triangle = new Triangle(5, 3, 3);
        Assert.Throws<TriangleException>(() => triangle.SideA = 15);
    }

    [Fact]
    public void CalculateSquareTest_ThrowErrorWhenUpdatesSideBValue()
    {
        var triangle = new Triangle(5, 3, 3);
        Assert.Throws<TriangleException>(() => triangle.SideB = 15);
    }
    [Fact]
    public void CalculateSquareTest_ThrowErrorWhenUpdatesSideCValue()
    {
        var triangle = new Triangle(5, 3, 3);
        Assert.Throws<TriangleException>(() => triangle.SideC = 15);
    }
}