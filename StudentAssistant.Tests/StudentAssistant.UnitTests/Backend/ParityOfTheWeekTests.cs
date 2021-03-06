﻿using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Moq;
using StudentAssistant.Backend.Models;
using StudentAssistant.Backend.Models.ConfigurationModels;
using StudentAssistant.Backend.Services;
using StudentAssistant.Backend.Services.Implementation;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StudentAssistant.Tests.StudentAssistant.UnitTests.Backend
{
    /// <summary>
    /// Принцип именования методов:
    /// [Тестируемый метод]_[Сценарий]_[Ожидаемое поведение]
    /// </summary>

    //[TestMethod]
    //public void ManagerZReportRequests_ShouldBeAddRequest()
    //{
    //    var fixture = new Fixture();
    //    fixture.Customize(new AutoMoqCustomization());
    //    var timeNow = DateTimeProvider.Now;
    //    var insertedTime = new DateTime(2018, 10, 7, 6, 5, 4);

    //    var deviceDataService = fixture.Freeze<Mock<IFrDeviceDataService>>();

    //    var dataService = fixture.Freeze<Mock<IZReportPrintRequestDataService>>();

    //    var setting = fixture.Build<FrDeviceConfigurationModel>()
    //        .With(w => w.Value, timeNow.ToString("yyyy-MM-dd HH:mm:ss"))
    //        .Create();

    //    var settings = new[]
    //    {
    //            setting
    //        };

    //    deviceDataService.Setup(s => s.GetSettingOfDevice(It.IsAny<int?>(), It.IsAny<int?>())).Returns(settings);

    //    var request = fixture.Build<ZReportPrintRequestModel>()
    //        .With(x => x.InsertedDate, insertedTime)
    //        .Create();

    //    //       dataService.Setup(s => s.GetLastActiveRequest(setting.FrDeviceId)).Returns(request);

    //    var frDeviceAdded = false;
    //    dataService.Setup(s => s.AddRequest(setting.FrDeviceId)).Callback(delegate { frDeviceAdded = true; });

    //    fixture.Inject(deviceDataService);
    //    fixture.Inject(dataService);

    //    var service = fixture.Create<ZReportManagerService>();

    //    service.ManagerZReportRequests();

    //    Assert.IsTrue(frDeviceAdded);
    //}

    public class ParityOfTheWeekTests
    {
        [Fact]
        public void GetPartOfSemester_ReturnsPartOFSemester_ShouldBeReturns_1()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var dateTimeTest = new DateTime(2018, 11, 11);

            var mapper = fixture.Freeze<Mock<IMapper>>();
            var parityOfTheWeekConfigurationModel = fixture.Freeze<Mock<ParityOfTheWeekConfigurationModel>>();

            // Act
            var service = new ParityOfTheWeekService(mapper.Object, parityOfTheWeekConfigurationModel.Object);
            var result = service.GetPartOfSemester(dateTimeTest);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Fact]
        public void GetCountParityOfWeek_ReturnsCountOfParity_ShouldBeReturns_10()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var dateTimeTest = new DateTime(2018, 11, 11);

            var mapper = fixture.Freeze<Mock<IMapper>>();
            var parityOfTheWeekConfigurationModel = fixture.Freeze<Mock<ParityOfTheWeekConfigurationModel>>();

            // Act
            var service = new ParityOfTheWeekService(mapper.Object, parityOfTheWeekConfigurationModel.Object);
            var result = service.GetCountParityOfWeek(dateTimeTest);

            // Assert
            Assert.AreEqual(10, result);
        }

        [Fact]
        public void GetNumberOfSemester_ReturnsNumberOfSemester_ShouldBeReturns_5()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var dateTimeTest = new DateTime(2018, 11, 11);

            var mapper = fixture.Freeze<Mock<IMapper>>();
            var parityOfTheWeekConfigurationModel = fixture.Freeze<Mock<ParityOfTheWeekConfigurationModel>>();

            var startLearningDate = 2016;

            // Act
            var service = new ParityOfTheWeekService(mapper.Object, parityOfTheWeekConfigurationModel.Object);
            var result = service.GetNumberOfSemester(dateTimeTest,startLearningDate);

            // Assert
            Assert.AreEqual(5, result);
        }

        [Fact]
        public void GetParityOfTheWeekByDateTime_ReturnsParityBoolValue_ShouldBeReturns_True()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var dateTimeTest = new DateTime(2018, 11, 11);

            var mapper = fixture.Freeze<Mock<IMapper>>();
            var parityOfTheWeekConfigurationModel = fixture.Freeze<Mock<ParityOfTheWeekConfigurationModel>>();

            // Act
            var service = new ParityOfTheWeekService(mapper.Object, parityOfTheWeekConfigurationModel.Object);
            var result = service.GetParityOfTheWeekByDateTime(dateTimeTest);

            // Assert
            Assert.IsTrue(result);
        }

        [Fact]
        public void GetWeekNumberOfYear_ReturnsWeekOfYear_ShouldBeReturns_45()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var dateTimeTest = new DateTime(2018, 11, 11);

            var mapper = fixture.Freeze<Mock<IMapper>>();
            var parityOfTheWeekConfigurationModel = fixture.Freeze<Mock<ParityOfTheWeekConfigurationModel>>();

            // Act
            var service = new ParityOfTheWeekService(mapper.Object, parityOfTheWeekConfigurationModel.Object);
            var result = service.GetWeekNumberOfYear(dateTimeTest);

            // Assert
            Assert.AreEqual(45, result);
        }

        [Fact]
        public void GenerateDataOfTheWeek_ReturnsCorrectModel_ShouldBeReturns_ParityOfTheWeekModel()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var mapper = fixture.Freeze<Mock<IMapper>>();
            var parityOfTheWeekConfigurationModel = fixture.Freeze<Mock<ParityOfTheWeekConfigurationModel>>();

            var dateTimeTest = new DateTime(2018, 11, 11);

            var expectedModel = new ParityOfTheWeekModel
            {
                DateTimeRequest = dateTimeTest,
                DayOfName = "воскресенье",
                NumberOfSemester = 5,
                ParityOfWeekCount = 10,
                ParityOfWeekToday = true,
                PartOfSemester = 1
            };

            // Act
            var service = new ParityOfTheWeekService(mapper.Object, parityOfTheWeekConfigurationModel.Object);
            var result = service.GenerateDataOfTheWeek(dateTimeTest);

            // Assert
            Assert.AreEqual(expectedModel.DateTimeRequest, result.DateTimeRequest);
        }
    }
}

