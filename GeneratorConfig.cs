namespace phone_gen
{
    public class GeneratorConfig
    {
        public GeneratorConfig()
        {
            Console.WriteLine("Enter the inbound interface (WAN interface) of the router [eth0]");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                this.inboundInterface = "eth0";
            }
            else
            {
                this.inboundInterface = input;
            }
            input = null;
            Console.WriteLine("Enter the starting number for the NAT/Firewall rules [100]");
            input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                this.startingRuleNumber = 100;
            }
            else
            {
                this.startingRuleNumber = int.Parse(input);
            }
            input = null;
            Console.WriteLine("Enter the number of phones you are installing [3]");
            input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                this.numberOfPhones = 3;
            }
            else
            {
                this.numberOfPhones = int.Parse(input);
            }
            input = null;
            Console.WriteLine("Enter the starting number for the SIP ports [5065]");
            input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                this.startingSipPortNumber = 5065;
            }
            else
            {
                this.startingSipPortNumber = int.Parse(input);
            }
            input = null;
            Console.WriteLine("Enter the starting number for the RTSP ports [14000]");
            input = Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                this.startingRtpPortNumber = 14000;
            }
            else
            {
                this.startingRtpPortNumber = int.Parse(input);
            }
        }
        public string inboundInterface;
        public int startingRuleNumber;
        public int numberOfPhones;
        public int startingSipPortNumber;
        public int startingRtpPortNumber;
    }
}