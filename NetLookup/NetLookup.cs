using System.Net;
using System.Net.Sockets;

namespace NetNsLookup
{
    internal class NetLookup
    {
        static void Main(string[] args)
        {
            try
            {
                IPHostEntry entry = GetHostEntry(args[0]);

                Console.WriteLine($"Hostname: {entry.HostName}");

                foreach (IPAddress result in entry.AddressList)
                {
                    Console.WriteLine(result);
                }
            }
            catch (SocketException)
            {
                Console.WriteLine($"{args[0]} not found");
            }
            catch
            {
                throw;
            }
        }

        static IPHostEntry GetHostEntry(string ip)
        {
            return Dns.GetHostEntry(ip);
        }
    }
}