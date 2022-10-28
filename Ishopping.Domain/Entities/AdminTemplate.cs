using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Entities
{
    public class AdminTemplate
    {       
        public int Id { get; set; }
        public int TemplateCod { get; set; }                    // identificação única
        public string Name { get; set; }
        public int Group { get; set; }
        public string CssPath { get; set; }                     // se for mais de 1 então separar por virgula
        public virtual ICollection<AdminSocialNetWork> AdminSocialNetWork { get; set; }
        public virtual ICollection<AdminViewData> AdminViewData { get; set; }
    }
}
