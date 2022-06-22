using System.Net;
using System.Net.NetworkInformation;

namespace phone_gen
{
    public class Phone
    {
        public Phone(string ipAddress, string macAddress)
        {
            this.phoneIPAddress = IPAddress.Parse(ipAddress);
            this.phoneMACAddress = PhysicalAddress.Parse(macAddress);
        }
        public IPAddress phoneIPAddress { get; set; }
        public PhysicalAddress phoneMACAddress { get; set; }
        public NatConfig? sipNatRule { get; set; }
        public NatConfig? rtpNatRule { get; set; }
        public FirewallConfig? sipFirewallRule { get; set; }
        public FirewallConfig? rtpFirewallRule { get; set; }
        public StaticMappingConfig? staticMappingRule { get; set; }
    }

}