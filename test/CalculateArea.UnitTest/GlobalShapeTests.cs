using System.Collections;
using Abstractions;
using CalculateArea.Circle;
using CalculateArea.Triangle;

namespace CalculateArea.UnitTest;

public class GlobalShapeTests
{
    [Theory]
    [ClassData(typeof(ShapeData))]
    public void CircleAreaCalculation_ValidRadius_ReturnsCorrectArea(IShape shape, double expectedArea)
    {
        // Act
        double actualArea = shape.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea);
    }

    class ShapeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new CircleShape(5), 78.54d
            };
            yield return new object[]
            {
                new TriangleShape(3, 4, 5), 6
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}