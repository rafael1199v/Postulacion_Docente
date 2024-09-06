public class DocumentoService: IDocumentoService
{
    public void guardarDocumentos(List<Documento>? documentosObligatorios, List<Documento>? documentosOpcionales)
    {

        //appDbContext.Documento.Add(documentosObligatorios);
        //appDbContext.Documento.Add(documentosOpcionales);
        //appDbContext.SaveChanges();
        System.Console.WriteLine("Ruta de documentos obligatorios");
        if(documentosObligatorios != null)
            foreach(Documento documento in  documentosObligatorios){
                Console.WriteLine(documento.rutaArchivo);
            }

        System.Console.WriteLine("Ruta de documentos opcionales");
        if(documentosOpcionales != null)
            foreach(Documento documento in documentosOpcionales){
                Console.WriteLine(documento.rutaArchivo);
            }

        System.Console.WriteLine("El documento ser guardo correctamente");
        
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