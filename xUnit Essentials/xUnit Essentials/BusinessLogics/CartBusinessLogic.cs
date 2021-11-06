using xUnit_Essentials.Models;

namespace xUnit_Essentials.BusinessLogics
{
    public class CartBusinessLogic : ICartBusinessLogic
    {
        // Constructor
        public CartBusinessLogic()
        {

        }

        // Public methods

        /// <summary>
        /// Calculate the discount on cart total when given discount percentage and maximum allowed discount price along with the current cart total.
        /// </summary>
        /// <param name="cartTotal"> Total cart amount</param>
        /// <param name="discountPrec">Coupon discount in percentage</param>
        /// <param name="maxDiscount">Maximum discount amount allowed</param>
        /// <returns></returns>
        public decimal CalculateCouponDiscount(decimal cartTotal, decimal discountPrec, decimal maxDiscount)
        {
            var discountedPrice = cartTotal * (discountPrec / 100);
            if (discountedPrice > maxDiscount)
            {
                return maxDiscount;
            }
            return discountedPrice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartTotal">Total cart amount</param>
        /// <param name="customer">Customer profile</param>
        /// <returns></returns>
        public decimal CalculateMembershipDiscount(decimal cartTotal, Customer customer)
        {
            var discountPrec = 0.0M;
            decimal maxDiscount = 0.0M;

            switch (customer.MembershipType)
            {
                case Models.Enums.MembershipTypes.None:
                case Models.Enums.MembershipTypes.Bronze:
                    discountPrec = 0.0M;
                    maxDiscount = 0.0M;
                    break;

                case Models.Enums.MembershipTypes.Silver:
                    discountPrec = 0.5M;
                    maxDiscount = 250;
                    break;

                case Models.Enums.MembershipTypes.Gold:
                    discountPrec = 1;
                    maxDiscount = 500;
                    break;

                case Models.Enums.MembershipTypes.Platinum:
                    discountPrec = 1.5M;
                    maxDiscount = 1000;
                    break;
            }
            var discountedPrice = cartTotal * (discountPrec / 100);
            if (discountedPrice > maxDiscount)
            {
                return maxDiscount;
            }
            return discountedPrice;
        }

        /*
         *  Bronze,
        Silver,
        Gold,
        Platinum,
        None,
         */
    }
}
