using BlazorApp.Animate.Animations;

namespace BlazorApp.Animate;

/// <summary>
/// Fornece instâncias <see cref="IAnimation"/> pré-construídas que podem ser usadas para definir a animação.
/// </summary>
public static class Animation
{
    #region Fade.

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento gradual (Fade in).
    /// </summary>
    public static FadeInAnimation FadeIn { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento gradual para cima (Fade in Up).
    /// </summary>
    public static FadeInUpAnimation FadeInUp { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento gradual para cima (Fade in Right).
    /// </summary>
    public static FadeInRightAnimation FadeInRight { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento gradual para cima (Fade in Down).
    /// </summary>
    public static FadeInDownAnimation FadeInDown { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento gradual para cima (Fade in Left).
    /// </summary>
    public static FadeInLeftAnimation FadeInLeft { get; } = new();

    #endregion

    #region Slide.

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento deslizante para cima (Slide in Up).
    /// </summary>
    public static SlideInUpAnimation SlideInUp { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento deslizante para a direita (Slide in
    /// Right).
    /// </summary>
    public static SlideInRightAnimation SlideInRight { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento deslizante para baixo (Slide in
    /// Down).
    /// </summary>
    public static SlideInDownAnimation SlideInDown { get; } = new();

    /// <summary>
    /// Obtém um <see cref="IAnimation"/> que representa a animação de aparecimento deslizante para a esquerda (Slide
    /// in Left).
    /// </summary>
    public static SlideInLeftAnimation SlideInLeft { get; } = new();

    #endregion
}
