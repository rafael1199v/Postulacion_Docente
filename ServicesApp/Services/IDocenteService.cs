public interface IDocenteService{
    public void guardarDatosDocente(Docente? nuevoDocente);
    public string VerEstado(int DocenteID, int VacanteID)
    {
        return "";
    }
    public Docente? conseguirDocente(string CarnetIdentidad);
}