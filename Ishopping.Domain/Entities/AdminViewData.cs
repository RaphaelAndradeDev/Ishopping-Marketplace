using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Entities
{
    public class AdminViewData
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
        public string ListVectorIcon { get; set; }                      // Conteúdo.  não alterar para int pois apresenta problemas futuros
        public string ListText { get; set; }                            // Conteúdo
        public int ListList { get; set; }                               // Conteúdo
        public int NumBtn { get; set; }                                 // Conteúdo
        public int NumVideo { get; set; }                               // Conteúdo
        public int NumSlider { get; set; }                              // Conteúdo

        //  ------------------------------------- Relacionamentos -------------------
                
        public int AdminTemplateId { get; set; }
        public virtual AdminTemplate AdminTemplate { get; set; }
        public virtual ICollection<AdminImageGallery> AdminImageGallery { get; set; }
        public virtual ICollection<AdminViewItem> AdminViewItem { get; set; }
        public virtual ICollection<AdminSlider> AdminSlider { get; set; }
        public virtual ICollection<AdminSliderConfig> AdminSliderConfig { get; set; }
    }
}
