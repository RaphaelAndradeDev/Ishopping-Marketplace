using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Entities
{
    public class ECommerceProductGroup
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string grupo { get; set; }
        public int exibicao { get; set; }
        public virtual IEnumerable<ECommerceProduct> ECommerceProduct { get; set; } 
    }
}
