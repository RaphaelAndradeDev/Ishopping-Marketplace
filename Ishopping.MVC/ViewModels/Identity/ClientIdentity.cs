using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ishopping.MVC.Models
{
    [Table("AspNetClients")]
    public class ClientIdentity
    {
        [Key]
        public int Id { get; set; }
        public string ClientKey { get; set; }
    }
}