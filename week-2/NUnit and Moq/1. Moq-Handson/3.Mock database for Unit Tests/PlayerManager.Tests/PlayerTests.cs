using NUnit.Framework;
using Moq;
using PlayersManagerLib;
using System;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IPlayerMapper> _mockPlayerMapper;

        [OneTimeSetUp]
        public void Init()
        {
            _mockPlayerMapper = new Mock<IPlayerMapper>();

            // Mock returns false (name doesn't exist in DB)
            _mockPlayerMapper.Setup(m => m.IsPlayerNameExistsInDb(It.IsAny<string>()))
                             .Returns(false);

            // Mock AddNewPlayerIntoDb (no operation needed)
            _mockPlayerMapper.Setup(m => m.AddNewPlayerIntoDb(It.IsAny<string>()));
        }

        [Test]
        public void RegisterNewPlayer_ShouldReturnPlayer_WhenValidName()
        {
            // Act
            var player = Player.RegisterNewPlayer("Virat", _mockPlayerMapper.Object);

            // Assert
            Assert.IsNotNull(player);
            Assert.AreEqual("Virat", player.Name);
            Assert.AreEqual(23, player.Age);
            Assert.AreEqual("India", player.Country);
            Assert.AreEqual(30, player.NoOfMatches);
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrowException_WhenNameIsNull()
        {
            // Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                Player.RegisterNewPlayer(null, _mockPlayerMapper.Object));

            Assert.That(ex.Message, Is.EqualTo("Player name can’t be empty."));
        }

        [Test]
        public void RegisterNewPlayer_ShouldThrowException_WhenNameAlreadyExists()
        {
            // Arrange
            _mockPlayerMapper.Setup(m => m.IsPlayerNameExistsInDb("Sachin")).Returns(true);

            // Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                Player.RegisterNewPlayer("Sachin", _mockPlayerMapper.Object));

            Assert.That(ex.Message, Is.EqualTo("Player name already exists."));
        }
    }
}
