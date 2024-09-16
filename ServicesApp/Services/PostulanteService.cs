public class PostulanteService : IPostulanteService
{
     public bool RegistrarPostulante(int docenteId, int vacanteId)
    {
        System.Console.WriteLine("Registrado con exito");
        return true;
    }

    public bool EliminarPostulacion(int docenteId, int vacanteId)
    {
        System.Console.WriteLine($"Docente eliminado de la postulacion con id {docenteId} en la vacante con Id {vacanteId}");
        return true;
    }
}