using System.Collections.Generic;
using dotnet_code_challenge.Interfaces;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.Services
{
    public class JsonToModelService : IFileToModel
    {
        private string _jsonString;
        public JsonToModelService(string filePath)
        {
//            _jsonString = System.IO.File.ReadAllText(filePath);
        }
        
        public IEnumerable<Horse> GetHorses()
        {
            throw new System.NotImplementedException();
        }
    }
}