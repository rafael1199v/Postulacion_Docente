public interface IReunionAvanzadaService : IReunionService
{
    void AgregarParticipante(Reunion NuevaReunion, string participante);
    void EliminarParticipante(Reunion NuevaReunion, string participante);
}
