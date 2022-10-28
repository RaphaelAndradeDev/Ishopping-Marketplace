using Ishopping.Domain.Communs;

namespace Ishopping.Domain.Entities
{
    public class AdminSlider : _Slider
    {
        public int Id { get; set; }
               
        // Relacionamento
        public int AdminViewDataId { get; set; }
        public virtual AdminViewData AdminViewData { get; set; }        
    }
}
