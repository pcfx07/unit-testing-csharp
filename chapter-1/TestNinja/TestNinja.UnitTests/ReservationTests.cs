using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    // TESSTRUNNER LOOKS FOR ALL CLASSES WITH THIS ATTRIBUTE
    // RUN TEST: Ctrl+R A
    [TestClass]
    // CONVENTION: <ClassName>Tests
    public class ReservationTests
    {
        // TESTRUNNER WILL RUN ALL METHODS WITH THIS ATTRIBUTE
        [TestMethod]
        // NAMING CONVENTION: MethodName_StateUnderTest_ExpectedBehavior
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            // TRIPLE A CONVENTION: ARRANGE, ACT, ASSERT

            // ARRANGE: INIT OBJECTS
            var reservation = new Reservation();

            // ACT: ACT ON THIS OBJECT
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });

            // ASSERT: VERIFY RESULT IS CORRECT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            // ARRANGE
            var reservation = new Reservation();
            var user = new User() { IsAdmin = false };

            // ACT
            reservation.MadeBy = user;
            var result = reservation.CanBeCancelledBy(user);

            //ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            // ARRANGE
            var reservation = new Reservation();
            var userA = new User();
            var userB = new User();

            // ACT
            reservation.MadeBy = userA;
            var result = reservation.CanBeCancelledBy(userB);

            // ASSERT
            Assert.IsFalse(result);
        }
    }
}
