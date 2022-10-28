
namespace Ishopping.Domain.Entities
{
    public class AppView  // views padrão do Ishopping
    {
        public int Id { get; private set; }
        public int ViewCod { get; private set; }                // Código único da view
        public string Action { get; private set; }
        public string Name { get; private set; }                // nome da action ou nome da partial view
        public string PartialView { get; private set; }
        public int Type { get; private set; }                   // type 1 = manutenção
        public int Level { get; private set; }     
               

        protected AppView() { }

        public AppView(string name, string partialView, int type, int level)
        {
            this.Name = name;
            this.PartialView = partialView;
            this.Type = type;
            this.Level = level;
        }

        public AppView(int viewCod, string action, string name, string partialView, int type, int level )
        {
            this.ViewCod = viewCod;
            this.Action = action;
            this.Name = name;
            this.PartialView = partialView;
            this.Type = type;
            this.Level = level;
        }
        
    }
}
