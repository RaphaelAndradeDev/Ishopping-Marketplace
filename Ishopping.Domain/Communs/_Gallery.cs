
namespace Ishopping.Domain.Communs
{
    public abstract class _Gallery
    {
        public int ViewCod { get; protected set; }
        public int Folder { get; protected set; }       
        public string FileName { get; protected set; }                
        public int TamanhoImg { get; protected set; }             
        public int FileType { get; protected set; }            
        public int Position { get; protected set; }
    }
}
