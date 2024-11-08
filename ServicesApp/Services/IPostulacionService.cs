public interface IPostulacionService
    {
        void AddPostulacion(Postulacion postulacion);

        Postulacion? GetPostulacionById(int id);
        string RechazarPostulacion(int id, string razon);

        string AceptarPostulacion(int id);
    }