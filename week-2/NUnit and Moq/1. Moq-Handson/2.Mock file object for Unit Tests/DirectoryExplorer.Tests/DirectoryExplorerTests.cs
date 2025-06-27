using MagicFilesLib;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _mockDirectoryExplorer;
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            _mockDirectoryExplorer = new Mock<IDirectoryExplorer>();
            _mockDirectoryExplorer.Setup(x => x.GetFiles(It.IsAny<string>()))
                .Returns(new List<string> { _file1, _file2 });
        }

        [Test]
        public void GetFiles_ShouldReturnCorrectFileList()
        {
            var explorer = _mockDirectoryExplorer.Object;
            var result = explorer.GetFiles("dummy/path");

            Assert.IsNotNull(result, "Collection should not be null");
            Assert.AreEqual(2, result.Count, "There should be exactly 2 files");
            CollectionAssert.Contains(result, _file1, "Should contain file1");
        }
    }
}
