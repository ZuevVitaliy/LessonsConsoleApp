using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public static class Extensions
    {
        private static Random rnd;
        public static Random GetRandom => rnd ?? (rnd = new Random());

        public static void ForEach<T>(this IEnumerable<T> target, Action<T> action)
        {
            if (target == null)
                return;
            foreach (var el in target)
            {
                action(el);
            }
        }

        public static int FindSubstringsCount(this string targetString, string searchingSubstring)
        {
            int result = 0;

            if (string.IsNullOrEmpty(targetString) || string.IsNullOrEmpty(searchingSubstring))
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

        public static bool IsDigit(this char ch)
        {
            return ch == '0' ||
                   ch == '1' ||
                   ch == '2' ||
                   ch == '3' ||
                   ch == '4' ||
                   ch == '5' ||
                   ch == '6' ||
                   ch == '7' ||
                   ch == '8' ||
                   ch == '9';
        }
    }
}
