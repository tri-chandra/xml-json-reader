using System.Collections.Generic;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.Interfaces
{
    public interface IFileToModel
    {
        IEnumerable<Horse> GetHorses();
    }
}