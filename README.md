# BlazorApp Animate

O BlazorApp Animate é uma biblioteca que pode ser usada para adicionar facilmente animações em um aplicativo Blazor.

## Índice

- [Instalação](#instalação)
- [Importação](#importação)
- [Adição de arquivo](#adição-de-arquivo)
- [Como usar](#como-usar)
  - [Componente Animate](#componente-animate)
  - [Método extensivo](#método-extensivo)
- [Animações disponíveis](#animações-disponíveis)
- [Funções de temporização disponíveis](#funções-de-temporização-disponíveis)
- [Modos de preenchimento disponíveis](#modos-de-preenchimento-disponíveis)
- [Configurando as opções padrão](#configurando-as-opções-padrão)
- [Configurando opções pré-construídas](#configurando-opções-pré-construídas)
- [Como criar animações mutantes](#como-criar-animações-mutantes)
- [Como criar animações personalizadas](#como-criar-animações-personalizadas)
- [Autores](#autores)
- [Notas de lançamento](#notas-de-lançamento)
- [Licença](#licença)

## Instalação

Instale a biblioteca a partir do NuGet.

``` powershell
Install-Package BlazorApp.Animate
```

## Importação

Em seu arquivo `_Imports.razor` adicione:

``` razor
@using BlazorApp.Animate
@using static BlazorApp.Animate.Animation
@using static BlazorApp.Animate.FillMode
@using static BlazorApp.Animate.TimingFunction
```

## Adição de arquivo

Dentro da sua tag `<head>` adicione:

``` html
<link rel="stylesheet" href="_content/BlazorApp.Animate/animations.min.css">
```

## Como usar

O BlazorApp Animate pode ser utilizado de duas maneiras, uma delas é com o componente `<Animate/>`, e a outra é através
do atributo `style` de qualquer tag HTML.

### Componente Animate

Coloque o conteúdo que você deseja animar dentro do componente `<Animate>`, semelhante aos exemplos abaixo:

``` razor
@* Componente sem parâmetros, usando a animação padrão (FadeIn). *@
<Animate>
    Texto que será animado.
</Animate>

@* Componente com o parâmetro Animation, que define a animação. *@
<Animate Animation="FadeIn">
    <p>
        Parágrafo que será animado.
    </p>
</Animate>

@* Componente com todos os parâmetros de animação. Esses são os valores padrões, quando não especificados. *@
<Animate Animation="FadeIn" DurationS="0.4" TimingFunction="EaseInOut" DelayS="0.0" FillMode="Both">
    <p>
        Parágrafo que será animado.
    </p>
</Animate>

@* Componente com todos os parâmetros de animação (TimeSpan). Esses são os valores padrões, quando não especificados. *@
<Animate Animation="FadeIn" Duration="TimeSpan.FromSeconds(0.4)" TimingFunction="EaseInOut" Delay="TimeSpan.Zero" FillMode="Both">
    <p>
        Parágrafo que será animado.
    </p>
</Animate>

@* Também é possível adicionar qualquer atributo para Animate, como "class" e "style". *@
<Animate class="example-class" style="font-weight: bold;">
    Texto animado em negrito.
</Animate>

@* Execute uma ação após a animação ser concluída. *@
<Animate AfterAnimate="firstRender => {}" AfterAnimateDelay="TimeSpan.FromSeconds(0.2)">
    Texto animado com uma ação após ela ser concluída.
</Animate>

@* É possível definir que a animação seja executada somente após a pré-renderização. *@
<Animate AfterPreRenderOnly="true">
    Texto animado que aparecerá somente após a pré-renderização.
</Animate>
```

### Método extensivo

Os exemplos abaixo tem um resultado equivalente ao uso com o componente `<Animate/>`, então escolha o que preferir.
Coloque a animação no atributo "style" de qualquer tag e use o método extensivo `.With()` para personalizar os parâmetros.

``` razor
@* Aplicando a animação FadeIn em um elemento HTML. *@
<div style="@FadeIn">
    Texto que será animado.
</div>

@* Animação com todos os parâmetros personalizados. Esses são os valores padrões, quando não especificados. *@
<p style="@FadeIn.With(0.4, EaseInOut, 0.0, Both)">
    Parágrafo que será animado.
</p>

@* Animação com todos os parâmetros personalizados, usando os parâmetros nomeados do C#. Esses são os valores padrões,
quando não especificados. *@
<p style="@FadeIn.With(durationS: 0.4, timingFunction: EaseInOut, delayS: 0.0, fillMode: Both)">
    Parágrafo que será animado.
</p>

@* Animação com todos os parâmetros (TimeSpan). Esses são os valores padrões, quando não especificados. *@
<p style="@FadeIn.With(TimeSpan.FromSeconds(0.4), EaseInOut, TimeSpan.Zero, Both)">
    Parágrafo que será animado.
</p>

@* Também é possível usar outras propriedades em "style". *@
<div class="example-class" style="font-weight: bold; @FadeIn">
    Texto animado em negrito.
</div>
```

## Animações disponíveis

As animações estão pré-construídas em `BlazorApp.Animate.Animation`, sendo elas:

- FadeIn
- FadeInUp
- FadeInRight
- FadeInDown
- FadeInLeft
---
- SlideInUp
- SlideInRight
- SlideInDown
- SlideInLeft

## Funções de temporização disponíveis

As funções de temporização estão pré-construídas em `BlazorApp.Animate.TimingFunction`, sendo elas:

- Linear
- Ease
- EaseIn
- EaseOut
- EaseInOut

> Obs.: Também é possível definir uma função de temporização personalizada usando `CubicBezierTimingFunction`.
> Exemplo:
> ``` razor
> <Animate TimingFunction="new CubicBezierTimingFunction(0.25, 0.1, 0.25, 1.0)"></Animate>
> ```

## Modos de preenchimento disponíveis

Os modos de preenchimento estão pré-construídas em `BlazorApp.Animate.FillMode`, sendo eles:

- None
- Forwards
- Backwards
- Both

## Configurando as opções padrão

É possível definir as opções padrão de animação para serem utilizadas no componente `<Animate/>` ou com o método
extensivo `.With()`, em seu `Program.cs` configure de maneira semelhante a abaixo:

``` csharp
builder.Services.Configure<AnimationOptions>(options =>
{
    options.Duration = TimeSpan.FromSeconds(0.4);
    options.TimingFunction = TimingFunction.EaseInOut;
    options.Delay = TimeSpan.Zero;
    options.FillMode = FillMode.Both;
});
```

E então utilize:

``` razor
@* Não é necessário fazer mais nada para as opções padrão serem aplicadas ao componente. *@
<Animate></Animate>

@* É necessário especificar as opções no método extensivo. *@
@inject IOptionsSnapshot<AnimaitonOptions> options

<div style="@FadeIn.With(options)"></div>
```

## Configurando opções pré-construídas

É possível definir opções de animação pré-construídas para serem aplicadas ao componente `<Animate/>` ou método
extensivo `.With()`.

``` csharp
public static AnimationOpts
{
    public static AnimationOptions My { get; } = new()
    {
        Duration = TimeSpan.FromSeconds(0.4),
        TimingFunction = TimingFunction.EaseInOut,
        Delay = TimeSpan.Zero,
        FillMode = FillMode.Both
    };
}
```

E então é possível utilizar da seguinte maneira:

``` razor
@* Especificar em componentes. *@
<Animate Options="AnimationOpts.My"></Animate>

@* Especificar em método extensivo. *@
<div style="@FadeIn.With(AnimationOpts.My)"></div>
```

## Como criar animações mutantes

As animações mutantes servem para poder criar outras animações a partir de uma já existente, alterando somente as
propriedades desejadas. Segue o exemplo:

``` csharp
_ = Animation.FadeIn.Name; // "fade-in".
_ = Animation.FadeIn.Duration; // TimeSpan.FromSeconds(0.4).
_ = Animation.FadeIn.TimingFunction; // TimingFunction.EaseInOut.
_ = Animation.FadeIn.Delay; // TimeSpan.Zero.
_ = Animation.FadeIn.FillMode; // FillMode.Both.

// Criando uma nova animação, a partir da mutação de FadeIn.
var newAnimation = new MutantAnimation(Animation.FadeIn, durationS: 1.0, delayS: 0.7);

_ = newAnimation.FadeIn.Name; // "fade-in".
_ = newAnimation.FadeIn.Duration; // TimeSpan.FromSeconds(1.0).
_ = newAnimation.FadeIn.TimingFunction; // TimingFunction.EaseInOut.
_ = newAnimation.FadeIn.Delay; // TimeSpan.FromSeconds(0.7).
_ = newAnimation.FadeIn.FillMode; // FillMode.Both.
```

## Como criar animações personalizadas

**Adicione a animação com keyframes em seu CSS**
``` css
/* Essa animação é apenas um exemplo. */
@keyframes simple-custom {
    0% {
        opacity: 0;
    }

    100% {
        opacity: 1;
    }
}

/* Essa animação é apenas um exemplo. */
@keyframes custom {
    0% {
        opacity: 0;
    }

    100% {
        opacity: 1;
    }
}
```

Para criar uma animação personalizada deve implementar `BlazorApp.Animate.IAnimation`, recomendamos fortemente que
herde `BlazorApp.Animate.AnimationBase`. Segue um exemplo:

**Crie um tipo C# que implemente `IAnimation` especificando o nome da animação criada com keyframes em seu CSS**
``` csharp
// Construtor primário com .NET 8/C# 12.
public sealed class SimpleCustomAnimation() : AnimationBase(name: "simple-custom")
{
}

// Construtor comum.
public sealed class SimpleCustomAnimation : AnimationBase
{
    public SimpleCustomAnimation() : base(name: "simple-custom")
    {
    }
}

// Construtor primário com .NET 8/C# 12, especificando todos os parâmetros.
public sealed class CustomAnimation()
    : AnimationBase(name: "custom", duration: 0.4, timingFunction: EaseInOut, delay: 0.0, fillMode: Both)
{
}

// Construtor comum, especificando todos os parâmetros.
public sealed class CustomAnimation : AnimationBase
{
    public CustomAnimation()
        : base(name: "custom", duration: 0.4, timingFunction: EaseInOut, delay: 0.0, fillMode: Both)
    {
    }
}
```

E então use de maneira semelhante ao exemplo abaixo:

``` razor
@* Exemplo com componente. *@
<Animate Animation="new CustomAnimation()">
    Texto a ser animado.
</Animate>

@* Exemplo com método extensivo. *@
<div style="@(new CustomAnimation())">
    Texto a ser animado.
</div>
```

---

Ou você pode definir uma classe estática com a instância pré-construída:

``` csharp
public static MyCustomAnimations
{
    public static CustomAnimation Custom { get; } = new();
}
```

Adicionar a importação em `_Imports.razor`:

``` razor
@using static MyCustomAnimations
```

E então usar, de maneira semelhante a abaixo:

``` razor
@* Exemplo com componente. *@
<Animate Animation="Custom">
    Texto a ser animado.
</Animate>

@* Exemplo com método extensivo. *@
<div style="@Custom">
    Texto a ser animado.
</div>
```

## Autores

- **[KempDec](https://github.com/kempdec)** - Mantedora do projeto de código aberto.
- **[Vinícius Lima](https://github.com/viniciusxdl)** - Desenvolvedor .NET C#.

## Notas de lançamento

Para notas de lançamento, confira a [seção de releases do BlazorApp Animate](https://github.com/kempdec/BlazorApp.Animate/releases).

## Licença

[MIT](https://github.com/kempdec/BlazorApp.Animate/blob/main/LICENSE)
