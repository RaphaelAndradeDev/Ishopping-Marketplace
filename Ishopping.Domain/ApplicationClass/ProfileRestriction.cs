
namespace Ishopping.Domain.ApplicationClass
{
    public class ProfileRestriction
    {
        public int SiteNumber { get; private set; }
        public bool HasRestriction { get; private set; }
        public string Message { get; private set; }            

        public ProfileRestriction(int siteNumber, bool hasRestriction, int imgFileType, string imgFileName)
        {
            this.SiteNumber = siteNumber;
            this.HasRestriction = hasRestriction;          
        }     
    }
}
