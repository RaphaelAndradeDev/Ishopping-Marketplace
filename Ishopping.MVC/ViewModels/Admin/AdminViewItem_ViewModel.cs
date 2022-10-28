
namespace Ishopping.MVC.ViewModels.Admin
{
    public class AdminViewItem_ViewModel
    {
        public int Id { get; set; }
        public bool OnMenu { get; set; }                                // Se a view vai ser adicionada ao menu da pagina
        public bool Active { get; set; }                                // Ativar este item.                                 
        public string TextMenu { get; set; }                            // Texto que aparecera no menu para esta viewItem
        public string TextView { get; set; }                            // Texto que aparecera na view
        public string ViewTipo { get; set; }                            // Tipo da view Ex: home, portofoli, about, team .. 
        public string Link { get; set; }                                // local onde vai ser redirecionado ao se clicar no item ou no menu 
        public int AdminViewDataId { get; set; }
        public virtual AdminViewData_ViewModel AdminViewData { get; set; }
    }
}
