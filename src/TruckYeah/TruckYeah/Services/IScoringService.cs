namespace TruckYeah.Services
{
    public interface IScoringService
    {
        public double ScorePair(string address, string driver);
        public int GetGreatestCommonFactor(int first, int second);
    }
}