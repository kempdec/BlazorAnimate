namespace BlazorApp.Animate.TimingFunctions;

/// <summary>
/// Representa a função de temporização "ease" que proporciona uma animação suave, começando devagar, acelerando no
/// meio e desacelerando novamente no final.
/// </summary>
/// <remarks>É equivalente a cubic-bezier(0.25, 0.1, 0.25, 1.0).</remarks>
public sealed class EaseTimingFunction : ITimingFunction
{
    public string Value { get; } = "ease";
}
