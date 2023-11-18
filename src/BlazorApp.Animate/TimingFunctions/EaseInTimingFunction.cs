namespace BlazorApp.Animate.TimingFunctions;

/// <summary>
/// Representa a função de temporização "ease-in" que proporciona uma animação que começa devagar e acelera à medida
/// que avança. Não há desaceleração no final da animação.
/// </summary>
/// <remarks>É equivalente a cubic-bezier(0.42, 0, 1.0, 1.0).</remarks>
public sealed class EaseInTimingFunction : ITimingFunction
{
    public string Value { get; } = "ease-in";
}
