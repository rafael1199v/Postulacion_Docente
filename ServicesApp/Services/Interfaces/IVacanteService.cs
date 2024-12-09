using PostulacionDocente.ServicesApp.Models;

public interface IVacanteService
{
   //Docente
    public List<VacanteDTO> ConseguirVacantesDisponibles(PostulacionDocenteContext context, string CI);
    public VacanteDTO? ConseguirDetalleVacante(PostulacionDocenteContext context, int vacanteId);

    //JefeCarrera
    public List<VacanteJefeCarreraDTO> ConseguirVacantesVigentesJefe(PostulacionDocenteContext context, string CI);
    public bool VacanteValida(VacanteDTO nuevaVacante);
    public bool CrearVacante(VacanteDTO nuevaVacante, PostulacionDocenteContext context);
    public bool EliminarVacante(int vacanteId, PostulacionDocenteContext context);
    public bool ModificarVacante(int vacanteId, VacanteDTO datosNuevosVacante, PostulacionDocenteContext context);

}