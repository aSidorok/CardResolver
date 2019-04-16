using System;

namespace CardResolver
{
    public class Program
    {
        private const string VisaStart = "4";
        private const string MasterCardStart = "5";

        static void Main()
        {
            Console.WriteLine("Please insert card number type: 1 for Visa, 2 for MasterCard");
            string cardTypeInput = Console.ReadLine();

            if (!int.TryParse(cardTypeInput, out int cardType) || IsInvalidCardTypeRangeProvided(cardType))
            {
                Console.WriteLine("Invalid card type");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Please insert card number to verify");

            string cardNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                Console.WriteLine("Your input string is incorrect");
                Console.ReadKey();
                return;
            }

            var luhnAlgorithm = new LuhnAlgorithm();
            var result = luhnAlgorithm.IsCardValid(cardNumber) ? "valid" : "invalid";
            var cardTypeValidation = IsValidCardType(cardNumber, cardType) ? "valid" : "invalid";

            Console.WriteLine($"Card number is {result} and {cardTypeValidation} card type");


            Console.ReadKey();
        }

        private static bool IsInvalidCardTypeRangeProvided(int cardType)
        {
            return cardType <= 0 || cardType >= 3;
        }

        private static bool IsValidCardType(string cardNumber, int cardType)
        {
            var startDigit = cardType == 1 ? VisaStart : MasterCardStart;

            return cardNumber.StartsWith(startDigit);
        }
    }
}
