using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Entities
{
    public class ConfigUserView
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }
        public bool Active { get; private set; }
        public string TextMenu { get; private set; }                            // Texto que aparecera no menu para esta view 

        // Relacionamento  -----------------------------------------
        public int AdminViewDataId { get; private set; }
        public virtual AdminViewData AdminViewData { get; private set; }
        public virtual ICollection<ConfigUserViewItem> ConfigUserViewItem { get; private set; }
        

        // Ctor
        protected ConfigUserView() { }
     
        public ConfigUserView(string userId, int siteNumber,  int adminViewDataId, bool active = true, string textMenu = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(textMenu);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;            
            this.AdminViewDataId = adminViewDataId;
            this.Active = active;
            this.TextMenu = textMenu;
        }

        // Methods
        public void Change(bool active, string textMenu)
        {
            Validate(textMenu);

            this.Active = active;
            this.TextMenu = textMenu;
        }

        public void AddConfigUserViewItem(ConfigUserViewItem configUserViewItem)
        {
            this.ConfigUserViewItem.Add(configUserViewItem);
        }

        public void AddListConfigUserViewItem(ICollection<ConfigUserViewItem> configUserViewItem)
        {
            this.ConfigUserViewItem = configUserViewItem;
        }

        private void Validate(string textMenu)
        {            
            AssertionConcern.AssertArgumentLength(textMenu, 20, Errors.MaxLength);
        }
    }
}
