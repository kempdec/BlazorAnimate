namespace BlazorApp.Animate.TimingFunctions;

/// <summary>
/// Representa a função de temporização "ease-out" que proporciona uma animação que começa rápido e desacelera à medida
/// que avança. Não há aceleração no início da animação.
/// </summary>
/// <remarks>É equivalente a cubic-bezier(0.0, 0.0, 0.58, 1.0).</remarks>
public sealed class EaseOutTimingFunction : ITimingFunction
{
    /// <inheritdoc/>
    public string Value { get; } = "ease-out";
}
