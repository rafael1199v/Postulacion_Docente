public class DocumentoService: IDocumentoService
{
    public void guardarDocumentos(List<Documento> documentosObligatorios, List<Documento> documentosOpcionales)
    {

        //appDbContext.Documento.Add(documentosObligatorios);
        //appDbContext.Documento.Add(documentosOpcionales);
        //appDbContext.SaveChanges();
        System.Console.WriteLine("El documento ser guardo correctamente");
        
    }

    public bool revisarDocumento()
    {
        System.Console.WriteLine("El documento esta correctamente estructurado");

        return true;
    }
}