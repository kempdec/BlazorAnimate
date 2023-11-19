using BlazorApp.Animate;
using BlazorApp.Animate.Options;
using BlazorApp.Animate.Sample.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Define as opções padrão de animação.
builder.Services.Configure<AnimationOptions>(options =>
{
    options.Duration = TimeSpan.FromSeconds(0.4);
    options.TimingFunction = TimingFunction.EaseInOut;
    options.Delay = TimeSpan.Zero;
    options.FillMode = FillMode.Both;
});

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
