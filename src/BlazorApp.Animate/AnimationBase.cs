using static BlazorApp.Animate.TimingFunction;
using static BlazorApp.Animate.FillMode;
using System.Text;
using System.Globalization;

namespace BlazorApp.Animate;

/// <summary>
/// Fornece abstração para uma animação.
/// </summary>
public abstract class AnimationBase : IAnimation
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="AnimationBase"/>.
    /// </summary>
    /// <remarks>Esse construtor define a duração da animação para 0.4 segundos, a função de temporização como
    /// <see cref="EaseInOut"/>, o atraso para iniciar a animação em 0.0 segundos e o modo de preenchimento como
    /// <see cref="Both"/>.</remarks>
    /// <param name="name">O nome da animação.</param>
    public AnimationBase(string name) : this(name, 0.4, EaseInOut, 0.0, Both) => IsDefault = true;

    /// <summary>
    /// Inicializa uma nova instância de <see cref="AnimationBase"/>.
    /// </summary>
    /// <param name="name">O nome da animação.</param>
    /// <param name="duration">A duração da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    public AnimationBase(string name, TimeSpan duration, ITimingFunction timingFunction, TimeSpan delay,
        IFillMode fillMode)
    {
        Name = name;
        Duration = duration;
        TimingFunction = timingFunction;
        Delay = delay;
        FillMode = fillMode;
    }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="AnimationBase"/>.
    /// </summary>
    /// <param name="name">O nome da animação.</param>
    /// <param name="duration">A duração (em segundos) da animação.</param>
    /// <param name="timingFunction">A função de temporização que define como uma animação progride ao longo da duração
    /// de cada ciclo.</param>
    /// <param name="delay">O atraso (em segundos) para iniciar a animação.</param>
    /// <param name="fillMode">O modo de preenchimento que define como os estilos são aplicados antes e depois da
    /// execução de uma animação.</param>
    public AnimationBase(string name, double duration, ITimingFunction timingFunction, double delay,
        IFillMode fillMode)
    {
        Name = name;
        Duration = TimeSpan.FromSeconds(duration);
        TimingFunction = timingFunction;
        Delay = TimeSpan.FromSeconds(delay);
        FillMode = fillMode;
    }

    public string Name { get; }

    public TimeSpan Duration { get; }

    public ITimingFunction TimingFunction { get; }

    public IFillMode FillMode { get; }

    public TimeSpan Delay { get; }

    public bool IsDefault { get; }

    public override string ToString() => GetStyle();

    public string GetStyle()
    {
        var styleBuilder = new StringBuilder();
        var culture = CultureInfo.GetCultureInfo("en-US");

        string durationSeconds = Duration.TotalSeconds.ToString(culture);
        string delaySeconds = Delay.TotalSeconds.ToString(culture);

        styleBuilder.Append($"animation-name: {Name};");
        styleBuilder.Append($"animation-duration: {durationSeconds}s;");
        styleBuilder.Append($"animation-timing-function: {TimingFunction.Value};");
        styleBuilder.Append($"animation-delay: {delaySeconds}s;");
        styleBuilder.Append($"animation-fill-mode: {FillMode.Value};");

        return styleBuilder.ToString();
    }
}
