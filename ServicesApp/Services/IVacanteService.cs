public interface IVacanteService
{
    public void PublicarNuevaVacante(Vacante nuevaVacante);
    public bool EliminarVacante(int vacanteId);
    public bool ModificarVacante(int vacanteId, Vacante datosNuevosVacante);
    public List<Vacante> ConseguirVacantesDisponibles();
}