using System;
using System.Collections.Generic;
using System.Linq;
using TruckYeah.Models;

namespace TruckYeah.Services
{
    public class ProgramDriver : IProgramDriver
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
            // blah blah boilerplate "read the file" code 
            Console.WriteLine("Enter the path to your address file: ");
            var addresses = _fileReader.ReadLinesFromFile();

            Console.WriteLine("Enter the path to your drivers file: ");
            var drivers = _fileReader.ReadLinesFromFile();

            // Check to see that there are enough drivers for each address, and vice-versa...
            // if not, just exit early because pebcak 
            if (!_validator.AreThereEnoughDriversForEachDelivery(addresses, drivers))
            {
                Console.WriteLine(
                    "There is a mismatch between the number of delivery addresses and drivers. Please check your input files and try again.");
                return;
            }

            // score the address/drivers
            var scoredDriverAddressCombos = ScoreAndSortDriverAddressCombos(addresses, drivers);

            // they're scored, so print the most optimal scores
            CollateAndPrintScores(scoredDriverAddressCombos);
        }

        public void CollateAndPrintScores(Dictionary<string, DriverAddressCombo> scoredDriverAddressCombos)
        {
            // literally just a throwaway dictionary to track which addresses and drivers have already been used when printing
            // prefer that O[1] lookup time, i'm being inefficient with loops elsewhere in the code
            var usedTokens = new Dictionary<string, double>();

            //loop over the scored address/driver combos, sorted by their scores descending
            foreach (var score in scoredDriverAddressCombos.OrderByDescending(score => score.Value.Score))
            {
                // check to see if this driver or address has already been used, if not, we can print it as an optimal route 
                // since we are sorted by score, we work from most optimal to least optimal, throwing out the rest after all the unique address and drivers have been used
                if (!usedTokens.ContainsKey(score.Value.Driver) && !usedTokens.ContainsKey(score.Value.Address))
                {
                    usedTokens.TryAdd(score.Value.Driver, score.Value.Score);
                    usedTokens.TryAdd(score.Value.Address, score.Value.Score);
                    Console.WriteLine(
                        $"Address: {score.Value.Address}, Driver: {score.Value.Driver}, SS: {score.Value.Score}");
                }
            }
        }

        public Dictionary<string, DriverAddressCombo> ScoreAndSortDriverAddressCombos(List<string> addresses,
            List<string> drivers)
        {
            var scores = new Dictionary<string, DriverAddressCombo>();
            // loop over the addresses
            foreach (var address in addresses)
            {
                // for each address, we need to score each possible driver, so loop over those for each address
                foreach (var driver in drivers)
                {
                    var score = new DriverAddressCombo()
                    {
                        Driver = driver,
                        Address = address,
                        Score = _scoring.ScorePair(address, driver) // scoring algorithm
                    };

                    // i got a little fancy with the key tracking.
                    // for some reason i am paranoid about dupes
                    // so i'm using a hash of the address + driver as the dict key
                    // this ensures that each driver/address combo can only enter the result set once
                    // if this is the first time we've seen this key, just throw it in the dictionary
                    if (!scores.ContainsKey(score.Key))
                    {
                        scores.Add(score.Key, score);
                    }

                    // if we've seen this key before
                    // take the existing one from the dictionary
                    // if our new scored pair somehow has a higher score than what already exists
                    // replace the one that exists already
                    // i don't think this is possible, but better safe than sorry
                    // i've seen some sh*t
                    else
                    {
                        var existingScore = scores[score.Key];
                        if (score.Score > existingScore.Score)
                        {
                            scores[score.Key] = score;
                        }
                    }
                }
            }

            return scores;
        }
    }
}