using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.ViewModels.Option
{
    public class PricingOptionViewModel
    {
        public BasicUserViewItem BasicUserViewItem { get; set; }
        public ComponentPricingOption ComponentPricingOption { get; set; }
    }
}