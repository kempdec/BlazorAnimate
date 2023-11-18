namespace BlazorApp.Animate.TimingFunctions;

/// <summary>
/// Representa a função de temporização "linear" que proporciona uma animação constante ao longo do tempo, sem
/// aceleração ou desaceleração.
/// </summary>
/// <remarks>É equivalente a cubic-bezier(0.0, 0.0, 1.0, 1.0).</remarks>
public sealed class LinearTimingFunction : ITimingFunction
{
    public string Value { get; } = "linear";
}
