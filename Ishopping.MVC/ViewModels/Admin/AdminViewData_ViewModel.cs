using System.Collections.Generic;

namespace Ishopping.MVC.ViewModels.Admin
{
    public class AdminViewData_ViewModel
    {
        public int Id { get; set; }

        // Identificação da view   
        public int ViewCod { get; set; }                                // Código único da view
        public string Controller { get; set; }
        public string Action { get; set; }

        // Dados para menu   
        public bool OnMenu { get; set; }                                // Se a view vai ser adicionada ao menu da pagina
        public string ViewLink { get; set; }                            // Link onde sera redirecionado o item na view ao clicar
        public bool ViewDefault { get; set; }                           // Essa view é a padrão entre outras do mesmo tipo
        public string ClassActive { get; set; }                         // Classe usada para deixar o item do menu destacado

        // Dados da view        
        public string TextMenu { get; set; }                            // Texto que aparecera no menu para esta view
        public bool Active { get; set; }
        public string ViewName { get; set; }                            // Nome da view
        public string ViewTipo { get; set; }                            // Tipo
        public bool Bloqueado { get; set; }                             // Bloqueado, o usuario não pode ativar ou desativar
        public bool ExSlider { get; set; }                              // Indica se essa view possui configurações de slider
        public bool ExImg { get; set; }                                 // Existe imagem ( se esta view possui imagem )
        public bool AddSingle { get; set; }                             // Algumas views chama outra view quando e executada alguma função ( ex: clique em um portofolio)                  
        public string ViewSingle { get; set; }                          // Nome ou código da view single
        public int ListImage { get; set; }
        public int ListIconPng { get; set; }
        public int ListLogo { get; set; }
        public string ListVectorIcon { get; set; }                      // não alterar para int pois apresenta problemas futuros
        public string ListText { get; set; }
        public int ListList { get; set; }
        public int NumBtn { get; set; }
        public int NumVideo { get; set; }

        //  ------------------------------------- Relacionamentos -------------------

        public int AdminTemplateId { get; set; }
        public virtual AdminTemplateViewModel AdminTemplate { get; set; }
        public virtual ICollection<AdminImageGalleryViewModel> AdminImageGallery { get; set; }
        public virtual ICollection<AdminViewItem_ViewModel> AdminViewItem { get; set; }
        public virtual ICollection<AdminSliderViewModel> AdminSlider { get; set; }
    }
}
