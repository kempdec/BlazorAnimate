namespace BlazorApp.Animate.Extensions;

/// <summary>
/// Classe com métodos extensivos para <see cref="double"/>.
/// </summary>
public static class DoubleExtension
{
    /// <summary>
    /// Converte o número de segundos especificado para um <see cref="TimeSpan"/>.
    /// </summary>
    /// <param name="seconds">O número de segundos a serem convertidos.</param>
    /// <returns>O número de segundos especificado convertido para um <see cref="TimeSpan"/>.</returns>
    public static TimeSpan? ToSecondsTimeSpan(this double? seconds) =>
        seconds is double secondsDouble ? TimeSpan.FromSeconds(secondsDouble) : null;
}
