public interface IPostulanteService
{
    public bool RegistrarPostulante(int docenteId, int vacanteId);
    public bool EliminarPostulacion(int docenteId, int vacanteId);
}