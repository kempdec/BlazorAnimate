# BlazorApp Animate

O BlazorApp Animate � uma pequena biblioteca para adicionar facilmente anima��es em um aplicativo Blazor.

## �ndice

- [Instala��o](#instala��o)
- [Importa��o](#importa��o)
- [Adi��o de arquivo](#adi��o-de-arquivo)
- [Como usar](#como-usar)
  - [Componente Animate](#componente-animate)
  - [M�todo extensivo](#m�todo-extensivo)
- [Anima��es dispon�veis](#anima��es-dispon�veis)
- [Fun��es de temporiza��o dispon�veis](#fun��es-de-temporiza��o-dispon�veis)
- [Modos de preenchimento dispon�veis](#modos-de-preenchimento-dispon�veis)
- [Como criar anima��es personalizadas ou mut�veis](#como-criar-anima��es-personalizadas-ou-mut�veis)
- [Autores](#autores)
- [Notas de lan�amento](#notas-de-lan�amento)
- [Licen�a](#licen�a)

## Instala��o

Instale a biblioteca a partir do NuGet.

``` powershell
Install-Package BlazorApp.Animate
```

## Importa��o

Em seu arquivo `_Imports.razor` adicione:

``` razor
@using BlazorApp.Animate
@using static BlazorApp.Animate.Animation
@using static BlazorApp.Animate.FillMode
@using static BlazorApp.Animate.TimingFunction
```

## Adi��o de arquivo

Dentro da sua tag `<head>` adicione:

``` html
<link rel="stylesheet" href="_content/BlazorApp.Animate/animations.min.css">
```

## Como usar

O BlazorApp Animate pode ser utilizado de duas maneiras, uma delas � com o componente `<Animate/>`, e a outra � atrav�s
do atributo `style` de qualquer tag HTML.

### Componente Animate

Coloque o conte�do que voc� deseja animar dentro do componente `<Animate>`, semelhante aos exemplos abaixo:

``` razor
@* Componente sem par�metros, usando a anima��o padr�o (FadeIn). *@
<Animate>
    Texto que ser� animado.
</Animate>

@* Componente com o par�metro Animation, que define a anima��o. *@
<Animate Animation="FadeIn">
    <p>
        Par�grafo que ser� animado.
    </p>
</Animate>

@* Componente com todos os par�metros. Esses s�o os valores padr�es, quando n�o especificados. *@
<Animate Animation="FadeIn" DurationS="0.4" TimingFunction="EaseInOut" DelayS="0.0" FillMode="Both">
    <p>
        Par�grafo que ser� animado.
    </p>
</Animate>

@* Componente com todos os par�metros (TimeSpan). Esses s�o os valores padr�es, quando n�o especificados. *@
<Animate Animation="FadeIn" Duration="TimeSpan.FromSeconds(0.4)" TimingFunction="EaseInOut" Delay="TimeSpan.FromSeconds(0.0)" FillMode="Both">
    <p>
        Par�grafo que ser� animado.
    </p>
</Animate>

@* Tamb�m � poss�vel adicionar qualquer atributo para Animate, como "class" e "style". *@
<Animate class="example-class" style="font-weight: bold;">
    Texto animado em negrito.
</Animate>
```

### M�todo extensivo

Os exemplos abaixo tem um resultado equivalente ao uso com o componente `<Animate/>`, ent�o escolha o que preferir.
Coloque a anima��o no atributo "style" de qualquer tag e use o m�todo extensivo `.With` para personalizar os par�metros.

``` razor
@* Aplicando a anima��o FadeIn em um elemento HTML. *@
<div style="@FadeIn">
    Texto que ser� animado.
</div>

@* Anima��o com todos os par�metros personalizados. Esses s�o os valores padr�es, quando n�o especificados. *@
<p style="@FadeIn.With(0.4, EaseInOut, 0.0, Both)">
    Par�grafo que ser� animado.
</p>

@* Anima��o com todos os par�metros personalizados, usando os par�metros nomeados do C#. Esses s�o os valores padr�es,
quando n�o especificados. *@
<p style="@FadeIn.With(durationS: 0.4, timingFunction: EaseInOut, delayS: 0.0, fillMode: Both)">
    Par�grafo que ser� animado.
</p>

@* Anima��o com todos os par�metros (TimeSpan). Esses s�o os valores padr�es, quando n�o especificados. *@
<p style="@FadeIn.With(TimeSpan.FromSeconds(0.4), EaseInOut, TimeSpan.FromSeconds(0.0), Both)">
    Par�grafo que ser� animado.
</p>

@* Tamb�m � poss�vel usar outras propriedades em "style". *@
<div class="example-class" style="font-weight: bold; @FadeIn">
    Texto animado em negrito.
</div>
```

## Anima��es dispon�veis

As anima��es est�o pr�-constru�das em `BlazorApp.Animate.Animation`, sendo elas:

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

## Fun��es de temporiza��o dispon�veis

As fun��es de temporiza��o est�o pr�-constru�das em `BlazorApp.Animate.TimingFunction`, sendo elas:

- Linear
- Ease
- EaseIn
- EaseOut
- EaseInOut

> Obs.: Tamb�m � poss�vel definir uma fun��o de temporiza��o personalizada usando `CubicBezierTimingFunction`.
> Exemplo:
> ``` razor
> <Animate TimingFunction="new CubicBezierTimingFunction(0.25, 0.1, 0.25, 1.0)"></Animate>
> ```

## Modos de preenchimento dispon�veis

Os modos de preenchimento est�o pr�-constru�das em `BlazorApp.Animate.FillMode`, sendo eles:

- None
- Forwards
- Backwards
- Both

## Como criar anima��es personalizadas ou mut�veis

Para criar uma anima��o personalizada deve implementar `BlazorApp.Animate.IAnimation`, recomendamos fortemente que
herde `BlazorApp.Animate.AnimationBase`. Segue um exemplo:

**Adicione a anima��o com keyframes em seu CSS**
``` css
/* Essa anima��o � apenas um exemplo. */
@keyframes simple-custom {
    0% {
        opacity: 0;
    }

    100% {
        opacity: 1;
    }
}

/* Essa anima��o � apenas um exemplo. */
@keyframes custom {
    0% {
        opacity: 0;
    }

    100% {
        opacity: 1;
    }
}
```

**Crie um tipo C# que implemente `IAnimation` especificando o nome da anima��o criada com keyframes em seu CSS**
``` csharp
// Construtor prim�rio com .NET 8/C# 12.
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

// Construtor prim�rio com .NET 8/C# 12, especificando todos os par�metros.
public sealed class CustomAnimation()
    : AnimationBase(name: "custom", duration: 0.4, timingFunction: EaseInOut, delay: 0.0, fillMode: Both)
{
}

// Construtor comum, especificando todos os par�metros.
public sealed class CustomAnimation : AnimationBase
{
    public CustomAnimation()
        : base(name: "custom", duration: 0.4, timingFunction: EaseInOut, delay: 0.0, fillMode: Both)
    {
    }
}
```

E ent�o use de maneira semelhante ao exemplo abaixo:

``` razor
@* Exemplo com componente. *@
<Animate Animation="new CustomAnimation()">
    Texto a ser animado.
</Animate>

@* Exemplo com m�todo extensivo. *@
<div style="@(new CustomAnimation())">
    Texto a ser animado.
</div>
```

---

Ou voc� pode definir uma classe est�tica com a inst�ncia pr�-constru�da:

``` csharp
public static MyCustomAnimations
{
    public static CustomAnimation Custom { get; } = new();
}
```

Adicionar a importa��o em `_Imports.razor`:

``` razor
@using static MyCustomAnimations
```

E ent�o usar, de maneira semelhante a abaixo:

``` razor
@* Exemplo com componente. *@
<Animate Animation="Custom">
    Texto a ser animado.
</Animate>

@* Exemplo com m�todo extensivo. *@
<div style="@Custom">
    Texto a ser animado.
</div>
```

## Autores

- **[KempDec](https://github.com/kempdec)** - Mantedora do projeto de c�digo aberto.
- **[Vin�cius Lima](https://github.com/viniciusxdl)** - Desenvolvedor .NET C#.

## Notas de lan�amento

Para notas de lan�amento, confira a [se��o de releases do BlazorApp Animate](https://github.com/kempdec/BlazorApp.Animate/releases).

## Licen�a

[MIT](https://github.com/kempdec/BlazorApp.Animate/blob/main/LICENSE)