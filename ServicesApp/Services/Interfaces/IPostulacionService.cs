using PostulacionDocente.ServicesApp.Models;

public interface IPostulacionService
    {
        void AddPostulacion(PostulacionDTO postulacion);

        PostulacionDTO? GetPostulacionById(int id);
        string RechazarPostulacion(int id, string razon);

        string AceptarPostulacion(int id);

        public PostulacionDetallesDTO? ConseguirDetallesPostulacion(PostulacionDocenteContext context, int postulacionId);
        public List<PostulacionDetallesDTO> ConseguirPostulacionesVigentes(PostulacionDocenteContext context, string CI);

    }