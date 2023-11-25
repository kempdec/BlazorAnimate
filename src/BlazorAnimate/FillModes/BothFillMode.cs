namespace KempDec.BlazorAnimate.FillModes;

/// <summary>
/// Representa o modo de preenchimento "both" que define que o elemento receberá os estilos iniciais antes da animação
/// começar e manterá os estilos finais após a conclusão da mesma.
/// </summary>
public sealed class BothFillMode : IFillMode
{
    /// <inheritdoc/>
    public string Value { get; } = "both";
}
