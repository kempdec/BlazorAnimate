using BlazorApp.Animate.TimingFunctions;

namespace BlazorApp.Animate;

/// <summary>
/// Fornece instâncias <see cref="ITimingFunction"/> pré-constrúidas que podem ser usadas para definir uma função de
/// temporização que define como uma animação progride ao longo da duração de cada ciclo.
/// </summary>
public static class TimingFunction
{
    /// <summary>
    /// Obtém um <see cref="ITimingFunction"/> que representa a função de temporização "linear" que proporciona uma
    /// animação constante ao longo do tempo, sem aceleração ou desaceleração.
    /// </summary>
    /// <remarks>É equivalente a cubic-bezier(0.0, 0.0, 1.0, 1.0).</remarks>
    public static LinearTimingFunction Linear { get; } = new();

    /// <summary>
    /// Obtém um <see cref="ITimingFunction"/> que representa a função de temporização "ease" que proporciona uma
    /// animação suave, começando devagar, acelerando no meio e desacelerando novamente no final.
    /// </summary>
    /// <remarks>É equivalente a cubic-bezier(0.25, 0.1, 0.25, 1.0).</remarks>
    public static EaseTimingFunction Ease { get; } = new();

    /// <summary>
    /// Obtém um <see cref="ITimingFunction"/> que representa a função de temporização "ease-in" que proporciona uma
    /// animação que começa devagar e acelera à medida que avança. Não há desaceleração no final da animação.
    /// </summary>
    /// <remarks>É equivalente a cubic-bezier(0.42, 0, 1.0, 1.0).</remarks>
    public static EaseInTimingFunction EaseIn { get; } = new();

    /// <summary>
    /// Obtém um <see cref="ITimingFunction"/> que representa a função de temporização "ease-out" que proporciona uma
    /// animação que começa rápido e desacelera à medida que avança. Não há aceleração no início da animação.
    /// </summary>
    /// <remarks>É equivalente a cubic-bezier(0.0, 0.0, 0.58, 1.0).</remarks>
    public static EaseOutTimingFunction EaseOut { get; } = new();

    /// <summary>
    /// Obtém um <see cref="ITimingFunction"/> que representa a função de temporização "ease-in-out" que proporciona
    /// uma animação que acelera suavemente no início, tem uma velocidade constante no meio e desacelera suavemente no
    /// final.
    /// </summary>
    /// <remarks>É equivalente a cubic-bezier(0.42, 0, 0.58, 1.0).</remarks>
    public static EaseInOutTimingFunction EaseInOut { get; } = new();
}
