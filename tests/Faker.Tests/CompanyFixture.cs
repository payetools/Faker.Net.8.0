﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class CompanyFixture
    {
        [Test]
        public void Should_Generate_Company_Name()
        {
            var name = Company.Name();
            Console.WriteLine($@"Name=[{name}]");

            // Name should match one of the given formats
            Assert.IsTrue(new List<Func<bool>>
            {
                () => Regex.IsMatch(name, @"\w+ \w+"),
                () => Regex.IsMatch(name, @"\w+-\w+"),
                () => Regex.IsMatch(name, @"\w+, \w+ and \w+")
            }.Any(x => x.Invoke()));
        }

        [Test]
        public void Should_Generate_Catchphrase()
        {
            var catchPhrase = Company.CatchPhrase();
            Console.WriteLine($@"CatchPhrase=[{catchPhrase}]");

            Assert.IsTrue(Regex.IsMatch(catchPhrase, @"[\w\-\/]+ [\w\-\/]+ [\w\-\/]+"));
        }

        [Test]
        public void Should_Generate_Bs()
        {
            var bs = Company.BS();
            Console.WriteLine($@"BS=[{bs}]");

            Assert.IsTrue(Regex.IsMatch(bs, @"[\w\-\/]+ [\w\-\/]+ [\w\-\/]+"));
        }
    }
}