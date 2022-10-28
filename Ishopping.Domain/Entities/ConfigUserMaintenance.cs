using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using System;

namespace Ishopping.Domain.Entities
{
    public class ConfigUserMaintenance
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }
        public bool IsMaintenance { get; private set; }
        public string Controller { get; private set; }              // Controller de retorno ex: Oxygen
        public string ViewName { get; private set; }
        public string PartialView { get; private set; }
        public string Title { get; private set; } 
        public string Message { get; private set; }
        public DateTime DateReturn { get; private set; }

        // Ctor
        protected ConfigUserMaintenance() { }
     
        public ConfigUserMaintenance(string userId, int siteNumber, bool isMaintenance, string controller, string viewName, string partialView, string title, DateTime dateReturn, string message = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(controller, viewName, title, message);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.IsMaintenance = isMaintenance;
            this.ViewName = viewName;
            this.PartialView = partialView;
            this.Controller = controller;
            this.Title = title;
            this.Message = message;
            this.DateReturn = dateReturn;
        }

        // Methods
        public void Change(bool isMaintenance, string viewName, string partialView, string title, DateTime dateReturn, string message = "")
        {
            Validate(viewName, partialView, title, message);

            this.IsMaintenance = isMaintenance;
            this.ViewName = viewName;
            this.PartialView = partialView;
            this.Title = title;
            this.Message = message;
            this.DateReturn = dateReturn;
        }

        public void SetIsMaintenance(bool isMaintenance)
        {
            this.IsMaintenance = isMaintenance;
        }

        private void Validate(string viewName, string partialView, string title, string message)
        {                       
            AssertionConcern.AssertArgumentNotNull(viewName, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(viewName, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(partialView, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(partialView, 32, Errors.MaxLength); 

            AssertionConcern.AssertArgumentNotNull(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(message, 512, Errors.MaxLength);
        }

        private void Validate(string controller, string viewName, string partialView, string title, string message)
        {
            Validate(viewName, partialView, title, message);

            AssertionConcern.AssertArgumentNotNull(controller, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(controller, 20, Errors.MaxLength);
        }
    }
}
