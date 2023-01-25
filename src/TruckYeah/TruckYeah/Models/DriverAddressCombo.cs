using System;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace TruckYeah.Models
{
    public class DriverAddressCombo
    {
        public string Driver { get; set; }
        public string Address { get; set; }
        public double Score { get; set; }

        public string Key
        {
            get
            {
                var combinedAddress = this.Driver + this.Address;
                return String.Format("{0:X}", combinedAddress.GetHashCode());
            }
        }
    }
}