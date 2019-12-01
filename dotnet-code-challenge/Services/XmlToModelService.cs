using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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
        }
        
        public IEnumerable<Horse> GetHorses()
        {
            XDocument doc = XDocument.Parse(_xmlString);
            var races = doc.Element("meeting").Element("races").Elements("race").ToList();

            var horses = races.SelectMany(x => x.Element("horses").Elements("horse"));
            var prices = races.SelectMany(
                x => x.Element("prices").Elements("price")
            ).SelectMany(
                x => x.Element("horses").Elements("horse")    
            );

            var result = horses.Join(
                prices,
                horse => horse.Element("number").Value,
                price => price.Attribute("number").Value,
                (horse, price) => new Horse()
                {
                    Id = horse.Element("number").Value,
                    Name = horse.Attribute("name").Value,
                    Price = price.Attribute("Price").Value
                }
            );
            return result;
        }
    }
}