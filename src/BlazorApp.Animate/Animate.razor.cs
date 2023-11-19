using BlazorApp.Animate.Extensions;
using Microsoft.AspNetCore.Components;
using static BlazorApp.Animate.Animation;

namespace BlazorApp.Animate;

/// <summary>
/// Adiciona um componente de animação.
/// </summary>
public partial class Animate
{
    /// <summary>
    /// Obtém ou inicializa os atributos adicionais que serão aplicados ao componente.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; init; } = [];

    /// <summary>
    /// Obtém ou inicializa um <see cref="IAnimation"/> que representa a animação do componente.
    /// </summary>
    /// <remarks>O valor padrão é <see cref="FadeIn"/>.</remarks>
    [Parameter]
    public IAnimation Animation { get; init; } = FadeIn;

    /// <summary>
    /// Obtém ou inicializa o conteúdo filho do componente.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public RenderFragment? ChildContent { get; init; }

    /// <summary>
    /// Obtém ou inicializa o atraso para iniciar a animação.
    /// </summary>
    [Parameter]
    public TimeSpan? Delay { get; init; }

    /// <summary>
    /// Obtém ou inicializa o atraso (em segundos) para iniciar a animação.
    /// </summary>
    /// <remarks>Essa propriedade é ignorada quando <see cref="Delay"/> for especificada.</remarks>
    [Parameter]
    public double? DelayS { get; init; }

    /// <summary>
    /// Obtém ou inicializa a duração da animação.
    /// </summary>
    [Parameter]
    public TimeSpan? Duration { get; init; }

    /// <summary>
    /// Obtém ou inicializa a duração (em segundos) da animação.
    /// </summary>
    /// <remarks>Essa propriedade é ignorada quando <see cref="Duration"/> for especificada.</remarks>
    [Parameter]
    public double? DurationS { get; init; }

    /// <summary>
    /// Obtém ou inicializa o modo de preenchimento que define como os estilos são aplicados antes e depois da execução
    /// de uma animação.
    /// </summary>
    [Parameter]
    public IFillMode? FillMode { get; init; }

    /// <summary>
    /// Obtém ou inicializa a função de temporização que define como uma animação progride ao longo da duração de cada
    /// ciclo.
    /// </summary>
    [Parameter]
    public ITimingFunction? TimingFunction { get; init; }

    /// <inheritdoc/>
    protected override void OnParametersSet()
    {
        TimeSpan? duration = Duration ?? DurationS.ToSecondsTimeSpan();
        TimeSpan? delay = Delay ?? DelayS.ToSecondsTimeSpan();

        var animation = new MutantAnimation(Animation, duration, TimingFunction, delay, FillMode);

        string? styles = AdditionalAttributes.GetValueOrDefault("style") as string;

        AdditionalAttributes["style"] = $"{animation} {styles}";
    }
}
