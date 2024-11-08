public class CurriculumService : ICurriculumService{
   
    private readonly IDocumentoService _documentoService;
    private readonly IDocenteService _docenteService;


    public CurriculumService(IDocenteService docenteService, IDocumentoService documentoService)
    {
        _docenteService = docenteService;
        _documentoService = documentoService;
    }

    public void enviarDocumento(){
    
        System.Console.WriteLine("Funciona");
        return;
    }

    public bool validarPostulacion()
    {
        System.Console.WriteLine("Postulacion verificada");
        return true;
    }

    public void GuardarCurriculumDocente(Docente? nuevoDocente, List<Documento>? documentos){
        _docenteService.guardarDatosDocente(nuevoDocente);
        _documentoService.guardarDocumentos(documentos);
    }
}