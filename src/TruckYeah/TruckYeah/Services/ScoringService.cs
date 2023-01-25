using TruckYeah.Helpers;

namespace TruckYeah.Services
{
    public class ScoringService : IScoringService
    {
        public double ScorePair(string address, string driver)
        {
            var score = 0.0;
            //If the length of the shipment's destination street name is even
            if (address.IsLengthEven())
            {
                // the base suitability score (SS) is the number of vowels in the driver’s name multiplied by 1.5
                score += (driver.GetVowelCount() * 1.5);
            }
            else
            {
                // the base SS is the number of consonants in the driver’s name multiplied by 1
                score += driver.GetConsonantCount();
            }

            // the question states to multiply the score by 1.5
            // if the address length or driver name length contain ANY common factors excluding 1
            // so just take the greatest common factor of both numbers. if it's > 1, then modify the score
            if (GetGreatestCommonFactor(address.Length, driver.Length) > 1)
            {
                score *= 1.5;
            }

            return score;
        }

        // shamelessly stolen from stackoverflow in the interest of time
        // https://stackoverflow.com/questions/18541832/c-sharp-find-the-greatest-common-divisor
        // apparently uses euclid's algorithm... too much math for me, just unit test it 
        public int GetGreatestCommonFactor(int first, int second)
        {
            while (first != 0 && second != 0)
            {
                if (first > second)
                {
                    first %= second;
                }
                else
                {
                    second %= first;
                }
            }

            return first | second;
        }
    }
}