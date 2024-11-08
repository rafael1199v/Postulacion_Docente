public class DocumentoService: IDocumentoService
{
    public void guardarDocumentos(List<Documento>? documentos)
    {

        //appDbContext.Documento.Add(documentosObligatorios);
        //appDbContext.Documento.Add(documentosOpcionales);
        //appDbContext.SaveChanges();
        System.Console.WriteLine("Ruta de documentos obligatorios");
        if(documentos != null)
            foreach(Documento documento in  documentos){
                Console.WriteLine(documento.rutaArchivo);
            }

        
    }

    public bool revisarDocumento()
    {
        System.Console.WriteLine("El documento esta correctamente estructurado");

        return true;
    }

    // public bool eliminarDocumento(int documentoI)
    // {
    //     System.Console.WriteLine("Documento Eliminado");
    //     return true;
    // }
}