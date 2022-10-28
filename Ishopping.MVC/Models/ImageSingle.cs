
namespace Ishopping.Models
{
    public class ImageSingle
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImgFolder { get; set; }
        public string ImgFileName { get; set; }

        public ImageSingle( string title, string description, string category, string imgFolder, string imgFileName)
        {
            this.Title = title;
            this.Description = description;
            this.Category = category;
            this.ImgFolder = imgFolder;
            this.ImgFileName = imgFileName;
        }
    }
}