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
    }
