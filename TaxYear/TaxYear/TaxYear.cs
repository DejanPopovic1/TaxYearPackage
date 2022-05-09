namespace TaxYearNamespace
{
    public static class TaxYear
    {
        public static DateTime EndingTaxDate(DateTime date, CountryEnum country)
        {
            var taxYearSplit = new DateTime(date.Year, CountryTaxYearStartMonth.StartMonths[country].Month, CountryTaxYearStartMonth.StartMonths[country].Day);
            if (date < taxYearSplit)
            {
                return taxYearSplit.AddDays(-1);
            }
            else
            {
                return taxYearSplit.AddYears(1).AddDays(-1);
            }
        }

        public static DateTime CurrentStartingTaxDate(DateTime date, CountryEnum country)
        {
            var taxYearSplit = new DateTime(date.Year, CountryTaxYearStartMonth.StartMonths[country].Month, CountryTaxYearStartMonth.StartMonths[country].Day);
            if (date < taxYearSplit)
            {
                return taxYearSplit.AddYears(-1);
            }
            else
            {
                return taxYearSplit;
            }
        }

        public static DateTime FollowingStartingTaxDate(DateTime date, CountryEnum country)
        {
            var taxYearSplit = new DateTime(date.Year, CountryTaxYearStartMonth.StartMonths[country].Month, CountryTaxYearStartMonth.StartMonths[country].Day);
            if (date < taxYearSplit)
            {
                return taxYearSplit;
            }
            else
            {
                return taxYearSplit.AddYears(1);
            }
        }

        public static bool IsSameTaxYear(DateTime date1, DateTime date2, CountryEnum country)
        {
            return EndingTaxDate(date1, country) == EndingTaxDate(date1, country);
        }
    }
}
