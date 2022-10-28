
namespace Ishopping.Domain.Entities
{
    public class SupportInfo
    {
        public int Id { get; private set; }
        public int Reference { get; private set; }              // A que informação ela se refere. Ex: 1 - Ishopping, 2 - PagSeguro.
        public int IntCod { get; private set; }                 // Código enviado pelo objeto de referencia
        public string StrCod { get; private set; }              // Código enviado pelo objeto de referencia em caso de string
        public string Information { get; private set; }         // Informação sobre o código

        // Ctor
        protected SupportInfo() { }
        public SupportInfo(int reference, int intCod, string strCod, string information)
        {
            this.Reference = reference;
            this.IntCod = intCod;
            this.StrCod = strCod;
            this.Information = information;
        }
      
    }
}
