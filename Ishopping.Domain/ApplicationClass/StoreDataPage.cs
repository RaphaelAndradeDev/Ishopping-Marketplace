using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Domain.ApplicationClass
{
    public class StoreDataPage
    {
        public int Category { get; set; }
        public IEnumerable<BasicDisplay> BasicDisplay { get; private set; }

        public StoreDataPage()
        {

        }

        public StoreDataPage(IEnumerable<BasicDisplay> basicDisplay)
        {         
            BasicDisplay = basicDisplay.Where(x => x.ProductDataPage.Count() > 0).OrderBy(x => x.Radius);           
        }    
    }
}
