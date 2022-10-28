using Ishopping.Common.Resources;
using System;

namespace Ishopping.Common.Validation
{
    public class CommonValidate
    {
        // Public Methods
        public static void Validate(string userId)
        {
            UserIdValidate(userId);
        }

        public static void Validate(int siteNumber)
        {
            SiteNumberValidate(siteNumber);
        }

        public static void Validate(string userId, int siteNumber)
        {
            UserIdValidate(userId);
            SiteNumberValidate(siteNumber);
        }

        // Private Methods
        private static void UserIdValidate(string userId)
        {
            Guid newGuid;
            if(!Guid.TryParse(userId, out newGuid))
            {
                throw new InvalidOperationException(Errors.IsNull);
            }
        }

        private static void SiteNumberValidate(int siteNumber)
        {
            AssertionConcern.AssertArgumentRange(siteNumber, 111111111,999999999, Errors.MaxLength);
        }
    }
}
