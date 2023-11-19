using BlazorApp.Animate.Extensions;
using BlazorApp.Animate.Options;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using static BlazorApp.Animate.Animation;

namespace BlazorApp.Animate;

/// <summary>
/// Adiciona um componente de anima��o.
/// </summary>
public partial class Animate
{
    /// <summary>
    /// Obt�m ou inicializa os atributos adicionais que ser�o aplicados ao componente.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; init; } = [];

    /// <summary>
    /// Obt�m ou inicializa um <see cref="IAnimation"/> que representa a anima��o do componente.
    /// </summary>
    /// <remarks>O valor padr�o � <see cref="FadeIn"/>.</remarks>
    [Parameter]
    public IAnimation Animation { get; init; } = FadeIn;

    /// <summary>
    /// Obt�m ou inicializa o conte�do filho do componente.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public RenderFragment? ChildContent { get; init; }

    /// <summary>
    /// Obt�m ou inicializa o atraso para iniciar a anima��o.
    /// </summary>
    [Parameter]
    public TimeSpan? Delay { get; init; }

    /// <summary>
    /// Obt�m ou inicializa o atraso (em segundos) para iniciar a anima��o.
    /// </summary>
    /// <remarks>Essa propriedade � ignorada quando <see cref="Delay"/> for especificada.</remarks>
    [Parameter]
    public double? DelayS { get; init; }

    /// <summary>
    /// Obt�m ou inicializa a dura��o da anima��o.
    /// </summary>
    [Parameter]
    public TimeSpan? Duration { get; init; }

    /// <summary>
    /// Obt�m ou inicializa a dura��o (em segundos) da anima��o.
    /// </summary>
    /// <remarks>Essa propriedade � ignorada quando <see cref="Duration"/> for especificada.</remarks>
    [Parameter]
    public double? DurationS { get; init; }

    /// <summary>
    /// Obt�m ou inicializa o modo de preenchimento que define como os estilos s�o aplicados antes e depois da execu��o
    /// de uma anima��o.
    /// </summary>
    [Parameter]
    public IFillMode? FillMode { get; init; }

    /// <summary>
    /// Obt�m ou inicializa as op��es de anima��o.
    /// </summary>
    [Parameter]
    public AnimationOptions? Options { get; init; }

    /// <summary>
    /// Obt�m ou inicializa a fun��o de temporiza��o que define como uma anima��o progride ao longo da dura��o de cada
    /// ciclo.
    /// </summary>
    [Parameter]
    public ITimingFunction? TimingFunction { get; init; }

    /// <summary>
    /// Obt�m ou inicializa as op��es de anima��o padr�o.
    /// </summary>
    [Inject]
    private IOptionsSnapshot<AnimationOptions>? DefaultOptions { get; init; }

    /// <inheritdoc/>
    protected override void OnParametersSet()
    {
        TimeSpan? duration = Duration
            ?? DurationS.ToSecondsTimeSpan()
            ?? Options?.Duration
            ?? DefaultOptions?.Value.Duration;

        ITimingFunction? timingFunction = TimingFunction
            ?? Options?.TimingFunction
            ?? DefaultOptions?.Value.TimingFunction;

        TimeSpan? delay = Delay
            ?? DelayS.ToSecondsTimeSpan()
            ?? Options?.Delay
            ?? DefaultOptions?.Value.Delay;

        IFillMode? fillMode = FillMode
            ?? Options?.FillMode
            ?? DefaultOptions?.Value.FillMode;

        var animation = new MutantAnimation(Animation, duration, timingFunction, delay, fillMode);

        string? styles = AdditionalAttributes.GetValueOrDefault("style") as string;

        AdditionalAttributes["style"] = $"{animation} {styles}";
    }
}
