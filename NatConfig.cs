namespace phone_gen
{
    public class NatConfig
    {
        public NatConfig(string ruleNumber, string description, string destinationPort, string inboundInterface, string insideAddress)
        {
            this.ruleNumber = ruleNumber;
            this.description = description;
            this.destinationPort = destinationPort;
            this.inboundInterface = inboundInterface;
            this.insideAddress = insideAddress;

        }
        public string ruleNumber { get; set; }
        public string description { get; set; }
        public string destinationPort { get; set; }
        public string inboundInterface { get; set; }
        public string insideAddress { get; set; }

        public string GetConfig()
        {
            return @"set service nat rule <ruleNumber> description <description>
set service nat rule <ruleNumber> destination port <destinationPort>
set service nat rule <ruleNumber> inbound-interface <inboundInterface>
set service nat rule <ruleNumber> inside-address address <insideAddress>
set service nat rule <ruleNumber> protocol udp
set service nat rule <ruleNumber> type destination"
                .Replace("<ruleNumber>", ruleNumber)
                .Replace("<description>", description)
                .Replace("<destinationPort>", destinationPort)
                .Replace("<inboundInterface>", inboundInterface)
                .Replace("<insideAddress>", insideAddress);
        }
    }
}