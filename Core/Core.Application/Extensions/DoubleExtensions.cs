namespace Core.Application.Extensions;

public static class DoubleExtensions
{
    /// <summary>
    /// => amount - ( amount * percent / 100 )
    /// </summary>
    /// <param name="percent">Discount percent for applying to amount</param>
    /// <returns></returns>
    public static double ApplyDiscount(this double amount, double percent)
    {
        return amount - (amount * percent / 100);
    }
}