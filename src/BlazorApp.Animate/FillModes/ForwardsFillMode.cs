namespace BlazorApp.Animate.FillModes;

/// <summary>
/// Representa o modo de preenchimento "forwards" que define que o elemento manterá os estilos finais da animação após
/// a sua conclusão.
/// </summary>
public sealed class ForwardsFillMode : IFillMode
{
    public string Value { get; } = "forwards";
}
