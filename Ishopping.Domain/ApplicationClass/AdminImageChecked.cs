
namespace Ishopping.Domain.ApplicationClass
{
    public class AdminImageChecked
    {
        public string Id { get; set; }
        public int SiteNumber { get; set; }
        public int FileType { get; set; }
        public string FileName { get; set; }  
        public bool Checked { get; set; }
        public bool IsBlock { get; set; }
    }
}
