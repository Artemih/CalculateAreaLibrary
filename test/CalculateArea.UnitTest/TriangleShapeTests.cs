using CalculateArea.Triangle;

namespace CalculateArea.UnitTest;

public class TriangleShapeTests
{
    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(4, 5, 6, 9.92)]
    [InlineData(5, 5, 8, 12)]
    public void TriangleAreaCalculation_ValidSides_ReturnsCorrectArea(
        double sideA,
        double sideB,
        double sideC,
        double expectedArea
    )
    {
        // Arrange
        TriangleShape triangle = new(sideA, sideB, sideC);

        // Act
        double actualArea = triangle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea, 4);
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    public void IsRightAngled_ValidRightAngledTriangle_ReturnsTrue(
        double sideA,
        double sideB,
        double sideC)
    {
        // Arrange
        TriangleShape triangle = new(sideA, sideB, sideC);

        // Act
        bool isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.True(isRightAngled);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 3, 4)]
    public void IsRightAngled_NotRightAngledTriangle_ReturnsFalse(
        double sideA,
        double sideB,
        double sideC)
    {
        // Arrange
        TriangleShape triangle = new(sideA, sideB, sideC);

        // Act
        bool isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.False(isRightAngled);
    }

    [Theory]
    [InlineData(-3, 4, 5)]
    [InlineData(3, -4, 5)]
    [InlineData(3, 4, -5)]
    [InlineData(-3, -4, 5)]
    [InlineData(-3, -4, -5)]
    public void TriangleAreaCalculation_InvalidSides_ThrowsArgumentException(
        double sideA,
        double sideB,
        double sideC)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new TriangleShape(sideA, sideB, sideC));
    }

    [Fact]
    public void TriangleAreaCalculation_InvalidPrecision_ThrowsArgumentException()
    {
        // Arrange
        double sideA = 2;
        double sideB = 3;
        double sideC = 4;
        int precision = -2;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new TriangleShape(sideA, sideB, sideC, precision));
    }
}