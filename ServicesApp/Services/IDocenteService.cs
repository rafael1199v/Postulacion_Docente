public interface IDocenteService{
    public void guardarDatosDocente(Docente? nuevoDocente);
    public void verEstado();
    public Docente? conseguirDocente(string CarnetIdentidad);
}