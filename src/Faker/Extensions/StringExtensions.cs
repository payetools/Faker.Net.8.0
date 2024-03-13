﻿using System.Text.RegularExpressions;

// ReSharper disable CheckNamespace

namespace Faker.Extensions
{
    public static class StringExtensions
    {
        private static readonly string[] Alphabet = "a b c d e f g h i j k l m n o p q r s t u v w x y z".Split(' ');

        /// <summary>
        ///     Get a string with every occurence of '#' replaced with a random number.
        /// </summary>
        public static string Numerify(this string s)
        {
            return Regex.Replace(s, "#", m => RandomNumber.Next(0, 9)
                .ToString(), RegexOptions.Compiled);
        }

        /// <summary>
        ///     Get a string with every '?' replaced with a random character from the alphabet.
        /// </summary>
        public static string Letterify(this string s)
        {
            return Regex.Replace(s, @"\?", m => Alphabet.Random(), RegexOptions.Compiled);
        }

        public static string AlphanumericOnly(this string s)
        {
            return Regex.Replace(s, @"\W", "");
        }

        /// <summary>
        ///     Capitalise the first letter of the given string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Capitalise(this string s)
        {
            return Regex.Replace(s, "^[a-z]", x => x.Value.ToUpperInvariant());
        }
    }
}