using System.Collections.Generic;
using dotnet_code_challenge.Interfaces;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.Services
{
    public class XmlToModelService : IFileToModel
    {
        private string _xmlString;
        public XmlToModelService(string filePath)
        {
            _xmlString = System.IO.File.ReadAllText(filePath);
            var x = _xmlString;
        }
        
        public IEnumerable<Horse> GetHorses()
        {
            throw new System.NotImplementedException();
        }
    }
}