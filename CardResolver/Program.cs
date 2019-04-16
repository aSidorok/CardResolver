using System;

namespace CardResolver
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert card number to verify");

            string cardNumber = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(cardNumber))
            {
                var luhnAlgorithm = new LuhnAlgorithm();
                var result = luhnAlgorithm.IsCardValid(cardNumber) ? "valid" : "invalid";

                Console.WriteLine($"Card number is {result}");
            }
            else
            {
                Console.WriteLine("Your input string is incorrect");
            }

            Console.ReadKey();
        }
    }
}
