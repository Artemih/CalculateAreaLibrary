using Abstractions;

namespace CalculateArea.Circle;

public sealed class CircleShape : IShape
{
    private readonly int _precision;
    private readonly MidpointRounding _midpointRoundingMode;

    public double Radius { get; }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="CircleShape"/> 
    /// </summary>
    /// <param name="radius">Радиус круга</param>
    /// <param name="precision">Точность вычселений</param>
    /// <param name="midpointRoundingMode">Способ округления</param>
    /// <exception cref="ArgumentException">Радиус или точность не положительные числа</exception>
    public CircleShape(
        double radius, 
        int precision = 2,
        MidpointRounding midpointRoundingMode = MidpointRounding.ToEven)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Радиус должен быть положительным числом");
        }

        if (precision < 0)
        {
            throw new ArgumentException("Точнасть должна быть положительным числом");
        }

        _precision = precision;
        _midpointRoundingMode = midpointRoundingMode;
        Radius = radius;
    }

    /// <summary>
    /// Вычисляет площадь круга по формуле π * r^2
    /// </summary>
    /// <returns>Площадь круга</returns>
    public double CalculateArea()
    {
        return Math.Round(Math.PI * Math.Pow(Radius, 2), _precision, _midpointRoundingMode);
    }
}