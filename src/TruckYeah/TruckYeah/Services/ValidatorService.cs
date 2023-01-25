using System.Collections.Generic;

namespace TruckYeah.Services
{
    public class ValidatorService : IValidatorService
    {
        public bool AreThereEnoughDriversForEachDelivery(List<string> addresses, List<string> drivers)
        {
            return addresses?.Count == drivers?.Count;
        }
    }
}