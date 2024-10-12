using System;
using System.Collections.Generic;

public class JefeCarreraService : IJefeCarreraService
{
    private List<(string Nombre, string Curso)> solicitudes = new List<(string Nombre, string Curso)>();
    private List<DateTime> reuniones = new List<DateTime>();

    private Jefe rrhh;
    private List<Postulacion> postulacionesPendientes = new List<Postulacion>{}; 

    public JefeCarreraService()
    {
        rrhh = new Jefe();
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

    // Nuevos métodos implementados para obtener listas
    public List<(string Nombre, string Curso)> ObtenerSolicitudes()
    {
                Console.WriteLine("Solicitudes recibidas:");
        if (solicitudes.Count == 0)
        {
            Console.WriteLine("No hay solicitudes disponibles.");
            return solicitudes;
        }

        foreach (var solicitud in solicitudes)
        {
            Console.WriteLine($"Nombre: {solicitud.Nombre}, Curso: {solicitud.Curso}");
        }
        return solicitudes;
    }

    public string VerDatosPostulante(Formulario formulario){

        string result = $"Datos del docente \"{formulario.postulante.datosPersonales.nombre}\":\n";
        result += $"Materia: {formulario.postulante.materia}\n";
        result += $"Años de experiencia: {formulario.postulante.experiencia}\n";
        result += $"Grado de especialidad: {formulario.postulante.grado}\n";
        result += $"Correo: {formulario.postulante.datosPersonales.correo}\n";
        result += $"Numero de teléfono: {formulario.postulante.datosPersonales.numero}\n";

        return result;
    }

}