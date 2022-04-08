using NUnit.Framework;
// using Booking.Services;

// namespace Booking.UnitTests.Services

[TestFixture] //denotes a class that contains unit tests
public class BookingService_IsTrue
{
    [Test] // indicates a method is a test method
    public void IsTrue_NoInput_ReturnTrue()
    {
        Assert.IsTrue(true);
    }
}