using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });

            // 3 DIFFERENT APPROACHES!
            Assert.IsTrue(result);
            Assert.That(result, Is.True);
            Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            var reservation = new Reservation();
            var user = new User() { IsAdmin = false };

            reservation.MadeBy = user;
            var result = reservation.CanBeCancelledBy(user);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            var reservation = new Reservation();
            var userA = new User();
            var userB = new User();

            reservation.MadeBy = userA;
            var result = reservation.CanBeCancelledBy(userB);

            Assert.That(result, Is.False);
        }
    }
}
