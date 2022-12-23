using System.Net;

namespace NetNsLookup
{
    internal class NetLookup
    {
        static void Main(string[] args)
        {
            IPHostEntry entry = GetHostEntry(args[0]);

            Console.WriteLine($"Hostname: {entry.HostName}");

            foreach (IPAddress result in entry.AddressList)
            {
                Console.WriteLine(result);
            }
        }

        static IPHostEntry GetHostEntry(string ip)
        {
            return Dns.GetHostEntry(ip);
        }
    }
}