using System;
using System.Collections.Generic;
using PostulacionDocente.ServicesApp.Models;

public class JefeCarreraService : IJefeCarreraService
{
    private List<(string Nombre, string Curso)> solicitudes = new List<(string Nombre, string Curso)>();
    private List<DateTime> reuniones = new List<DateTime>();

    private JefeDTO rrhh;
    private List<PostulacionDTO> postulacionesPendientes = new List<PostulacionDTO>{}; 

    public JefeCarreraService()
    {
        rrhh = new JefeDTO();
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

    public void RechazarSolicitud(string nombreSolicitud)
    {
        var solicitud = solicitudes.Find(s => s.Nombre == nombreSolicitud);
        if (solicitud.Equals(default((string Nombre, string Curso))))
        {
            Console.WriteLine("La solicitud no se encontró.");
            return;
        }

        solicitudes.Remove(solicitud);
        Console.WriteLine($"Solicitud rechazada para {nombreSolicitud}");
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

    public void VerDatosPostulante(){
        //TODO
    }

    public JefeCarreraPerfilDTO? ConseguirDatosJefeCarrera(PostulacionDocenteContext context, string CI)
    {
        var jefeCarrera = (from _jefeCarrera in context.JefeCarreras
                          join _usuario in context.Usuarios on _jefeCarrera.UsuarioId equals _usuario.UsuarioId
                          where _usuario.Ci == CI
                          select new JefeCarreraPerfilDTO {
                            Nombre = _usuario.Nombre,
                            Correo = _usuario.Correo,
                            Carreras = _jefeCarrera.Carreras.Select(carrera => carrera.NombreCarrera).ToList()
                          }).FirstOrDefault<JefeCarreraPerfilDTO>();


        return jefeCarrera;
    }
}