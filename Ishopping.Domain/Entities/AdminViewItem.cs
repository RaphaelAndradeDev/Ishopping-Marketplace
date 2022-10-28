using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Entities
{
    public class AdminViewItem
    {
        public int Id { get; set; }
        public bool OnMenu { get; set; }                                // Se a view vai ser adicionada ao menu da pagina
        public bool Active { get; set; }                                // Ativar este item.                                 
        public string TextMenu { get; set; }                            // Texto que aparecera no menu para esta viewItem
        public string TextView { get; set; }                            // Texto que aparecera na view
        public string ViewTipo { get; set; }                            // Tipo da view Ex: home, portofoli, about, team .. 
        public int ViewTypeCod { get; set; }                            // Códido único do item da view
        public string Link { get; set; }                                // local onde vai ser redirecionado ao se clicar no item ou no menu 

        // Relacionamentos
        public int AdminViewDataId { get; set; }
        public virtual AdminViewData AdminViewData { get; set; }
    }
}
