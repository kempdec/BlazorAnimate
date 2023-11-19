using BlazorApp.Animate.Helpers;

namespace BlazorApp.Animate;

/// <summary>
/// Fornece abstração para uma animação.
/// </summary>
public interface IAnimation
{
    /// <summary>
    /// Obtém o nome da animação.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Obtém a duração da animação.
    /// </summary>
    public TimeSpan Duration { get; }

    /// <summary>
    /// Obtém a função de temporização que define como uma animação progride ao longo da duração de cada ciclo.
    /// </summary>
    public ITimingFunction TimingFunction { get; }

    /// <summary>
    /// Obtém o atraso para iniciar a animação.
    /// </summary>
    public TimeSpan Delay { get; }

    /// <summary>
    /// Obtém o modo de preenchimento que define como os estilos são aplicados antes e depois da execução de uma
    /// animação.
    /// </summary>
    public IFillMode FillMode { get; }

    /// <summary>
    /// Obtém um sinalizador indicando se a animação utiliza as definições padrões.
    /// </summary>
    public bool IsDefault { get; }

    /// <summary>
    /// Obtém uma coleção de propriedades de estilo CSS da animação.
    /// </summary>
    /// <returns>Uma coleção de propriedades de estilo CSS da animação.</returns>
    public StyleDictionary GetStyles();
}
