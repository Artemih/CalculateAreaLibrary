using CalculateArea.Circle;

namespace CalculateArea.UnitTest;

public class CircleShapeTests
{
    [Theory]
    [InlineData(5, 78.54)]
    public void CircleAreaCalculation_ValidRadius_ReturnsCorrectArea(double radius, double expectedArea)
    {
        // Arrange
        CircleShape circle = new(radius);

        // Act
        double actualArea = circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea);
    }

    [Fact]
    public void CircleAreaCalculation_InvalidRadius_ThrowsArgumentException()
    {
        // Arrange
        double radius = -5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CircleShape(radius));
    }  
    
    [Fact]
    public void CircleAreaCalculation_InvalidPrecision_ThrowsArgumentException()
    {
        // Arrange
        double radius = 5;
        int precision = -2;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CircleShape(radius, precision));
    }
}