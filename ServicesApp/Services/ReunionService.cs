public class ReunionService : IReunionService
{
    private readonly List<Reunion> _reuniones = new List<Reunion>();

    public bool CrearReunion(Reunion NuevaReunion)
    {
        if (!ValidarReunion(NuevaReunion))
        {
            return false;
        }

        Console.WriteLine($"Descripción: {NuevaReunion.Descripcion}");
        Console.WriteLine($"Fecha: {NuevaReunion.Fecha}");
        Console.WriteLine($"Hora: {NuevaReunion.Hora}");
        Console.WriteLine($"Lugar: {NuevaReunion.Lugar}");
        Console.WriteLine($"Participantes: {string.Join(", ", NuevaReunion.Participantes)}");
        Console.WriteLine($"Duración: {NuevaReunion.Duracion}");
        Console.WriteLine($"Tipo de reunión: {NuevaReunion.TipoReunion}");

        _reuniones.Add(NuevaReunion);
        return true;
    }

    public bool ValidarReunion(Reunion NuevaReunion)
    {
        if (NuevaReunion == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(NuevaReunion.Descripcion) || string.IsNullOrEmpty(NuevaReunion.Lugar))
        {
            return false;
        }

        if (NuevaReunion.Fecha == DateTime.MinValue || NuevaReunion.Hora == TimeSpan.Zero)
        {
            return false;
        }

        return true;
    }
}
