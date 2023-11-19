using BlazorApp.Animate.Extensions;

namespace BlazorApp.Animate;

/// <summary>
/// Classe com métodos extensivos para <see cref="IAnimation"/>.
/// </summary>
public static class IAnimationExtension
{
    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="duration">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, TimeSpan? duration = null,
        ITimingFunction? timingFunction = null, TimeSpan? delay = null, IFillMode? fillMode = null) =>
        new MutantAnimation(animation, duration, timingFunction, delay, fillMode);

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação (em segundos) que será mutada.</param>
    /// <param name="durationS">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delayS">O atraso (em segundos) para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, double? durationS = null,
        ITimingFunction? timingFunction = null, double? delayS = null, IFillMode? fillMode = null)
    {
        TimeSpan? durationTimeSpan = durationS.ToSecondsTimeSpan();
        TimeSpan? delayTimeSpan = delayS.ToSecondsTimeSpan();

        return new MutantAnimation(animation, durationTimeSpan, timingFunction, delayTimeSpan, fillMode);
    }
}
