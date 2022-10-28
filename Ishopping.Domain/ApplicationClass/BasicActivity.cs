using Ishopping.Domain.Communs;

namespace Ishopping.Domain.ApplicationClass
{
    public class BasicActivity
    {
        public int Position { get; set; }
        public string Title { get; set; }
        public string VectorIcon { get; set; }
        public string Description { get; set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }
    }
}
