using NUnit.Framework;
using Mikkytrionze.org;
using System;
using System.Text.RegularExpressions;

namespace VerbalExpressionTest
{
    public class Tests
    {
        [Test]
        public void TestCanBuildValidRegexUsingNormalWords()
        {
            var verbalExpression = new VerbalExpression();
            verbalExpression
                .StartOfLine()
                .Then("startingPoint")
                .Maybe("probaleText")
                .AnythingBut(" ")
                .EndOfLine();

            var expected = @"/^startingPoint(probaleText)?[^ ]*$/";
            Assert.AreEqual(verbalExpression.RegularExpression, expected);
        }

        [Test]
        public void TestItCanValidateUrl()
        {
            var verbalExpression = new VerbalExpression();
            verbalExpression
                .StartOfLine()
                .Then("http")
                .Maybe("s")
                .Then("://")
                .Maybe("www")
                .AnythingBut(" ")
                .EndOfLine();

            string url = "http://www.facecom";
            Match match = Regex.Match(url, verbalExpression.RegularExpression);
            Assert.IsTrue(match.Success);
        }
    }
}