using System.Linq;
using dotnet_code_challenge.Model;
using dotnet_code_challenge.Services;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class XmlToModelServiceTest
    {
        [Theory]
        [InlineData("./FeedData/Caulfield_Race1.xml", "Advancing", "4.2")]
        public void Test1(string filePath, string name, string price)
        {
            
            // arrange
            var filetoModel = new XmlToModelService(filePath);

            // act
            Horse horse = filetoModel.GetHorses().FirstOrDefault();
            
            // assert
            Assert.Equal(name, horse.Name);
            Assert.Equal(price, horse.Price);
        }
    }
}