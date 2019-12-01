using System;
using System.IO;
using dotnet_code_challenge.Interfaces;
using dotnet_code_challenge.Services;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class FileToModelServiceTest
    {
        [Theory]
        [InlineData("", FileType.XML, typeof(XmlToModelService))]
        [InlineData("", FileType.JSON, typeof(JsonToModelService))]
        public void Test1(string filePath, FileType type, Type outputType)
        {
            // arrange & act
            IFileToModel filetoModel = FileToModelService.GetFileToModel(filePath, type);
            
            // assert
            Assert.Equal(outputType, filetoModel.GetType());
        }
    }
}