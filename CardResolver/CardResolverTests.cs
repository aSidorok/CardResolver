using NUnit.Framework;

namespace CardResolver
{
    [TestFixture]
    public class CardResolverTests
    {
        private readonly LuhnAlgorithm _luhnAlgorithm = new LuhnAlgorithm();

        [TestCase("0395029284937416", true)]
        [TestCase("0395029284947416", false)]
        [TestCase("1026703357705984", true)]
        [TestCase("1026703357505984", false)]
        [TestCase("7646964571502733", true)]
        [TestCase("7644964571502733", false)]
        [TestCase("1902144865969151", true)]
        [TestCase("1902144865969133", false)]
        [TestCase("9112809000361403", false)]
        [TestCase("9112809000361402", true)]
        [TestCase("759728853082617", true)]
        public void Check(string cardNumber, bool expectedResult)
        {
            var actualResult = _luhnAlgorithm.IsCardValid(cardNumber);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}