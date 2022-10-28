using Ishopping.Domain.Communs;

namespace Ishopping.Domain.Entities
{
    public class AdminSocialNetWork : _SocialNetwork
    {
        public int Id { get; set; }
        public int AdminTemplateId { get; set; }
        public virtual AdminTemplate AdminTemplate { get; set; }
    }
}
