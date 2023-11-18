using BlazorApp.Animate.FillModes;

namespace BlazorApp.Animate;

/// <summary>
/// Fornece instâncias de <see cref="IFillMode"/> pré-construídas que podem ser usadas para definir o modo de
/// preenchimento que define como os estilos são aplicados antes e depois da execução de uma animação.
/// </summary>
public static class FillMode
{
    /// <summary>
    /// Obtém um <see cref="IFillMode"/> que representa o modo de preenchimento "none" que define que o elemento não
    /// terá estilos aplicados antes ou depois da animação. Os estilos são aplicados apenas durante a execução da
    /// animação.
    /// </summary>
    public static NoneFillMode None { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IFillMode"/> que representa o modo de preenchimento "forwards" que define que o elemento
    /// manterá os estilos finais da animação após a sua conclusão.
    /// </summary>
    public static ForwardsFillMode Forwards { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IFillMode"/> que representa o modo de preenchimento "backwards" que define que o elemento
    /// receberá os estilos iniciais da animação antes do início da mesma.
    /// </summary>
    public static BackwardsFillMode Backwards { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IFillMode"/> que representa o modo de preenchimento "both" que define que o elemento
    /// receberá os estilos iniciais antes da animação começar e manterá os estilos finais após a conclusão da mesma.
    /// </summary>
    public static BothFillMode Both { get; } = new();
}
