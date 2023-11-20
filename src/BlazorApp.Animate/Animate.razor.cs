using BlazorApp.Animate.Extensions;
using BlazorApp.Animate.Helpers;
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
    /// Obt�m ou inicializa um delegate manipulador de eventos para depois de animar o componente, contendo um
    /// sinalizador indicando se � a primeira renderiza��o.
    /// </summary>
    [Parameter]
    public EventCallback<bool> AfterAnimate { get; init; }

    /// <summary>
    /// Obt�m ou inicializa o atraso para acionar o evento de <see cref="AfterAnimate"/>.
    /// </summary>
    [Parameter]
    public TimeSpan? AfterAnimateDelay { get; init; }

    /// <summary>
    /// Obt�m ou define um sinalizador indicando se a anima��o deve ser executada somente depois da pr�-renderiza��o.
    /// O valor padr�o � <see langword="false"/>.
    /// </summary>
    /// <remarks>Essa propriedade adicionar� o estilo CSS "opacity: 0" ao componente.</remarks>
    [Parameter]
    public bool AfterPreRenderOnly { get; set; }

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

    /// <summary>
    /// O atraso para iniciar a anima��o.
    /// </summary>
    private TimeSpan? _delay;

    /// <summary>
    /// A dura��o da anima��o.
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
    /// Obt�m uma cole��o de propriedades de estilo CSS do componente.
    /// </summary>
    private StyleDictionary GetStyles() => new(AdditionalAttributes.GetValueOrDefault("style"));

    /// <summary>
    /// Aciona o evento de <see cref="AfterAnimate"/>.
    /// </summary>
    /// <param name="firstRender">Um sinalizador indicando se � a primeira renderiza��o.</param>
    /// <returns>A <see cref="Task"/> que representa a opera��o ass�ncrona.</returns>
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
    /// Remove o estilo que esconde o componente de anima��o.
    /// </summary>
    private void RemoveToHide() => RemoveStyle("opacity");

    /// <summary>
    /// Define o atributo "style" do componente com as propriedades de estilo CSS de anima��o.
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
    /// Adiciona o estilo que esconde o componente de anima��o.
    /// </summary>
    private void ToHide() => SetStyle("opacity:0");
}
