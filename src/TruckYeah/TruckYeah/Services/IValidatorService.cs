using System.Collections.Generic;

namespace TruckYeah.Services
{
    public interface IValidatorService
    {
        public bool AreThereEnoughDriversForEachDelivery(List<string> addresses, List<string> drivers);
    }
}