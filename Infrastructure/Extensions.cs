using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public static class Extensions
    {
        private static Random rnd;
        public static Random GetRandom => rnd ?? (rnd = new Random());

        public static void ForEach<T>(this IEnumerable<T> target, Action<T> action)
        {
            foreach (var el in target)
            {
                action(el);
            }
        }

        public static int FindSubstringsCount(this string targetString, string searchingSubstring)
        {
            int result = 0;

            if (String.IsNullOrEmpty(targetString) || String.IsNullOrEmpty(searchingSubstring))
                return result;

            for (int i = 0, j = 0; i < targetString.Length; i++, j++)
            {
                if (targetString[i] != searchingSubstring[j])
                {
                    j = -1;
                    continue;
                }

                if (j == searchingSubstring.Length - 1)
                {
                    result++;
                    j = -1;
                }
            }

            return result;
        }

        public static bool IsBinaryNumericString(this string number)
        {
            return number.All(ch => ch == '0' || ch == '1');
        }

        public static bool IsNumericString(this string targetString)
        {
            return targetString.All(char.IsDigit);
        }
    }
}
