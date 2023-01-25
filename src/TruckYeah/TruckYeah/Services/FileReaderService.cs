using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckYeah.Services
{
    class FileReaderService : IFileReaderService
    {
        // this is impossible to unit test since it depends on system I/O
        // keep it as small as possible to minimize hit to test coverage metrics
        // just gotta trust it works, and test around it
        // manual e2e testing will confirm if this actually works
        public List<string> ReadLinesFromFile()
        {
            string filePath = "";
            try
            {
                filePath = Console.ReadLine();
                return System.IO.File.ReadLines(filePath).ToList();
            }
            catch (Exception ex)
            {
                // let the user know there was a problem and gracefully return an empty list
                Console.WriteLine("Error trying to read file: " + filePath);
                Console.WriteLine(ex.Message);
                return new List<string>();
            }
        }
    }
}