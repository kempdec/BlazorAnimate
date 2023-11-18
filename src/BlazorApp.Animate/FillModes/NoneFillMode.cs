namespace BlazorApp.Animate.FillModes;

/// <summary>
/// Representa o modo de preenchimento "none" que define que o elemento não terá estilos aplicados antes ou depois da
/// animação. Os estilos são aplicados apenas durante a execução da animação.
/// </summary>
public sealed class NoneFillMode : IFillMode
{
    public string Value { get; } = "none";
}
