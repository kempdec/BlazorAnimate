namespace BlazorApp.Animate;

/// <summary>
/// Fornece abstração para um modo de preenchimento que define como os estilos são aplicados antes e depois da execução
/// de uma animação.
/// </summary>
public interface IFillMode
{
    /// <summary>
    /// Obtém o valor do modo de preenchimento.
    /// </summary>
    public string Value { get; }
}
