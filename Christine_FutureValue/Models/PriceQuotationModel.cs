using System.ComponentModel.DataAnnotations;

namespace PriceQuotation.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter a Subtotal.")]
        [Range(1, 500, ErrorMessage = "Please enter a subtotal between 1 and 500.")]
        public decimal? Subtotal { get; set; }

        [Required(ErrorMessage = "Please enter a discount rate.")]
        [Range(0.1, 10, ErrorMessage = "Discount rate must be between 0.1 and 10.0.")]
        public decimal? DiscountRate { get; set; }

        // Calculated Discount Amount
        public decimal? DiscountAmount
        {
            get
            {
                if (Subtotal.HasValue && DiscountRate.HasValue)
                {
                    return Subtotal * (DiscountRate / 100);
                }
                return null;
            }
        }

        // Calculate total after applying discount
        public decimal? Total
        {
            get
            {
                if (Subtotal.HasValue && DiscountAmount.HasValue)
                {
                    return Subtotal - DiscountAmount;
                }
                return null;
            }
        }

        //calculate and return total
        public decimal? CalculatePriceQuote()
        {
            if (Subtotal.HasValue && DiscountRate.HasValue)
            {
                var discountAmount = Subtotal * (DiscountRate / 100);
                return Subtotal - discountAmount;
            }
            return null; 
        }
    }
}
