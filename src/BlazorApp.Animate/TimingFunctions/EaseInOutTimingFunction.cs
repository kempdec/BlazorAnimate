namespace BlazorApp.Animate.TimingFunctions;

/// <summary>
/// Representa a função de temporização "ease-in-out" que proporciona uma animação que acelera suavemente no início,
/// tem uma velocidade constante no meio e desacelera suavemente no final.
/// </summary>
/// <remarks>É equivalente a cubic-bezier(0.42, 0, 0.58, 1.0).</remarks>
public sealed class EaseInOutTimingFunction : ITimingFunction
{
    /// <inheritdoc/>
    public string Value { get; } = "ease-in-out";
}
