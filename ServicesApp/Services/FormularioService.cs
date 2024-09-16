public class FormularioService : IFormularioService{
   
    private readonly IDocumentoService _documentoService;
    private readonly IDocenteService _docenteService;


    public FormularioService(IDocenteService docenteService, IDocumentoService documentoService)
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

    public void GuardarDatosFormularioDocente(Docente? nuevoDocente, List<Documento>? documentosObligatorios, List<Documento>? documentosOpcionales){
        _docenteService.guardarDatosDocente(nuevoDocente);
        _documentoService.guardarDocumentos(documentosObligatorios, documentosOpcionales);
    }
}