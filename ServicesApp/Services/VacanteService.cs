public class VacanteService : IVacanteService
{
    public void PublicarNuevaVacante(Vacante nuevaVacante)
    {
        System.Console.WriteLine("Nueva VacanteRegistrada");
    }
    public bool EliminarVacante(int vacanteId)
    {
        System.Console.WriteLine($"La vacante con Id {vacanteId} ha sido eliminada");
        return true;
    }
    public bool ModificarVacante(int vacanteId, Vacante datosNuevosVacante)
    {
        System.Console.WriteLine($"La vacante con el id {vacanteId} ha sido modificada");
        return true;
    }

    public List<Vacante> ConseguirVacantesDisponibles()
    {
        List<Vacante> vacantesDisponibles = new List<Vacante>()
        {
            new Vacante{NombreVacante = "Docente Programacion I"},
            new Vacante{NombreVacante = "Medico, Trabajo medio tiempo"},
            new Vacante{NombreVacante = "Docente diseño grafico, tiempo completo"}
        };

        return vacantesDisponibles;
    }
}