public interface IFormularioService{
    public void enviarDocumento();
    public bool validarPostulacion();
    public void GuardarDatos(Docente nuevoDocente, List<Documento> documentosObligatorios, List<Documento> documentosOpcionales);
}