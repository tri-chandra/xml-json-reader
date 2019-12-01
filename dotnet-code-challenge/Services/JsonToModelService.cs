using System.Collections;
using System.Collections.Generic;
using System.Linq;
using dotnet_code_challenge.Interfaces;
using dotnet_code_challenge.Model;
using Newtonsoft.Json.Linq;

namespace dotnet_code_challenge.Services
{
    public class JsonToModelService : IFileToModel
    {
        private string _jsonString;
        public JsonToModelService(string filePath)
        {
            _jsonString = System.IO.File.ReadAllText(filePath);
        }
        
        public IEnumerable<Horse> GetHorses()
        {
            JToken token = JObject.Parse(_jsonString);

            var markets = token.SelectToken("RawData").SelectToken("Markets").Values<JObject>();
            IEnumerable<JObject> selections = markets.SelectMany(
                x => x.SelectToken("Selections").Values<JObject>()
            );
            
            var horseTokens = token.SelectToken("RawData").SelectToken("Participants").Values<JObject>();
            IEnumerable<Horse> horses = horseTokens.Select(x => x.ToObject<Horse>());
            var result = horses.Join<Horse, JObject, string, Horse>(
                selections,
                horse => horse.Id,
                selection => selection.SelectToken("Tags").SelectToken("participant").Value<string>(),
                (horse, selection) => new Horse()
                {
                    Id = horse.Id,
                    Name = horse.Name,
                    Price = selection.SelectToken("Price").Value<string>()
                }
            );

            return result;
        }
    }
}