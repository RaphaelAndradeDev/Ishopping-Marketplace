using Ishopping.SectionModels.Ishopping;
using System.Collections.Generic;

namespace Ishopping.ViewModels.Ishopping
{
    public class SinglePostViewModel
    {
        public SinglePostSectionModel SinglePost { get; set; }
        public IEnumerable<string> Categorys { get; set; }
        public IEnumerable<PostSummarySectionModel> PostSummary { get; set; }
    }
}