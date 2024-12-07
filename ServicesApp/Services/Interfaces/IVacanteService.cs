using PostulacionDocente.ServicesApp.Models;

public interface IVacanteService
{
    public bool CrearVacante(VacanteDTO nuevaVacante, PostulacionDocenteContext context);
    public bool EliminarVacante(int vacanteId, PostulacionDocenteContext context);
    public bool ModificarVacante(int vacanteId, VacanteDTO datosNuevosVacante, PostulacionDocenteContext context);
    public List<VacanteDTO> ConseguirVacantesDisponibles(PostulacionDocenteContext context, string CI);
    public bool VacanteValida(VacanteDTO nuevaVacante);
    public VacanteDTO? ConseguirDetalleVacante(PostulacionDocenteContext context, int vacanteId);
}