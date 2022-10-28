using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class UserImageGallery : _Gallery
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }

        // Checagem 
        public bool Checked { get; private set; }
        public bool IsBlock { get; private set; }

        // relacionamentos
        public virtual ICollection<ComponentSimpleProduct> ComponentSimpleProduct { get; private set; }
        public virtual ICollection<ComponentProject> ComponentProject { get; private set; }
        public virtual ICollection<ComponentPost> ComponentPost { get; private set; }
        public virtual ICollection<ECommerceProduct> ECommerceProduct { get; private set; }

        // Ctor
        protected UserImageGallery() { }
       
        public UserImageGallery(string userId, int siteNumber, int viewCod, string fileName, int fileType, int folder, int position)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, fileName, fileType, folder, position);

            IdUser = userId;
            SiteNumber = siteNumber;
            ViewCod = viewCod;
            FileName = fileName;       
            FileType = fileType;
            Folder = folder;
            Position = position;

            ComponentSimpleProduct = new HashSet<ComponentSimpleProduct>();
            ComponentProject = new HashSet<ComponentProject>();
            ComponentPost = new HashSet<ComponentPost>();
            ECommerceProduct = new HashSet<ECommerceProduct>();
        }

        // Methodos
        public void Change(int position)
        {
            Position = position;
        }

        public void Change(int viewCod, string fileName, int fileType, int folder, int position)
        {
            Validate(viewCod, fileName, fileType, folder, position);

            ViewCod = viewCod;
            FileName = fileName;
            FileType = fileType;
            Folder = folder;
            Position = position;
        }

        public void SetCheck(bool check)
        {
            Checked = check;
        }

        public void SetAproved(bool aproved)
        {
            IsBlock = aproved;
        }      

        private void Validate(int position)
        {
            AssertionConcern.AssertArgumentRange(position, 0, 99, Errors.InvalidNumber);
        }

        private void Validate(int viewCod, string fileName, int fileType, int folder, int position)
        {
            Validate(position);

            AssertionConcern.AssertArgumentNotNull(fileName, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(fileName, 20, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(fileType, 1, 16, Errors.InvalidNumber);
            AssertionConcern.AssertArgumentRange(folder, 111111111, 999999999, Errors.InvalidNumber);         
        }
    }
}
