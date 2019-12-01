using System.Linq;
using dotnet_code_challenge.Model;
using dotnet_code_challenge.Services;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class JsonToModelServiceTest
    {
        [Theory]
        [InlineData("./FeedData/Wolferhampton_Race1.json", "Toolatetodelegate", "10")]
        public void Test1(string filePath, string name, string price)
        {
            
            // arrange
            var filetoModel = new JsonToModelService(filePath);

            // act
            Horse horse = filetoModel.GetHorses().FirstOrDefault();
            
            // assert
            Assert.Equal(name, horse.Name);
            Assert.Equal(price, horse.Price);
        }
    }
}