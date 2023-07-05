using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;
using WebApiEntityFramework.Enums;

namespace WebApiEntityFramework.Conversions
{
    public class CurrencyToSymbolConverter : ValueConverter<Currency, string>
    {
        public CurrencyToSymbolConverter() : base(currency => CurrencyToString(currency),symbol => StringToCurrency(symbol))
        {
        }

        public static string CurrencyToString(Currency currency) =>
            currency switch
            {
                Currency.USDollar => "$",
                Currency.Euro => "€",
                Currency.DominiPeso => "RD$",
                _ => ""
            };

        public static Currency StringToCurrency(string symbol) =>
            symbol switch
            {
                "$" => Currency.USDollar,
                "€" => Currency.Euro,
                "RD$" => Currency.DominiPeso,
                _ => Currency.UnKnown
            };
    }
}
