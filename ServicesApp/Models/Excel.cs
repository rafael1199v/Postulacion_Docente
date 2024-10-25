public class Excel : Documento, IEntidad
{
    public Documento Parse()
    {
        return new Excel();
    }
}