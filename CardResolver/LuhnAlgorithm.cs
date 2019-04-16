using System;
using System.Linq;

namespace CardResolver
{
    public class LuhnAlgorithm
    {
        private readonly int[] _results = { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

        public bool IsCardValid(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                throw new ArgumentNullException(nameof(cardNumber));
            }

            int[] digits = cardNumber.Select(c => c - '0').ToArray();

            if (digits.Sum() == 0)
            {
                return false;
            }

            return CheckDigits(digits);
        }

        private bool CheckDigits(int[] digits)
        {
            for (int i = digits.Length % 2; i < digits.Length; i += 2)
            {
                digits[i] = _results[digits[i]];
            }

            return digits.Sum() % 10 == 0;
        }
    }
}