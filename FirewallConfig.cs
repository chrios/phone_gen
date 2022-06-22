namespace phone_gen
{
    public class FirewallConfig
    {
        public FirewallConfig(string ruleNumber, string description, string destinationAddress, string port, string firewallName)
        {
            this.ruleNumber = ruleNumber;
            this.description = description;
            this.destinationAddress = destinationAddress;
            this.port = port;
            this.firewallName = firewallName;
        }
        public string ruleNumber { get; set; }
        public string description { get; set; }
        public string destinationAddress { get; set; }
        public string port { get; set; }
        public string firewallName { get; set; }
        public string GetConfig()
        {
            return @"set firewall name <firewallName> rule <ruleNumber> action accept
set firewall name <firewallName> rule <ruleNumber> description <description>
set firewall name <firewallName> rule <ruleNumber> destination address <destinationAddress>
set firewall name <firewallName> rule <ruleNumber> destination port <port>
set firewall name <firewallName> rule <ruleNumber> log enable
set firewall name <firewallName> rule <ruleNumber> protocol udp
set firewall name <firewallName> rule <ruleNumber> state new enable"
                .Replace("<ruleNumber>", ruleNumber)
                .Replace("<description>", description)
                .Replace("<destinationAddress>", destinationAddress)
                .Replace("<port>", port)
                .Replace("<firewallName>", firewallName);
        }
    }
}