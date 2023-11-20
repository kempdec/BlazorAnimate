using BlazorApp.Animate.Extensions;
using BlazorApp.Animate.Helpers;
using BlazorApp.Animate.Options;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
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
    /// Obtém ou inicializa um delegate manipulador de eventos para depois de animar o componente, contendo um
    /// sinalizador indicando se é a primeira renderização.
    /// </summary>
    [Parameter]
    public EventCallback<bool> AfterAnimate { get; init; }

    /// <summary>
    /// Obtém ou inicializa o atraso para acionar o evento de <see cref="AfterAnimate"/>.
    /// </summary>
    [Parameter]
    public TimeSpan? AfterAnimateDelay { get; init; }

    /// <summary>
    /// Obtém ou define um sinalizador indicando se a animação deve ser executada somente depois da pré-renderização.
    /// O valor padrão é <see langword="false"/>.
    /// </summary>
    /// <remarks>Essa propriedade adicionará o estilo CSS "opacity: 0" ao componente.</remarks>
    [Parameter]
    public bool AfterPreRenderOnly { get; set; }

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
    /// Obtém ou inicializa as opções de animação.
    /// </summary>
    [Parameter]
    public AnimationOptions? Options { get; init; }

    /// <summary>
    /// Obtém ou inicializa a função de temporização que define como uma animação progride ao longo da duração de cada
    /// ciclo.
    /// </summary>
    [Parameter]
    public ITimingFunction? TimingFunction { get; init; }

    /// <summary>
    /// Obtém ou inicializa as opções de animação padrão.
    /// </summary>
    [Inject]
    private IOptionsSnapshot<AnimationOptions>? DefaultOptions { get; init; }

    /// <summary>
    /// O atraso para iniciar a animação.
    /// </summary>
    private TimeSpan? _delay;

    /// <summary>
    /// A duração da animação.
    /// </summary>
    private TimeSpan? _duration;

    /// <inheritdoc/>
    protected override void OnParametersSet()
    {
        if (AfterPreRenderOnly)
        {
            ToHide();
        }
        else
        {
            SetAnimationStyle();
        }
    }

    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!AfterPreRenderOnly)
        {
            if (firstRender)
            {
                await OnAfterAnimateAsync(firstRender);
            }

            return;
        }

        AfterPreRenderOnly = false;

        SetAnimationStyle();
        StateHasChanged();

        await OnAfterAnimateAsync(firstRender);
    }

    /// <summary>
    /// Obtém uma coleção de propriedades de estilo CSS do componente.
    /// </summary>
    private StyleDictionary GetStyles() => new(AdditionalAttributes.GetValueOrDefault("style"));

    /// <summary>
    /// Aciona o evento de <see cref="AfterAnimate"/>.
    /// </summary>
    /// <param name="firstRender">Um sinalizador indicando se é a primeira renderização.</param>
    /// <returns>A <see cref="Task"/> que representa a operação assíncrona.</returns>
    private async Task OnAfterAnimateAsync(bool firstRender)
    {
        TimeSpan delay = (_duration + _delay + AfterAnimateDelay) ?? TimeSpan.Zero;

        await Task.Delay(delay);
        await AfterAnimate.InvokeAsync(firstRender);
    }

    /// <summary>
    /// Remove o estilo CSS no atributo "style" do componente.
    /// </summary>
    /// <param name="style">O estilo CSS a ser removido.</param>
    private void RemoveStyle(string style)
    {
        StyleDictionary styles = GetStyles();

        styles.Remove(style);

        AdditionalAttributes["style"] = styles.ToString();
    }

    /// <summary>
    /// Remove o estilo que esconde o componente de animação.
    /// </summary>
    private void RemoveToHide() => RemoveStyle("opacity");

    /// <summary>
    /// Define o atributo "style" do componente com as propriedades de estilo CSS de animação.
    /// </summary>
    private void SetAnimationStyle()
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

        _delay = animation.Delay;
        _duration = animation.Duration;

        SetStyles(animation.GetStyles());
    }

    /// <summary>
    /// Define o estilo CSS no atributo "style" do componente.
    /// </summary>
    /// <param name="styles">Os estilos CSS a serem definidos.</param>
    private void SetStyles(StyleDictionary styles)
    {
        StyleDictionary currentStyles = GetStyles();

        foreach (KeyValuePair<string, string> style in styles)
        {
            currentStyles.Set(style.Key, style.Value);
        }

        AdditionalAttributes["style"] = styles.ToString();
    }

    /// <summary>
    /// Define o estilo CSS no atributo "style" do componente.
    /// </summary>
    /// <param name="style">O estilo CSS a ser definido.</param>
    private void SetStyle(string? style)
    {
        StyleDictionary styles = GetStyles();

        styles.Set(style);

        AdditionalAttributes["style"] = styles.ToString();
    }

    /// <summary>
    /// Adiciona o estilo que esconde o componente de animação.
    /// </summary>
    private void ToHide() => SetStyle("opacity:0");
}
