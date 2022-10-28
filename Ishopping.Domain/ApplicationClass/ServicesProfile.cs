using System;

namespace Ishopping.Domain.ApplicationClass
{
    public class ServicesProfile
    {

        // Bloqueio       
        public bool HasInsufficientValue { get; set; }
        public bool HasRestriction { get; set; }
        public bool IsTimeOver { get; set; }

        // ******** Identificação
        public int SiteNumber { get; set; }

        // ******* Plan
        public int Plan { get; set; }

        // ***** Quantidade por serviços      
        public int EmailQuantity { get; set; }
        public string Email { get; set; }

        public bool HasRestrictionOnService()
        {
            return this.HasRestriction || this.HasInsufficientValue || this.IsTimeOver;
        }
    }
}
