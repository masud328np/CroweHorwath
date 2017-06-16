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
            var mockWriter = new Mock<IWriter>();

            mockSetting.Setup(x => x.GetValueByKey(It.IsAny<string>())).Returns("console");
            mockFactory.Setup(x => x.GetWriter(It.IsAny<string>())).Returns(mockWriter.Object);

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
            var mockWriter = new Mock<IWriter>();

            var writerTypeName = "console";
            mockSetting.Setup(x => x.GetValueByKey(It.IsAny<string>())).Returns(writerTypeName);
            mockFactory.Setup(x => x.GetWriter(It.IsAny<string>())).Returns(mockWriter.Object);
            //act
            var objectUnderTest = new WritingService(mockSetting.Object,mockFactory.Object);
            objectUnderTest.RequestToWrite("xx");

            //assert
            mockFactory.Verify(t => t.GetWriter(writerTypeName));


        }

        [TestMethod]
        public void GivenWriterInstantiated_CallWriteWithRequestedText()
        {
            //assemble
            var mockSetting = new Mock<ISettings>();
            var mockFactory = new Mock<IWriterFactory>();
            var mockWriter = new Mock<IWriter>();

            var writerTypeName = "console";
            mockSetting.Setup(x => x.GetValueByKey(It.IsAny<string>())).Returns(writerTypeName);
            mockFactory.Setup(x => x.GetWriter(It.IsAny<string>())).Returns(mockWriter.Object);
            mockWriter.Setup(x => x.Write(It.IsAny<string>()));
            //act
            var txtToWrite = "xx";
            var objectUnderTest = new WritingService(mockSetting.Object, mockFactory.Object);
            objectUnderTest.RequestToWrite("xx");

            //assert
            mockWriter.Verify(t => t.Write(txtToWrite));


        }


    }
}
