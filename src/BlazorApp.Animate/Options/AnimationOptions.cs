namespace BlazorApp.Animate.Options;

/// <summary>
/// Representa as opções para uma animação.
/// </summary>
/// <remarks>Esse tipo pode ser utilizado para definir as opções padrão do componente <see cref="Animate"/>
/// através da injenção de dependência.</remarks>
public sealed class AnimationOptions
{
    /// <summary>
    /// Obtém ou define duração da animação.
    /// </summary>
    public TimeSpan? Duration { get; set; }

    /// <summary>
    /// Obtém ou define a função de temporização que define como uma animação progride ao longo da duração de cada
    /// ciclo.
    /// </summary>
    public ITimingFunction? TimingFunction { get; set; }

    /// <summary>
    /// Obtém ou define o atraso para iniciar a animação.
    /// </summary>
    public TimeSpan? Delay { get; set; }

    /// <summary>
    /// Obtém ou define o modo de preenchimento que define como os estilos são aplicados antes e depois da execução de
    /// uma animação.
    /// </summary>
    public IFillMode? FillMode { get; set; }
}
