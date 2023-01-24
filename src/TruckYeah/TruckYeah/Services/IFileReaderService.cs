using System.Collections.Generic;

namespace TruckYeah.Services
{
    public interface IFileReaderService
    {
        public List<string> GetAddressesFromFile();
        public List<string> GetDriverNamesFromFile();
    }
}