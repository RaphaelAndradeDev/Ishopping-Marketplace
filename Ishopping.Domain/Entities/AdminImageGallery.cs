using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;


namespace Ishopping.Domain.Entities
{
    public class AdminImageGallery : _Gallery
    {
        public int Id { get; set; }
        public int AdminViewDataId { get; set; }
        public virtual AdminViewData AdminViewData { get; set; }

        // Ctor
        protected AdminImageGallery() { }

        public AdminImageGallery(int adminViewDataId, int viewCod, string fileName, int fileType, int folder, int position)
        {          
            Validate(viewCod, fileName, fileType, folder, position);

            this.AdminViewDataId = adminViewDataId;
            this.ViewCod = viewCod;
            this.FileName = fileName;       
            this.FileType = fileType;
            this.Folder = folder;
            this.Position = position;
        }

        // Methodos
        public void Change(int position)
        {
            this.Position = position;
        }

        public void Change(int viewCod, string fileName, int fileType, int folder, int position)
        {
            Validate(viewCod, fileName, fileType, folder, position);

            this.ViewCod = viewCod;
            this.FileName = fileName;
            this.FileType = fileType;
            this.Folder = folder;
            this.Position = position;
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
            AssertionConcern.AssertArgumentRange(folder, 1000, 9999, Errors.InvalidNumber);         
        }
    }
}
