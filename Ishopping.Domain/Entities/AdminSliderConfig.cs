
namespace Ishopping.Domain.Entities
{
    public class AdminSliderConfig
    {
        public int Id { get; set; }
        public int SliderType { get; set; }                 // slider para texto, butão, video ou imagem
        public string SliderName { get; set; }              // nome do slider
        public string PartialView { get; set; }
        public string SliderClass { get; set; }             // nome da classe do slider        
        public string ClassTarget { get; set; }

        // Relacionamento
        public int AdminViewDataId { get; set; }
        public virtual AdminViewData AdminViewData { get; set; } 
    }
}
