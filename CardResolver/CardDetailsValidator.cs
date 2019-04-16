namespace CardResolver
{
    public static class CardDetailsValidator
    {
        private const string VisaStart = "4";
        private const string MasterCardStart = "5";
        private const int MaxCardDigits = 16;
        private const int MinVisaDigits = 13;

        public static bool IsInvalidCardTypeRangeProvided(int cardType)
        {
            return cardType <= 0 || cardType >= 3;
        }

        public static string IsValidCardType(string cardNumber, int cardType)
        {
            var validationResult = cardType == 1
                ? GetCardTypeValidationMessage(cardNumber, VisaStart)
                : GetCardTypeValidationMessage(cardNumber, MasterCardStart);

            return $"Card type provided is {validationResult}";
        }

        public static string IsValidCardTypeLength(string cardNumber, int cardType)
        {
            var isValidLength = cardType == 1
                ? IsValidVisaCardNumberLength(cardNumber)
                : cardNumber.Length == MaxCardDigits;

            return $"Card length is {(isValidLength ? "valid" : "invalid")}";
        }

        private static string GetCardTypeValidationMessage(string cardNumber, string startWithDigit)
        {
            return cardNumber.StartsWith(startWithDigit) ? "valid" : "invalid";
        }

        private static bool IsValidVisaCardNumberLength(string cardNumber)
        {
            return cardNumber.Length >= MinVisaDigits && cardNumber.Length <= MaxCardDigits;
        }
    }
}