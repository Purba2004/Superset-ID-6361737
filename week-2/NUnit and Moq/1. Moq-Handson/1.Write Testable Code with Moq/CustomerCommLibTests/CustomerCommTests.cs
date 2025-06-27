using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLibTests
{
    [TestFixture] // Marks the test class
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [OneTimeSetUp] // Runs once before all tests
        public void Init()
        {
            _mockMailSender = new Mock<IMailSender>();
        }

        [TestCase(true)] // Test with mocked success
        [TestCase(false)] // Test with mocked failure
        public void SendMailToCustomer_ShouldReturnExpectedResult(bool expectedResult)
        {
            // Arrange
            _mockMailSender
                .Setup(sender => sender.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(expectedResult);

            _customerComm = new CustomerComm(_mockMailSender.Object);

            // Act
            var result = _customerComm.SendMailToCustomer();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
