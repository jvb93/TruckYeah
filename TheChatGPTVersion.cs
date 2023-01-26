using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Get shipment destinations
        Console.WriteLine("Enter path of shipment destinations file:");
        string destFilePath = Console.ReadLine();
        string[] dests = File.ReadAllLines(destFilePath);

        // Get drivers
        Console.WriteLine("Enter path of drivers file:");
        string driverFilePath = Console.ReadLine();
        string[] drivers = File.ReadAllLines(driverFilePath);

        // Assign shipments to drivers
        double totalSS = 0;
        for (int i = 0; i < dests.Length; i++)
        {
            double maxSS = 0;
            int maxSSIndex = 0;

            // Find driver with highest SS for this shipment
            for (int j = 0; j < drivers.Length; j++)
            {
                double SS = GetSuitabilityScore(dests[i], drivers[j]);
                if (SS > maxSS)
                {
                    maxSS = SS;
                    maxSSIndex = j;
                }
            }

            // Assign shipment to driver
            totalSS += maxSS;
            drivers[maxSSIndex] = "";
            Console.WriteLine("Assigned shipment {0} to driver {1} with SS {2}", dests[i], drivers[maxSSIndex], maxSS);
        }

        // Print total SS
        Console.WriteLine("Total SS: {0}", totalSS);
    }

    static double GetSuitabilityScore(string dest, string driver)
    {
        // Convert input to lowercase
        dest = dest.ToLower();
        driver = driver.ToLower();

        // Get base SS
        double SS = 0;
        if (dest.Length % 2 == 0)
        {
            SS = dest.Count(c => "aeiou".Contains(c)) * 1.5;
        }
        else
        {
            SS = dest.Count(c => !"aeiou".Contains(c));
        }

        // Check for common factors
        if (HasCommonFactor(dest.Length, driver.Length))
        {
            SS *= 1.5;
        }

        return SS;
    }

    static bool HasCommonFactor(int a, int b)
    {
        for (int i = 2; i <= Math.Min(a, b); i++)
        {
            if (a % i == 0 && b % i == 0)
            {
                return true;
            }
        }
        return false;
    }
}
