using Ishopping.Domain.Communs;

namespace Ishopping.Domain.ApplicationClass
{
    public class BasicUserViewItem
    {
        public bool Active { get; set; }
        public int ViewTypeCod { get; set; }
        public string TextView { get; set; }                            // Texto que aparecera na view
        public string StTextView { get; set; }                          // Estilo do texto que aparecera na view
        public string SubTitle { get; set; }                            // Subtitulo que aparecera na view 
        public string StSubTitle { get; set; }                          // Estilo do subtitulo que aparecera na view 

        // Get IsTags
        public string _TextView { get { return IsHtmlTags.GetTags(TextView); } }
        public string _SubTitle { get { return IsHtmlTags.GetTags(SubTitle); } }
    }
}
