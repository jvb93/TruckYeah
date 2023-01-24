using System;

namespace TruckYeah.Services
{
    class ProgramDriver : IProgramDriver
    {
        private readonly IFileReaderService _fileReader;
        private readonly IValidatorService _validator;
        private readonly IScoringService _scoring;

        public ProgramDriver(IFileReaderService fileReader, IValidatorService validator, IScoringService scoring)
        {
            _fileReader = fileReader;
            _validator = validator;
            _scoring = scoring;
        }

        public void Run()
        {
            Console.WriteLine("Enter the path to your address file");
            var addresses = _fileReader.GetAddressesFromFile();
            
            Console.WriteLine("Enter the path to your drivers file");
            var drivers = _fileReader.GetDriverNamesFromFile();

            if (_validator.AreThereEnoughDriversForEachDelivery(addresses, drivers))
            {
                Console.WriteLine(
                    "There is a mismatch between the number of delivery addresses and drivers. Please check your input files and try again.");
                return;
            }

            foreach (var address in addresses)
            {
                foreach (var driver in drivers)
                {
                }
            }
        }
    }
}