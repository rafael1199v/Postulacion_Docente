using System;
using System.Collections.Generic;

public class RRHHService : IRRHHService
{
    private List<(string Nombre, string Curso)> solicitudes = new List<(string Nombre, string Curso)>();
    private List<DateTime> reuniones = new List<DateTime>();

    public void Horario()
    {
        var horarios = new List<string>
        {
            "Lunes: 09:00 - 17:00",
            "Martes: 09:00 - 17:00",
            "Miércoles: 09:00 - 17:00",
            "Jueves: 09:00 - 17:00",
            "Viernes: 09:00 - 15:00"
        };

        Console.WriteLine("Horarios del personal:");
        foreach (var horario in horarios)
        {
            Console.WriteLine(horario);
        }
    }

    public void CrearReunion(DateTime fecha)
    {
        if (fecha < DateTime.Now)
        {
            Console.WriteLine("La fecha de la reunión no puede ser en el pasado.");
            return;
        }

        reuniones.Add(fecha);
        Console.WriteLine($"Reunión creada para el {fecha}");
    }

    public void VerSolicitudes()
    {
        Console.WriteLine("Solicitudes recibidas:");
        if (solicitudes.Count == 0)
        {
            Console.WriteLine("No hay solicitudes disponibles.");
            return;
        }

        foreach (var solicitud in solicitudes)
        {
            Console.WriteLine($"Nombre: {solicitud.Nombre}, Curso: {solicitud.Curso}");
        }
    }

    public void AceptarSolicitud(string nombreSolicitud)
    {
        var solicitud = solicitudes.Find(s => s.Nombre == nombreSolicitud);
        if (solicitud.Equals(default((string Nombre, string Curso))))
        {
            Console.WriteLine("La solicitud no se encontró.");
            return;
        }

        solicitudes.Remove(solicitud);
        Console.WriteLine($"Solicitud aceptada para {nombreSolicitud}");
    }
}
