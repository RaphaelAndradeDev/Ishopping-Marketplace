using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class UserSerializeViewData : _UserData
    {

        // Property             
        public int ViewCod { get; private set; }
        public bool IsMaintenance { get; private set; }      
        public bool IsBlock { get; private set; }
        public string Serialize { get; private set; }


        // Ctor
        protected UserSerializeViewData() { }

        public UserSerializeViewData(string userId, int siteNumber, int viewCod, bool isBlock, string serialize)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(serialize);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ViewCod = viewCod;
            this.IsBlock = isBlock;
            this.IsMaintenance = true;           
            this.Serialize = serialize;
            this.LastChange = DateTime.Now;
        }
        
        // Methods
        public void Change(string serialize)
        {
            Validate(serialize);
            this.Serialize = serialize;
            this.LastChange = DateTime.Now;
        }

        public void SetBlock(bool isBlock)
        {
            this.IsBlock = isBlock;
            this.LastChange = DateTime.Now;
        }

        public void SetMaintenance(bool isMaintenance, DateTime dateReturn)
        {
            this.IsMaintenance = isMaintenance;          
            this.LastChange = DateTime.Now;
        }

        private void Validate(string serialize)
        {
            AssertionConcern.AssertArgumentNotEmpty(serialize, Errors.IsNull);          
        }
    }
}
