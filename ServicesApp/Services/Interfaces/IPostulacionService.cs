public interface IPostulacionService
    {
        void AddPostulacion(PostulacionDTO postulacion);

        PostulacionDTO? GetPostulacionById(int id);
        string RechazarPostulacion(int id, string razon);

        string AceptarPostulacion(int id);

    }