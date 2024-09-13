using System.ComponentModel.DataAnnotations;

namespace PriceQuotation.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter a Subtotal.")]
        [Range(1, 500, ErrorMessage = "Subtotal must be a positive number greater than 0")]
        public decimal? Subtotal { get; set; }

        [Required(ErrorMessage = "Please enter a Discount Rate.")]
        [Range(1, 100, ErrorMessage = "Discount Percent must be a number between 0 and 100.")]
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
                return 0;
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
                return 0;
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
            return 0; 
        }
    }
}
