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
                                        TituloMateria = _materia.NombreMateria,
                                        Estado = _postulacion.Estado.EstadoId,
                                        DescripcionEstado = _postulacion.Estado.Mensaje,
                                        NombreVacante = _vacante.NombreVacante,
                                        DescripcionVacante = _vacante.Descripcion
                                     }).FirstOrDefault<PostulacionDetallesDTO>();
            

            return postulacionDetalle;
        }

    }
