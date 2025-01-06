using NUnit.Framework;
using Text;

namespace Text.Tests
{
    public class StrTests
    {

        [Test]
        public void IsPalindrome_InputTrue_ReturnTrue()
        {
            string input = "Racecar";

            bool result = Str.IsPalindrome(input);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsPalindrome_InputFalse_ReturnFalse()
        {
            string input = "Thomas";

            bool result = Str.IsPalindrome(input);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void IsPalindrome_InputEmpty_ReturnTrue()
        {
            string input = "";

            bool result = Str.IsPalindrome(input);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsPalindrome_InputTrueWithPunctuation_ReturnTrue()
        {
            string input = "A man, a plan, a canal: Panama.";

            bool result = Str.IsPalindrome(input);

            Assert.AreEqual(true, result);
        }
    }
}