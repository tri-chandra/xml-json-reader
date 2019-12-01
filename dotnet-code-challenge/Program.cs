using System;
using System.Linq;
using dotnet_code_challenge.Services;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data from Wolferhampton_Race1.json: (format: [Name]: [Price])");
            
            var jsonModelReader = FileToModelService.GetFileToModel("./FeedData/Wolferhampton_Race1.json", FileType.JSON);
            var horses = jsonModelReader.GetHorses();
            var orderedHorses = horses.OrderBy(x => x.Price);

            foreach (var horse in orderedHorses)
            {
                Console.WriteLine($"- {horse.Name}: {horse.Price}");
            }

            Console.WriteLine();
            Console.WriteLine("Data from Caulfield_Race1.xml:  (format: [Name]: [Price])");
            
            var xmlModelReader = FileToModelService.GetFileToModel("./FeedData/Caulfield_Race1.xml", FileType.XML);
            horses = xmlModelReader.GetHorses();
            orderedHorses = horses.OrderBy(x => x.Price);

            foreach (var horse in orderedHorses)
            {
                Console.WriteLine($"- {horse.Name}: {horse.Price}");
            }

            Console.ReadKey();
        }
    }
}
