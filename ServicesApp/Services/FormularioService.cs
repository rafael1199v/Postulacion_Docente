public class FormularioService : IFormularioService{
   
    public void enviarDocumento(){
    
        System.Console.WriteLine("Funciona");
        return;
    }

    public bool validarPostulacion()
    {
        System.Console.WriteLine("Postulacion verificada");
        return true;
    }

    public void GuardarDatos(Docente nuevoDocente, List<Documento> documentosObligatorios, List<Documento> documentosOpcionales){
        IDocumentoService IdocumentoService = new DocumentoService();
        IDocenteService IdocenteService = new DocenteService();

        IdocenteService.guardarDatosDocente(nuevoDocente);
        IdocumentoService.guardarDocumentos(documentosObligatorios, documentosOpcionales);

    }
}