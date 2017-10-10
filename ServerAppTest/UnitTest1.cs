using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerApp;

namespace ServerAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GenerateRandomDataTest()
        {
            //Arrange
            int expected = 5;

            //Act
            var response = Helpers.GenerateRandomData();

            //Assert
            Assert.AreEqual(response.Count, expected);
        }

        [TestMethod]
        public void ParseFileToResponseTest()
        {
            //Arrange
            string testString = "#A:RED:5\r\n#B:BLUE:10";
            var expectedValue = 10;

            //Act
            var response = Helpers.ParseFileToResponse(testString);

            //Assert
            Assert.AreEqual(response[1].Value, expectedValue);
        }
    }
}
