public class FabricaPdf : IFabrica{
    public IEntidad Crear(){
        return new Pdf();
    }
}