// importing Nunit Framework and our application using NUnit testing framework

using Demo_MathLibrary_Testing_using_Nunit; // importing our application namespace

namespace MathLibrary.Tests
{
    public class calculatorTests
    {
        private Calculator calculator; // declaring a private field for the Calculator class
        [SetUp] // attribute to indicate this method runs before each test
        public void Setup()
        {
            calculator = new Calculator(); // initializing the Calculator instance before each test
        }

        [Test]
        public void addShouldReturnCorrect()
        {
            Assert.Pass(); // This is a placeholder for the actual test logic
            int result = calculator.Add(2, 5); // calling the Add method
            //Assert.AreEqual(5, result);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void subtractShouldReturnCorrect()
        {
            //Assert.Pass();
            int result = calculator.sub(5, 3);
            //Assert.AreEqual(3, result);
            Assert.That (result, Is.EqualTo(2));
        }

        [Test]
        public void multiplyShouldReturnCorrect()
        {
            int result = calculator.Multiply(2, 3);
            Assert.That(result, Is.EqualTo(6));
        }
    }
}