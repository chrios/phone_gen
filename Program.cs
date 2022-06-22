using phone_gen;
using System.Net;

GeneratorConfig configuration = new GeneratorConfig();
List<Phone> allPhones = new List<Phone>();

for (int x = 1; x <= configuration.numberOfPhones; x++)
{
    Console.WriteLine($"Configuring phone {x} of {configuration.numberOfPhones}...");
    Console.WriteLine("Enter the MAC address of the phone (The NIC that it is connected with, like Wifi or Ethernet MAC)");
    string thisMac = Console.ReadLine();
    Console.WriteLine("Enter the desired IP address of the phone");
    string thisIPAddress = Console.ReadLine();
    Console.WriteLine("Creating phone object...");
    Phone thisPhone = new Phone(thisIPAddress, thisMac);
    Console.WriteLine("Adding phone to list...");
    allPhones.Add(thisPhone);
}

Console.WriteLine("Generating NAT and Firewall Rules...");

Console.WriteLine("Generating config...");

int thisRuleNumber = configuration.startingRuleNumber;
int thisSipPortsNumber = configuration.startingSipPortNumber;
int thisRtpStartPort = configuration.startingRtpPortNumber;

foreach (Phone phone in allPhones)
{
    // generate SIP rules

    phone.sipNatRule = new NatConfig(
        thisRuleNumber.ToString(),
        "SIP to Deskphone",
        thisSipPortsNumber.ToString(),
        configuration.inboundInterface,
        phone.phoneIPAddress.ToString()
    );
    phone.sipFirewallRule = new FirewallConfig(
        thisRuleNumber.ToString(),
        "SIP to deskphone",
        phone.phoneIPAddress.ToString(),
        thisSipPortsNumber.ToString(),
        "WAN_IN"
    );
    
    thisRuleNumber++;

    // generate RTP rules

    phone.rtpNatRule = new NatConfig(
        thisRuleNumber.ToString(),
        "RTP to Deskphone",
        $"{thisRtpStartPort}-{thisRtpStartPort + 19}",
        configuration.inboundInterface,
        phone.phoneIPAddress.ToString()
    );
    phone.rtpFirewallRule = new FirewallConfig(
        thisRuleNumber.ToString(),
        "RTP to deskphone",
        phone.phoneIPAddress.ToString(),
        $"{thisRtpStartPort}-{thisRtpStartPort + 19}",
        "WAN_IN"
    );

    // generate static mapping rules
    /*
        phone.staticMappingRule = new StaticMappingConfig(
            phone.phoneMACAddress.ToString(),
            phone.phoneIPAddress.ToString(),

        )
    */
    // increment port numbers

    thisRuleNumber++;
    thisSipPortsNumber++;
    thisRtpStartPort += 20;
}

Console.WriteLine("Writing out configs to console:\n---");

foreach (Phone phone in allPhones)
{
    Console.WriteLine(phone.rtpFirewallRule.GetConfig());
    Console.WriteLine(phone.rtpNatRule.GetConfig());
    Console.WriteLine(phone.sipFirewallRule.GetConfig());
    Console.WriteLine(phone.sipNatRule.GetConfig());
}

return 0;