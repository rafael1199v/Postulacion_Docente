var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IPostulacionService, PostulacionService>();
builder.Services.AddScoped<IFormularioService, FormularioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IDocenteService, DocenteService>();
builder.Services.AddScoped<IDocumentoService, DocumentoService>();
builder.Services.AddScoped<IVacanteService, VacanteService>();
builder.Services.AddScoped<IPostulanteService, PostulanteService>();
builder.Services.AddScoped<INotificacionService, NotificacionService>();
builder.Services.AddScoped<IJefeCarreraService, JefeCarreraService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var postulacionService = serviceProvider.GetRequiredService<IPostulacionService>();

    postulacionService.AddPostulacion(new Postulacion { PostulacionId = 1, MateriaId = 101, JefeCarreraId = 1001, Estado = "Pendiente" });
    postulacionService.AddPostulacion(new Postulacion { PostulacionId = 2, MateriaId = 102, JefeCarreraId = 1002, Estado = "Aceptada" });
    postulacionService.AddPostulacion(new Postulacion { PostulacionId = 3, MateriaId = 103, JefeCarreraId = 1003, Estado = "Rechazada" });
}

if (!app.Environment.IsDevelopment())
{

}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
