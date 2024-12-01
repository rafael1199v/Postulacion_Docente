public interface IVacanteService
{
    public bool CrearVacante(VacanteDTO nuevaVacante);
    public bool EliminarVacante(int vacanteId);
    public bool ModificarVacante(int vacanteId, VacanteDTO datosNuevosVacante);
    public List<VacanteDTO> ConseguirVacantesDisponibles();
    public bool VacanteValida(VacanteDTO nuevaVacante);
}