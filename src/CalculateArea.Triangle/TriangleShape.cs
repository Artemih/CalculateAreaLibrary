using Abstractions;

namespace CalculateArea.Triangle;

public sealed class TriangleShape : IShape
{
    private readonly int _precision;
    private readonly MidpointRounding _roundingMode;

    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="TriangleShape"/> 
    /// </summary>
    /// <param name="sideA">Сторона A</param>
    /// <param name="sideB">Сторона B</param>
    /// <param name="sideC">Сторона C</param>
    ///  /// <param name="precision">Точность вычселений</param>
    /// <param name="roundingMode">Способ округления</param>
    /// <exception cref="ArgumentException">Одна из сторон или точность не являеться положительными числами</exception>
    public TriangleShape(
        double sideA,
        double sideB,
        double sideC,
        int precision = 2,
        MidpointRounding roundingMode = MidpointRounding.ToEven)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Одна или более сторон не являеться положительными числами");
        }

        if (precision < 0)
        {
            throw new ArgumentException("Точнасть должна быть положительным числом");
        }

        _precision = precision;
        _roundingMode = roundingMode;

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }


    /// <summary>
    /// Вычисляет площадь треугольника по формуле √p · (p — a)(p — b)(p — c),
    /// </summary>
    /// <returns>Площадь круга</returns>
    public double CalculateArea()
    {
        double p = (SideA + SideB + SideC) / 2;
        double area = Math.Sqrt(Math.Abs(p * (p - SideA) * (p - SideB) * (p - SideC)));
        return Math.Round(area, _precision, _roundingMode);
    }


    public bool IsRightAngled()
    {
        double[] sides = [SideA, SideB, SideC];
        Array.Sort(sides);
        double hypotenuseSqr = Math.Round(Math.Pow(sides[2], 2), _precision, _roundingMode);
        double sumOfLegsSqr = Math.Round(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2), _precision, _roundingMode);
        // return Math.Abs(Math.Pow(sides[2], 2) / () is >= 1 or <= 1.0001;
        return hypotenuseSqr.Equals(sumOfLegsSqr);
    }
}