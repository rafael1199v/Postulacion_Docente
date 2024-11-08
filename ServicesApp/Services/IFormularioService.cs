public interface IFormularioService{
    public void enviarDocumento();
    public bool validarPostulacion();
        public void GuardarDatosFormularioDocente(Docente? nuevoDocente, List<Documento>? documentos);
}