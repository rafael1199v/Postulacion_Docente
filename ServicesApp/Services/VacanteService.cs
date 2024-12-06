using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PostulacionDocente.ServicesApp.Models;

public class VacanteService : IVacanteService
{
    public bool EliminarVacante(int vacanteId, PostulacionDocenteContext context)
    {
        System.Console.WriteLine($"La vacante con Id {vacanteId} ha sido eliminada");
        return true;
    }
    public bool ModificarVacante(int vacanteId, VacanteDTO datosNuevosVacante, PostulacionDocenteContext context)
    {
        System.Console.WriteLine($"La vacante con el id {vacanteId} ha sido modificada");
        return true;
    }

    public List<VacanteDTO> ConseguirVacantesDisponibles(PostulacionDocenteContext context)
    {
        // List<VacanteDTO> vacantesDisponibles = new List<VacanteDTO>()
        // {
        //     new VacanteDTO{NombreVacante = "Docente Programacion I"},
        //     new VacanteDTO{NombreVacante = "Medico, Trabajo medio tiempo"},
        //     new VacanteDTO{NombreVacante = "Docente diseño grafico, tiempo completo"}
        // };
        DateTime now = DateTime.Now;

        var vacantesDisponibles = (from _vacante in context.Vacantes
                                  where now < _vacante.FechaFin && now >= _vacante.FechaInicio && (_vacante.Postulacions.Count == 0 || _vacante.Postulacions.Any(p => p.EstadoId != 4))
                                  select new VacanteDTO{
                                    VacanteId = _vacante.VacanteId,
                                    NombreVacante = _vacante.NombreVacante,
                                    Materia = _vacante.Materia.NombreMateria,
                                    DescripcionVacante = _vacante.Descripcion,
                                    FechaInicio = _vacante.FechaInicio,
                                    FechaFinalizacion = _vacante.FechaFin
                                  }).ToList();


        return vacantesDisponibles;
    }

    public bool CrearVacante(VacanteDTO nuevaVacante, PostulacionDocenteContext context)
    {
       
        if(!this.VacanteValida(nuevaVacante))
        {
            return false;
        }

        System.Console.WriteLine(nuevaVacante.NombreVacante);
        System.Console.WriteLine(nuevaVacante.DescripcionVacante);
        System.Console.WriteLine(nuevaVacante.Materia);
        System.Console.WriteLine(nuevaVacante.FechaInicio);
        System.Console.WriteLine(nuevaVacante.FechaFinalizacion);
        //Se guarda en la base de datos

        return true;
    }


    public bool VacanteValida(VacanteDTO nuevaVacante)
    {
         if(nuevaVacante == null)
        {
            return false;
        }

        if(string.IsNullOrEmpty(nuevaVacante.NombreVacante) || string.IsNullOrEmpty(nuevaVacante.Materia)|| string.IsNullOrEmpty(nuevaVacante.DescripcionVacante))
        {
            return false;
        }


        if(nuevaVacante.FechaInicio > nuevaVacante.FechaFinalizacion){
            return false;
        }

        return true;
    }
}