using System.Reflection.Metadata;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

public class PdfService : IPdfService
{
    public byte[] GenerarPdfDocente(DocenteDTO docente)
    {
        var documento = QuestPDF.Fluent.Document.Create(container => {
            container.Page(page =>
            {
                page.MarginHorizontal(40);
                page.MarginVertical(60);

                page.Header()
                    .Height(60)
                    .Background(Colors.Grey.Lighten1)
                    .AlignCenter()
                    .AlignMiddle()
                    .Text("Curriculum");

                page.Content()
                    .Background(Colors.Grey.Lighten2)
                    .Text(text => 
                    {
                        text.Line($"Nombre: {docente.nombre}");
                        text.Line($"CI: {docente.CI}");
                        text.Line($"Numero: {docente.numero}");
                        text.Line($"Correo: {docente.correo}");
                        text.Line($"Grado: {docente.grado}");
                        text.Line($"Años de experiencia: {docente.experiencia}");
                        text.Line($"Especialidad: {docente.materia}");
                    });

                page.Footer()
                    .Height(30)
                    .Background(Colors.Grey.Lighten1)
                    .AlignCenter()
                    .AlignMiddle()
                    .Text("Plagio?");
            });
        });

        //documento.ShowInPreviewer();
        using var stream = new MemoryStream();
        documento.GeneratePdf(stream);

        return stream.ToArray();
    }
}