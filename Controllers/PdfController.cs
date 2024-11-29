
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class PdfController : ControllerBase
{
    private readonly IPdfService _pdfService;

    public PdfController(IPdfService pdfService)
    {
        _pdfService = pdfService;
    }

    [HttpGet("generarPdf/{ci}")]  
    public IActionResult GenerarPdf(string ci)
    {
        //Obtenemos el docente con elCI correspondiente
        //Simulamos
        Docente docente = new Docente{
            nombre = "Rafael Vargas",
            CI = "13331254",
            numero = "12345678",
            correo = "rafael1199@gmail.com",
            contrasenha = "rafael123", //Deberiamos usar un docenteDTO
            materia = "Porgramacion",
            experiencia = 10,
            grado = "Ingeniero"
        };

        var pdfBytes = _pdfService.GenerarPdfDocente(docente);
        
        return File(pdfBytes, "application/pdf", $"Curriculum_{docente.nombre}.pdf");
    }
}