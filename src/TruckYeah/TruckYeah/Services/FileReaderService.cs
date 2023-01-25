using System.Collections.Generic;
using System.Linq;

namespace TruckYeah.Services
{
    class FileReaderService : IFileReaderService
    {
        // this is impossible to unit test since it depends on system I/O
        // leave it as a 1-liner to minimize test coverage impacts
        // just gotta trust it works, and test around it
        // manual e2e testing will confirm if this actually works
        public List<string> ReadLinesFromFile(string filePath)
        {
            return System.IO.File.ReadLines(filePath).ToList();
        }
    }
}