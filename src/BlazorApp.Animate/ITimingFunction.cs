namespace BlazorApp.Animate;

/// <summary>
/// Fornece abstração para uma função de temporização que define como uma animação progride ao longo da duração de
/// cada ciclo.
/// </summary>
public interface ITimingFunction
{
    /// <summary>
    /// O valor da função de temporização.
    /// </summary>
    public string Value { get; }
}
