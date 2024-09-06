public interface IDocumentoService
{
    public void guardarDocumentos(List<Documento>? documentosObligatorios, List<Documento>? documentosOpcionales);
    public bool revisarDocumento();
}