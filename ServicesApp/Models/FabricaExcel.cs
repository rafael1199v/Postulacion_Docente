public class FabricaExcel : IFabrica
{
    public IEntidad Crear()
    {
        return new Excel();
    }
}