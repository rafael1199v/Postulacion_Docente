using PostulacionDocente.ServicesApp.Models;

public class PostulacionService : IPostulacionService
    {
        private readonly Dictionary<int, PostulacionDTO> _postulaciones = new Dictionary<int, PostulacionDTO>();

        public void AddPostulacion(PostulacionDTO postulacion)
        {
            _postulaciones[postulacion.PostulacionId] = postulacion;
        }

        public PostulacionDTO? GetPostulacionById(int id)
        {
            _postulaciones.TryGetValue(id, out var postulacion);
            return postulacion;
        }

        public string RechazarPostulacion(int id, string razon)
        {
            if (_postulaciones.TryGetValue(id, out var postulacion))
            {
                return $"Postulación rechazada: {razon}";
            }
            return "Postulación no encontrada";
        }

        public string AceptarPostulacion(int id)
        {
            if (_postulaciones.TryGetValue(id, out var postulacion))
            {
                return "Postulación aceptada.";
            }
            return "Postulación no encontrada";
        }


        public PostulacionDetallesDTO? ConseguirDetallesPostulacion(PostulacionDocenteContext context, int postulacionId)
        {
            var postulacionDetalle = (from _postulacion in context.Postulacions
                                     join _vacante in context.Vacantes on _postulacion.VacanteId equals _vacante.VacanteId
                                     join _materia in context.Materia on _vacante.MateriaId equals _materia.MateriaId
                                     where _postulacion.PostulacionId == postulacionId
                                     select new PostulacionDetallesDTO {
                                        PostulacionId = _postulacion.PostulacionId,
                                        TituloMateria = _materia.NombreMateria,
                                        Estado = _postulacion.Estado.EstadoId,
                                        DescripcionEstado = _postulacion.Estado.Mensaje,
                                        NombreVacante = _vacante.NombreVacante,
                                        DescripcionVacante = _vacante.Descripcion
                                     }).FirstOrDefault<PostulacionDetallesDTO>();
            

            return postulacionDetalle;
        }

    public List<PostulacionDetallesDTO> ConseguirPostulacionesVigentes(PostulacionDocenteContext context, string CI)
    {
        var docenteId = (from _usuario in context.Usuarios
                        join _docente in context.Docentes on _usuario.UsuarioId equals _docente.UsuarioId
                        where _usuario.Ci == CI
                        select _docente.DocenteId).FirstOrDefault<int>();

        var postulaciones = (from _postulacion in context.Postulacions
                            join _vacante in context.Vacantes on _postulacion.VacanteId equals _vacante.VacanteId
                            join _materia in context.Materia on _vacante.MateriaId equals _materia.MateriaId
                            where _postulacion.DocenteId == docenteId && _postulacion.EstadoId != 5 && _postulacion.EstadoId != 4 && _vacante.FechaFin > DateTime.Now
                            select new PostulacionDetallesDTO {
                                PostulacionId = _postulacion.PostulacionId,
                                TituloMateria = _materia.NombreMateria,
                                Estado = _postulacion.Estado.EstadoId,
                                DescripcionEstado = _postulacion.Estado.Mensaje,
                                NombreVacante = _vacante.NombreVacante,
                                DescripcionVacante = _vacante.Descripcion
                            }).ToList();
        

        return postulaciones;
                            
    }
}
