using xUnit_Essentials.Models;

namespace xUnit_Essentials.BusinessLogics
{
    public interface ICartBusinessLogic
    {
        decimal CalculateCouponDiscount(decimal cartTotal, decimal discountPrec, decimal maxDiscount);
        decimal CalculateMembershipDiscount(decimal cartTotal, Customer customer);
    }
}