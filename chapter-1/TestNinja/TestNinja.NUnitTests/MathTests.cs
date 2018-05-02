using NUnit.Framework;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.NUnitTests
{
    // RIDER: RUN UNIT TEST, SELECT CLASS OR METHOD: Ctrl U, R
    [TestFixture]
    public class MathTests
    {
        private Math _math;
        // SetUp
        // TearDown (often used with integration tests)
        
        // WILL RUN BEFORE EACH TEST ENSURING _math ALWAYS
        // RECEIVES A NEW INSTANCE OF Math()
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
        
        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            // EACH TEST SHOULD RECEIVE A NEW INSTANCE OF MATH CLASS
            // BETTER USE [SetUp]
//            var math = new Math();

            var result = _math.Add(1, 2);
            
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentGreater_ReturnFirstArgument()
        {
            var result = _math.Max(2, 1);
            
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
        {
            var result = _math.Max(1, 2);
            
            Assert.That(result, Is.EqualTo(2));            
        }
        
        [Test]
        public void Max_BothArgumentsAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1);
            
            Assert.That(result, Is.EqualTo(1));
        }

        // BETTER USE 1 METHOD WITH ARGUMENTS
        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int x, int y, int expectedResult)
        {
            var result = _math.Max(x, y);
            
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}