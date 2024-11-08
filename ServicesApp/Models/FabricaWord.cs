public class FabricaWord : IFabrica
{
    public IEntidad Crear()
    {
        return new Word();
    }
}