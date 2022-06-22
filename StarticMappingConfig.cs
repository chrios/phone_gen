namespace phone_gen
{
    public class StaticMappingConfig
    {
        public StaticMappingConfig(string macAddress, string ipAddress, string localNetName, string hostName, string networkAddress)
        {
            this.macAddress = macAddress;
            this.ipAddress = ipAddress;
            this.localNetName = localNetName;
            this.hostName = hostName;
            this.networkAddress = networkAddress;
        }
        public string macAddress { get; set; }
        public string ipAddress { get; set; }
        public string localNetName { get; set; }
        public string hostName { get; set; }
        public string networkAddress { get; set; }

        public string GetConfig()
        {
            return @"set service dhcp-server shared-network-name <localNetName> subnet <networkAddress> static-mapping <hostName> ip-address <ipAddress>
set service dhcp-server shared-network-name <localNetName> subnet <networkAddress> static-mapping <hostName> mac-address '<macAddress>'"
                .Replace("<macAddress>", macAddress)
                .Replace("<ipAddress>", ipAddress)
                .Replace("<localNetName>", localNetName)
                .Replace("<hostName>", hostName)
                .Replace("<networkAddress>", networkAddress);
        }
    }
}