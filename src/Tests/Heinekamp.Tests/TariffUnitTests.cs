//using FluentAssertions;
//using Heinekamp.Domain.Entities;

//namespace Heinekamp.Tests
//{
//    public class TariffUnitTests
//    {
//        [InlineData(3500, 830)]
//        [InlineData(4500, 1050)]
//        [Theory]
//        public void BasicTariff_Should_Return_Correct_Value(int consumption, decimal expected)
//        {
//            var basicTariff = new BasicTariffElectricityProduct
//            {
//                Name = "Product A",
//                Type = 1,
//                BaseCost = 5,
//                AdditionalKwhCost = 22
//            };

//            var consumptionCost = basicTariff.GetCalculationStrategy(consumption);

//            consumptionCost
//                .Should()
//                .Be(expected);
//        }

//        [InlineData(3500, 800)]
//        [InlineData(4500, 950)]
//        [Theory]
//        public void PackagedTariff_Should_Return_Correct_Value(int consumption, decimal expected)
//        {
//            var packagedTariff = new PackagedTariffElectricityProduct
//            {
//                Name = "Product B",
//                Type = 2,
//                BaseCost = 800,
//                IncludedKwh = 4000,
//                AdditionalKwhCost = 30
//            };

//            var consumptionCost = packagedTariff.GetCalculationStrategy(consumption);

//            consumptionCost
//                .Should()
//                .Be(expected);
//        }
//    }
//}