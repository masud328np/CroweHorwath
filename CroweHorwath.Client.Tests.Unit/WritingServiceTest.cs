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
        public void WhenRecieveRequestItCallsSettings()
        {
            //assemble
            var mockSetting = new Mock<ISettings>();
            var mockFactory = new Mock<IWriterFactory>();
            mockSetting.Setup(x => x.GetValueByKey(It.IsAny<string>())).Returns("console");
            mockFactory.Setup(x => x.GetWriter(It.IsAny<string>())).Returns(It.IsAny<IWriter>());

            //act
            var objectUnderTest = new WritingService(mockSetting.Object, mockFactory.Object);

            objectUnderTest.RequestToWrite("xx");

            //assert
            mockSetting.Verify(t => t.GetValueByKey(It.IsAny<string>()));


        }

        [TestMethod]
        public void GivenAppSettings_IfWriterName_ThenCallFactoryToGetWriterObject()
        {
            //assemble
            var mockSetting = new Mock<ISettings>();
            var mockFactory = new Mock<IWriterFactory>();
            var writerTypeName = "console";
            mockSetting.Setup(x => x.GetValueByKey(It.IsAny<string>())).Returns(writerTypeName);
            mockFactory.Setup(x => x.GetWriter(It.IsAny<string>())).Returns(It.IsAny<IWriter>());
            //act
            var objectUnderTest = new WritingService(mockSetting.Object,mockFactory.Object);
            objectUnderTest.RequestToWrite("xx");

            //assert
            mockFactory.Verify(t => t.GetWriter(writerTypeName));


        }


    }
}
