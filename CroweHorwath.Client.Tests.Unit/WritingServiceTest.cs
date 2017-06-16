using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CroweHorwath.Api;
using Moq;

namespace CroweHorwath.Client.Tests.Unit
{
    [TestClass]
    public class WritingServiceTest
    {
        [TestMethod]
        public void WhenRecieveRequestICallSettingsService()
        {
            //assemble
            var mockSetting = new Mock<ISettings>();
            mockSetting.Setup(x => x.GetValueByKey(It.IsAny<string>())).Returns("console");

            //act
            var objectUnderTest = new WritingService(mockSetting.Object);

            objectUnderTest.RequestToWrite("xx");


            //assert
            mockSetting.Verify(t => t.GetValueByKey(It.IsAny<string>()));
           

        }
    }
}
