using KempDec.BlazorAnimate.Options;

namespace KempDec.BlazorAnimate;

/// <summary>
/// Representa uma animação mutante.
/// </summary>
public sealed class MutantAnimation : AnimationBase
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="MutantAnimation"/>.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="options">As opções de animação.</param>
    /// <param name="duration">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    public MutantAnimation(IAnimation animation, AnimationOptions options, TimeSpan? duration = null,
        ITimingFunction? timingFunction = null, TimeSpan? delay = null, IFillMode? fillMode = null)
        : this(animation, duration ?? options.Duration, timingFunction ?? options.TimingFunction,
              delay ?? options.Delay, fillMode ?? options.FillMode)
    {
    }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="MutantAnimation"/>.
    /// </summary>
    /// <param name="animation">A animação que será mutada.</param>
    /// <param name="duration">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    public MutantAnimation(IAnimation animation, TimeSpan? duration = null, ITimingFunction? timingFunction = null,
        TimeSpan? delay = null, IFillMode? fillMode = null)
            : base(animation.Name, duration ?? animation.Duration, timingFunction ?? animation.TimingFunction,
                delay ?? animation.Delay, fillMode ?? animation.FillMode)
    {
    }

    /// <summary>
    /// Retorna a representação da animação mutante em uma cadeia de caracteres.
    /// </summary>
    /// <param name="mutantAnimation">A animação mutante.</param>
    public static implicit operator string(MutantAnimation mutantAnimation) => mutantAnimation.ToString();
}
