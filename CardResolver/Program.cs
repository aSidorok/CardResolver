using System;
using System.Linq;
using System.Text;

namespace CardResolver
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Please insert card number type: 1 for Visa, 2 for MasterCard");
            string cardTypeInput = Console.ReadLine();

            if (!int.TryParse(cardTypeInput, out int cardType) || CardDetailsValidator.IsInvalidCardTypeRangeProvided(cardType))
            {
                Console.WriteLine("Invalid card type");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Please insert card number to verify");

            string cardNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cardNumber) || !cardNumber.All(char.IsDigit))
            {
                Console.WriteLine("Your input string is incorrect");
                Console.ReadKey();
                return;
            }

            var luhnAlgorithm = new LuhnAlgorithm();
            var cardNumberValidationResult = luhnAlgorithm.IsCardValid(cardNumber) ? "valid" : "invalid";

            var messageResult = new StringBuilder();

            messageResult.Append("Card number is ").AppendLine(cardNumberValidationResult);
            messageResult.AppendLine(CardDetailsValidator.IsValidCardType(cardNumber, cardType));
            messageResult.AppendLine(CardDetailsValidator.IsValidCardTypeLength(cardNumber, cardType));

            Console.WriteLine("\nRESULTS:");
            Console.WriteLine(messageResult.ToString());

            Console.ReadKey();
        }
    }
}
