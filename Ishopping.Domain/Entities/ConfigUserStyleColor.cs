using System;

namespace Ishopping.Domain.Entities
{
    public class ConfigUserStyleColor
    {
        public Guid Id { get; set; }
        public string DefaultColor { get; set; }
        public string UserColor { get; set; }

        public Guid ConfigUserAppearanceId { get; set; }
        public virtual ConfigUserAppearance ConfigUserAppearance { get; set; }
    }
}
