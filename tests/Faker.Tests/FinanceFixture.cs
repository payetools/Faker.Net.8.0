using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class FinanceFixture
    {
        [Test]
        public void should_return_an_isin()
        {
            var isin = Finance.Isin();
            Console.WriteLine($@"Isin=[{isin}]");

            Assert.That(isin, Is.Not.Empty);
            Assert.That(isin.Length, Is.EqualTo(12));
        }

        [Test]
        public void should_return_a_ticker()
        {
            var ticker = Finance.Ticker();
            Console.WriteLine($@"Ticker=[{ticker}]");

            Assert.That(ticker, Is.Not.Empty);
        }

        [Test]
        public void should_return_a_coupon()
        {
            var coupon = Finance.Coupon();
            Console.WriteLine($@"Coupon=[{coupon}]");

            Assert.That(coupon, Is.GreaterThan(0));
        }

        [Test]
        public void should_return_a_maturity_in_the_future()
        {
            var date = DateTime.Now.Date;
            var maturity = Finance.Maturity();
            Console.WriteLine($@"Maturity=[{maturity}]");

            Assert.That(maturity, Is.GreaterThan(date));
            Assert.That((maturity - date).TotalDays, Is.GreaterThan(180));
        }

        [Test]
        public void should_return_a_maturity_in_the_past()
        {
            var date = DateTime.Now.Date;
            var maturity = Finance.Maturity(-120, -6);
            Console.WriteLine($@"Maturity=[{maturity}]");

            Assert.That(maturity, Is.LessThan(date));
        }

        [Test]
        public void should_return_a_credit_bond_name()
        {
            var bondName = Finance.Credit.BondName();
            Console.WriteLine($@"BondName=[{bondName}]");

            Assert.That(bondName, Is.Not.Empty);
        }

        [Test]
        public void should_return_a_credit_bond()
        {
            var bond = Finance.Credit.BondClass();
            Console.WriteLine($@"BondClass=[{bond}]");

            Assert.That(bond, Is.Not.Null);
        }

        [Test]
        public void should_return_valid_uk_bank_details()
        {
            var (accountNo, sortCode) = Finance.UkBankDetails();
            Console.WriteLine($@"UkBankDetails=[{accountNo}, {sortCode}]");

            Assert.That(accountNo, Is.Not.Null);
            Assert.AreEqual(accountNo.Length, 8);
            Assert.True(int.TryParse(accountNo, out var result));
            Assert.That(sortCode, Is.Not.Null);
            Assert.AreEqual(sortCode.Length, 6);
            Assert.True(int.TryParse(sortCode, out result));

            (accountNo, sortCode) = Finance.UkBankDetails(true);
            Console.WriteLine($@"UkBankDetails=[{accountNo}, {sortCode}]");

            Assert.That(accountNo, Is.Not.Null);
            Assert.AreEqual(accountNo.Length, 8);
            Assert.True(int.TryParse(accountNo, out result));
            Assert.That(sortCode, Is.Not.Null);
            Assert.AreEqual(sortCode.Length, 8);
            var pattern = new Regex(@"\d\d\-\d\d\-\d\d");
            Assert.True(pattern.IsMatch(sortCode));
        }
    }
}