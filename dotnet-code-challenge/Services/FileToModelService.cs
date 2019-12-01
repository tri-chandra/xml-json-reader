using dotnet_code_challenge.Interfaces;

namespace dotnet_code_challenge.Services
{
    public enum FileType
    {
        XML,
        JSON
    }
    
    public class FileToModelService
    {
        public static IFileToModel GetFileToModel(string filePath, FileType type)
        {
            switch (type)
            {
                case FileType.XML:
                    return new XmlToModelService(filePath);
                case FileType.JSON:
                    return new JsonToModelService(filePath);
                default: // if all enums are covered in the switch-case, should not be reachable
                    return null;
            }
        }
    }
}