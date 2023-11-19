using BlazorApp.Animate.Extensions;
using BlazorApp.Animate.Options;
using Microsoft.Extensions.Options;

namespace BlazorApp.Animate;

/// <summary>
/// Classe com métodos extensivos para <see cref="IAnimation"/>.
/// </summary>
public static class IAnimationExtension
{
    /// <summary>
    /// Muta a animação com as opções de animação especificada.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">As opções de animação.</param>
    /// <returns>A representação da animação mutante com as opções de animação especificada em uma cadeia de
    /// caracteres.</returns>
    public static string? With(this IAnimation animation, AnimationOptions options) =>
        new MutantAnimation(animation, options);

    /// <summary>
    /// Muta a animação com as opções de animação especificada.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptions{TOptions}"/> usado para acessar as opções de
    /// animação.</param>
    /// <returns>A representação da animação mutante com as opções de animação especificada em uma cadeia de
    /// caracteres.</returns>
    public static string? With(this IAnimation animation, IOptions<AnimationOptions> options) =>
        With(animation, options.Value);

    /// <summary>
    /// Muta a animação com as opções de animação especificada.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptionsSnapshot{TOptions}"/> usado para acessar as opções de
    /// animação.</param>
    /// <returns>A representação da animação mutante com as opções de animação especificada em uma cadeia de
    /// caracteres.</returns>
    public static string? With(this IAnimation animation, IOptionsSnapshot<AnimationOptions> options) =>
        With(animation, options.Value);

    /// <summary>
    /// Muta a animação com as opções de animação especificada.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptionsMonitor{TOptions}"/> usado para acessar as opções de
    /// animação.</param>
    /// <returns>A representação da animação mutante com as opções de animação especificada em uma cadeia de
    /// caracteres.</returns>
    public static string? With(this IAnimation animation, IOptionsMonitor<AnimationOptions> options) =>
        With(animation, options.CurrentValue);

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

        return With(animation, durationTimeSpan, timingFunction, delayTimeSpan, fillMode);
    }

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">As opções da animação.</param>
    /// <param name="duration">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, AnimationOptions options, TimeSpan? duration = null,
        ITimingFunction? timingFunction = null, TimeSpan? delay = null, IFillMode? fillMode = null) =>
        new MutantAnimation(animation, options, duration, timingFunction, delay, fillMode);

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptions{TOptions}"/> usado para acessar as opções da animação.</param>
    /// <param name="duration">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, IOptions<AnimationOptions> options, TimeSpan? duration = null,
        ITimingFunction? timingFunction = null, TimeSpan? delay = null, IFillMode? fillMode = null) =>
        With(animation, options.Value, duration, timingFunction, delay, fillMode);

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptionsSnapshot{TOptions}"/> usado para acessar as opções da animação.</param>
    /// <param name="duration">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, IOptionsSnapshot<AnimationOptions> options,
        TimeSpan? duration = null, ITimingFunction? timingFunction = null, TimeSpan? delay = null,
        IFillMode? fillMode = null) => With(animation, options.Value, duration, timingFunction, delay, fillMode);

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptionsMonitor{TOptions}"/> usado para acessar as opções da animação.</param>
    /// <param name="duration">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, IOptionsMonitor<AnimationOptions> options,
        TimeSpan? duration = null, ITimingFunction? timingFunction = null, TimeSpan? delay = null,
        IFillMode? fillMode = null) => With(animation, options.CurrentValue, duration, timingFunction, delay, fillMode);

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">As opções da animação.</param>
    /// <param name="durationS">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delayS">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, AnimationOptions options, double? durationS = null,
        ITimingFunction? timingFunction = null, double? delayS = null, IFillMode? fillMode = null) =>
            With(animation, options, durationS.ToSecondsTimeSpan(), timingFunction, delayS.ToSecondsTimeSpan(),
                fillMode);

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptions{TOptions}"/> usado para acessar as opções da animação.</param>
    /// <param name="durationS">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delayS">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, IOptions<AnimationOptions> options, double? durationS = null,
        ITimingFunction? timingFunction = null, double? delayS = null, IFillMode? fillMode = null) =>
            With(animation, options.Value, durationS, timingFunction, delayS, fillMode);

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptionsSnapshot{TOptions}"/> usado para acessar as opções da animação.</param>
    /// <param name="durationS">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delayS">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, IOptionsSnapshot<AnimationOptions> options,
        double? durationS = null, ITimingFunction? timingFunction = null, double? delayS = null,
        IFillMode? fillMode = null) => With(animation, options.Value, durationS, timingFunction, delayS, fillMode);

    /// <summary>
    /// Muta a animação com as propriedades especificadas.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">Um <see cref="IOptionsMonitor{TOptions}"/> usado para acessar as opções da animação.</param>
    /// <param name="durationS">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delayS">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    /// <returns>A representação da animação mutante com as propriedades especificadas em uma cadeia de
    /// caracteres.</returns>
    public static string With(this IAnimation animation, IOptionsMonitor<AnimationOptions> options,
        double? durationS = null, ITimingFunction? timingFunction = null, double? delayS = null,
        IFillMode? fillMode = null) => With(animation, options.CurrentValue, durationS, timingFunction, delayS,
            fillMode);
}
