using PostulacionDocente.ServicesApp.Models;

public interface IDocenteService{
    public void guardarDatosDocente(DocenteDTO? nuevoDocente);
    public void verEstado();
    public DocenteDTO? conseguirDocente(string CarnetIdentidad);
    public DocentePerfilDTO? ConseguirDetallesDocente(PostulacionDocenteContext context, string usuarioCI);
}