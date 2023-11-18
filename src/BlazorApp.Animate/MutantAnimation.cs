namespace BlazorApp.Animate;

/// <summary>
/// Representa uma animação mutante.
/// </summary>
/// <remarks>
/// Inicializa uma nova instância de <see cref="MutantAnimation"/>.
/// </remarks>
/// <param name="animation">A animação que será mutada.</param>
/// <param name="duration">A duração da animação.</param>
/// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
/// de cada ciclo.</param>
/// <param name="delay">O atraso para iniciar a animação.</param>
/// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
/// execução de uma animação.</param>
public sealed class MutantAnimation(IAnimation animation, TimeSpan? duration = null,
    ITimingFunction? timingFunction = null, TimeSpan? delay = null, IFillMode? fillMode = null)
        : AnimationBase(animation.Name, duration ?? animation.Duration, timingFunction ?? animation.TimingFunction,
            delay ?? animation.Delay, fillMode ?? animation.FillMode)
{
}
