using System;
using GildedRose.App.Factory;
using GildedRose.Domain.Models;
using Moq;
using NUnit.Framework;

namespace GildedRose.Tests.Factory
{
    public class StrategyFactoryTests
    {
        [Test]
        public void GetUpdateStrategy_WhenItemIsNull_ThrowsArgumentNullException()
        {
            // Setup
            var serviceProviderMock = new Mock<IServiceProvider>();
            Item item = null;

            // Act
            var factory = new StrategyFactory(serviceProviderMock.Object);
            try
            {
                factory.GetUpdateStrategy(item);
            }
            catch (ArgumentNullException ex)
            {
                Assert.Pass();
            }

            Assert.Fail("The method did not throw an ArgumentNullException");
        }
    }
}
