namespace KempDec.BlazorAnimate.Helpers;

/// <summary>
/// Representa uma coleção de propriedades de estilo CSS.
/// </summary>
public sealed class StyleDictionary : Dictionary<string, string>
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="StyleDictionary"/>.
    /// </summary>
    /// <param name="style">O estilo CSS.</param>
    public StyleDictionary(string? style = null)
    {
        if (style is null)
        {
            return;
        }

        IEnumerable<(string Key, string Value)> styles =
            style.Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(SplitProperty);

        foreach ((string key, string value) in styles)
        {
            Add(key, value);
        }
    }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="StyleDictionary"/>.
    /// </summary>
    /// <param name="style">O estilo CSS.</param>
    public StyleDictionary(object? style) : this(style?.ToString())
    {
    }

    /// <summary>
    /// Adiciona a propriedade de estilo CSS especificada.
    /// </summary>
    /// <param name="property">A propriedade de estilo CSS a ser adicionada.</param>
    /// <exception cref="ArgumentException">É lançado quando <paramref name="property"/> não tem o separador
    /// : (dois pontos).</exception>
    public void Add(string? property)
    {
        if (property is null)
        {
            return;
        }

        (string key, string value) = SplitProperty(property);

        Add(key, value);
    }

    /// <summary>
    /// Define a propriedade de estilo CSS especificada. Caso a propriedade já exista, substitui.
    /// </summary>
    /// <param name="property">A propriedade de estilo CSS a ser definida.</param>
    /// <exception cref="ArgumentException">É lançado quando <paramref name="property"/> não tem o separador
    /// : (dois pontos).</exception>
    public void Set(string? property)
    {
        if (property is null)
        {
            return;
        }

        (string key, string value) = SplitProperty(property);

        Set(key, value);
    }

    /// <summary>
    /// Define uma propriedade de estilo CSS. Caso a propriedade já exista, substitui.
    /// </summary>
    /// <param name="key">A chave da propriedade.</param>
    /// <param name="value">O valor da propriedade.</param>
    public void Set(string key, object? value)
    {
        Remove(key);
        Add(key, value?.ToString() ?? string.Empty);
    }

    /// <summary>
    /// Separa e retorna a chave e valor de uma propriedade CSS.
    /// </summary>
    /// <param name="property">A propriedade CSS a ser separada.</param>
    /// <returns>A chave e valor de uma propriedade CSS</returns>
    /// <exception cref="ArgumentException">É lançado quando <paramref name="property"/> não tem o separador
    /// : (dois pontos).</exception>
    private static (string Key, string Value) SplitProperty(string? property)
    {
        if (property is null)
        {
            return (string.Empty, string.Empty);
        }

        if (!property.Contains(':'))
        {
            throw new ArgumentException("A propriedade não tem o separador : (dois pontos).", nameof(property));
        }

        string[] properties = property.Split(':');

        return (properties[0].Trim(), properties[1].Trim());
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        IEnumerable<string> styles = this.Select(e => $"{e.Key}:{e.Value}");

        return string.Join(';', styles);
    }
}
