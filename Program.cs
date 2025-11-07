var builder = WebApplication.CreateBuilder(args);

// Configuração de Serviços (Services Configuration)
// Deve vir antes de builder.Build()

// Adiciona serviços de sessão com opções
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Adiciona serviços para Controllers com Views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do Pipeline de Requisição (Middleware)
// Deve vir depois de app.Build()

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padrão do HSTS é 30 dias.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Sessão deve vir depois de UseRouting()
// e antes de UseAuthorization() ou MapControllerRoute()
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();