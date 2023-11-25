namespace KempDec.BlazorAnimate.FillModes;

/// <summary>
/// Representa o modo de preenchimento "backwards" que define que o elemento receberá os estilos iniciais da animação
/// antes do início da mesma.
/// </summary>
public sealed class BackwardsFillMode : IFillMode
{
    /// <inheritdoc/>
    public string Value { get; } = "backwards";
}
