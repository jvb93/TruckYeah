using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Enter the path to your address file: ");
            var filePath = Console.ReadLine();
            var addresses = _fileReader.ReadLinesFromFile(filePath);

            Console.WriteLine("Enter the path to your drivers file: ");
            filePath = Console.ReadLine();
            var drivers = _fileReader.ReadLinesFromFile(filePath);

            if (_validator.AreThereEnoughDriversForEachDelivery(addresses, drivers))
            {
                Console.WriteLine(
                    "There is a mismatch between the number of delivery addresses and drivers. Please check your input files and try again.");
                return;
            }

            var scores = new Dictionary<Tuple<string, string>, double>();
            foreach (var address in addresses)
            {
                foreach (var driver in drivers)
                {
                    var score = _scoring.ScorePair(address, driver);
                    scores.Add(new Tuple<string, string>(address, driver), score );
                }
            }

            foreach (var scorePair in scores.OrderByDescending(score=> score.Value))
            {
                Console.WriteLine(scorePair.Key.Item1 + " " + scorePair.Key.Item2 + " Score: " + scorePair.Value);
            }
        }
    }
}