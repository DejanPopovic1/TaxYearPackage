using NUnit.Framework;
using System;
using TaxYearNamespace;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("2022,12,22", "2023-12-20")]
        [TestCase("2022,12,21", "2023-12-20")]
        [Test]
        public void EndingTaxYearDateFollowingYear(DateTime supplied, DateTime expected)
        {
            var actualResult = TaxYear.EndingTaxDate(supplied, CountryEnum.Afghanistan);
            Assert.AreEqual(expected, actualResult);
        }

        [TestCase("2022,12,19", "2022-12-20")]
        [TestCase("2022,12,20", "2022-12-20")]
        [Test]
        public void EndingTaxYearDateSameYear(DateTime supplied, DateTime expected)
        {
            var actualResult = TaxYear.EndingTaxDate(supplied, CountryEnum.Afghanistan);
            Assert.AreEqual(expected, actualResult);
        }

        [TestCase("2022,12,21", "2022-12-21")]
        [TestCase("2022,12,22", "2022-12-21")]
        [Test]
        public void CurrentStartingTaxDateSameYear(DateTime supplied, DateTime expected)
        {
            var actualResult = TaxYear.CurrentStartingTaxDate(supplied, CountryEnum.Afghanistan);
            Assert.AreEqual(expected, actualResult);
        }

        [TestCase("2022,12,19", "2021-12-21")]
        [TestCase("2022,12,20", "2021-12-21")]
        [Test]
        public void CurrentStartingTaxDatePreviousYear(DateTime supplied, DateTime expected)
        {
            var actualResult = TaxYear.CurrentStartingTaxDate(supplied, CountryEnum.Afghanistan);
            Assert.AreEqual(expected, actualResult);
        }

        [TestCase("2022,12,21", "2023-12-21")]
        [TestCase("2022,12,22", "2023-12-21")]
        [Test]
        public void FollowingStartingTaxYearFollowingYear(DateTime supplied, DateTime expected)
        {
            var actualResult = TaxYear.FollowingStartingTaxDate(supplied, CountryEnum.Afghanistan);
            Assert.AreEqual(expected, actualResult);
        }

        [TestCase("2022,12,19", "2022-12-21")]
        [TestCase("2022,12,20", "2022-12-21")]
        [Test]
        public void FollowingStartingTaxYearSameYear(DateTime supplied, DateTime expected)
        {
            var actualResult = TaxYear.FollowingStartingTaxDate(supplied, CountryEnum.Afghanistan);
            Assert.AreEqual(expected, actualResult);
        }

        [TestCase("2022,05,05", "2022-05-05", true)]
        [TestCase("2022,12,19", "2022-12-20", true)]
        [TestCase("2022,12,21", "2022-12-22", true)]
        [TestCase("2022,12,21", "2023-01-01", true)]
        [TestCase("2022,12,20", "2021-12-21", true)]
        [Test]
        public void FollowingStartingTaxYearSameYear(DateTime supplied1, DateTime supplied2, bool result)
        {
            var r1 = TaxYear.EndingTaxDate(new DateTime(2022, 12, 21), CountryEnum.Afghanistan);
            var r2 = TaxYear.EndingTaxDate(new DateTime(2023, 01, 01), CountryEnum.Afghanistan);
            var actualResult = TaxYear.IsSameTaxYear(supplied1, supplied2, CountryEnum.Afghanistan);
            Assert.AreEqual(actualResult, result);
        }
    }
}