public class VacanteService : IVacanteService
{
    public bool EliminarVacante(int vacanteId)
    {
        System.Console.WriteLine($"La vacante con Id {vacanteId} ha sido eliminada");
        return true;
    }
    public bool ModificarVacante(int vacanteId, VacanteDTO datosNuevosVacante)
    {
        System.Console.WriteLine($"La vacante con el id {vacanteId} ha sido modificada");
        return true;
    }

    public List<VacanteDTO> ConseguirVacantesDisponibles()
    {
        List<VacanteDTO> vacantesDisponibles = new List<VacanteDTO>()
        {
            new VacanteDTO{NombreVacante = "Docente Programacion I"},
            new VacanteDTO{NombreVacante = "Medico, Trabajo medio tiempo"},
            new VacanteDTO{NombreVacante = "Docente diseño grafico, tiempo completo"}
        };

        return vacantesDisponibles;
    }

    public bool CrearVacante(VacanteDTO nuevaVacante)
    {
       
        if(!this.VacanteValida(nuevaVacante))
        {
            return false;
        }

        System.Console.WriteLine(nuevaVacante.NombreVacante);
        System.Console.WriteLine(nuevaVacante.DescripcionVacante);
        System.Console.WriteLine(nuevaVacante.Materia);
        System.Console.WriteLine(nuevaVacante.FechaInicion);
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


        if(nuevaVacante.FechaInicion > nuevaVacante.FechaFinalizacion){
            return false;
        }

        return true;
    }
}