using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages
{
    public class ConvertCurrencyModel : PageModel
    {
        public const double DOLLARS_IN_POUNDS = 1.1;
        public const double EUROS_IN_POUNDS = 1.14;
        public const double EUROS_IN_DOLLARS = 1.03;

        [BindProperty]
        public CurrencyChoice OriginalCurrency { get; set; }
        [BindProperty]
        public CurrencyChoice NewCurrency { get; set; }
        [BindProperty]
        public double CurrencyAmount { get; set; }
        [BindProperty]
        public double ConversionResult { get; set; }

        public enum CurrencyChoice
        {
            NoUnit,
            Pounds,
            Dollars,
            Euros
        }
        public void OnGet()
        {
            OriginalCurrency = CurrencyChoice.Pounds;
            CurrencyAmount = 10.50;
            NewCurrency = CurrencyChoice.Dollars;
            ViewData["Message"] = "Please Fill Out all Fields";
        }

        public void OnPost()
        {
            if (OriginalCurrency == CurrencyChoice.Pounds &&
                NewCurrency == CurrencyChoice.Dollars)
            {
                ConversionResult = CurrencyAmount * DOLLARS_IN_POUNDS;
            }
            else if (OriginalCurrency == CurrencyChoice.Dollars &&
                NewCurrency == CurrencyChoice.Pounds)
            {
                ConversionResult = CurrencyAmount / DOLLARS_IN_POUNDS;
            }
            else if (OriginalCurrency == CurrencyChoice.Pounds &&
                NewCurrency == CurrencyChoice.Euros)
            {
                ConversionResult = CurrencyAmount * EUROS_IN_POUNDS;
            }
            else if (OriginalCurrency == CurrencyChoice.Euros &&
                NewCurrency == CurrencyChoice.Pounds)
            {
                ConversionResult = CurrencyAmount / EUROS_IN_POUNDS;
            }
            else if (OriginalCurrency == CurrencyChoice.Dollars &&
                NewCurrency == CurrencyChoice.Euros)
            {
                ConversionResult = CurrencyAmount * EUROS_IN_DOLLARS;
            }
            else if (OriginalCurrency == CurrencyChoice.Euros &&
                NewCurrency == CurrencyChoice.Dollars)
            {
                ConversionResult = CurrencyAmount / EUROS_IN_DOLLARS;
            }
            ViewData["Message"] = $"{CurrencyAmount} {OriginalCurrency} " +
                $"is equal to {ConversionResult} {NewCurrency}";
        }
    }
}
