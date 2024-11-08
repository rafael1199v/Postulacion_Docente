public interface IVacanteService
{
    public bool CrearVacante(Vacante nuevaVacante);
    public bool EliminarVacante(int vacanteId);
    public bool ModificarVacante(int vacanteId, Vacante datosNuevosVacante);
    public List<Vacante> ConseguirVacantesDisponibles();
    public bool VacanteValida(Vacante nuevaVacante);
}