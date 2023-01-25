using System.Collections.Generic;

namespace TruckYeah.Services
{
    public interface IFileReaderService
    {
        public List<string> ReadLinesFromFile(string filePath);
    }
}