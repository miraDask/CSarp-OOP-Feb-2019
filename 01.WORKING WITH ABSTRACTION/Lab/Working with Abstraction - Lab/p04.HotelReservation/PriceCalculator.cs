namespace p04.HotelReservation
{
    public class PriceCalculator
    {
        public decimal Calculate(decimal pricePerDay, int days, Season season, DiscountType discauntType)
        {
            int multiplier = (int)season;
            decimal discount = (decimal)discauntType / 100;

            decimal priceBeforDiscount = pricePerDay * multiplier * days;
            decimal totalPrice = priceBeforDiscount * (1 - discount);

            return totalPrice;
        }
    }
}
