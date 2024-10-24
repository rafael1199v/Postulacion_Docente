public class VacanteService : IVacanteService
{
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

    public bool CrearVacante(Vacante nuevaVacante)
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


    public bool VacanteValida(Vacante nuevaVacante)
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