
namespace Ishopping.MVC.Models.Communs
{
    public class _GalleryViewModel
    {
        public string View { get; set; }                // Nome da view
        public string FileName { get; set; }            // Nome da imagem        
        public int TamanhoIm { get; set; }              // Tamanho em Bytes
        public int FileType { get; set; }               // se o arquivo de imagem vai ser usado em imagem normal, icone png ou para produtos  
        public int Folder { get; set; }
        public int Position { get; set; }
    }
}
