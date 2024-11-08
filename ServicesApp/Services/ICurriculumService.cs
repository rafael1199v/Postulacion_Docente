public interface ICurriculumService{
    public void enviarDocumento();
    public bool validarPostulacion();
        public void GuardarCurriculumDocente(Docente? nuevoDocente, List<Documento>? documentos);
}