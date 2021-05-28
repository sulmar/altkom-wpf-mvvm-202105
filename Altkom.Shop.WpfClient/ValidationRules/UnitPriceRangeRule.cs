using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Altkom.Shop.WpfClient.ValidationRules
{
    public class UnitPriceRangeRule : ValidationRule
    {
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (decimal.TryParse(value.ToString(), out decimal unitPrice))
            {
                if (unitPrice < Minimum || unitPrice > Maximum )
                {
                    return new ValidationResult(false, $"Podaj w zakresie od {Minimum} do {Maximum}");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
            {
                return new ValidationResult(false, "Błędny format");
            }
        }
    }
}
