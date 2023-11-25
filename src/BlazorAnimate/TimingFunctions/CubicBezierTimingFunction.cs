using System.Globalization;

namespace KempDec.BlazorAnimate.TimingFunctions;

/// <summary>
/// Representa a função de temporização cúbica de Bezier que define como uma animação progride ao longo da duração de
/// cada ciclo.
/// </summary>
public class CubicBezierTimingFunction : ITimingFunction
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="CubicBezierTimingFunction"/>.
    /// </summary>
    /// <param name="point1X">A coordenada X do 1º ponto de controle. O valor deve estar entre 0.0 e 1.0.</param>
    /// <param name="point1Y">A coordenada Y do 1º ponto de controle. O valor deve estar entre 0.0 e 1.0.</param>
    /// <param name="point2X">A coordenada X do 2º ponto de controle. O valor deve estar entre 0.0 e 1.0.</param>
    /// <param name="point2Y">A coordenada Y do 2º ponto de controle. O valor deve estar entre 0.0 e 1.0.</param>
    public CubicBezierTimingFunction(double point1X, double point1Y, double point2X, double point2Y)
    {
        if (point1X is not >= 0.0 and <= 1.0)
        {
            throw new ArgumentOutOfRangeException(nameof(point1X), PointOutOfRangeMessage);
        }

        if (point1Y is not >= 0.0 and <= 1.0)
        {
            throw new ArgumentOutOfRangeException(nameof(point1Y), PointOutOfRangeMessage);
        }

        if (point2X is not >= 0.0 and <= 1.0)
        {
            throw new ArgumentOutOfRangeException(nameof(point2X), PointOutOfRangeMessage);
        }

        if (point2Y is not >= 0.0 and <= 1.0)
        {
            throw new ArgumentOutOfRangeException(nameof(point2Y), PointOutOfRangeMessage);
        }

        var culture = CultureInfo.GetCultureInfo("en-US");

        string p1Str = point1X.ToString(culture);
        string p2Str = point1Y.ToString(culture);
        string p3Str = point2X.ToString(culture);
        string p4Str = point2Y.ToString(culture);

        Value = $"cubic-bezier({p1Str}, {p2Str}, {p3Str}, {p4Str})";
    }

    /// <summary>
    /// A mensagem de ponto de controle fora do intervalo.
    /// </summary>
    private const string PointOutOfRangeMessage = "O valor deve estar entre 0.0 e 1.0.";

    /// <inheritdoc/>
    public string Value { get; }
}
