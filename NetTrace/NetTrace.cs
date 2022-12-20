using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace NetTrace {
    internal class NetTrace {
        static void Main(string[] args) {
            // get ip address from args
            IPHostEntry Host = Dns.GetHostEntry(args[0]);
            IPAddress destIP = Host.AddressList[0];

            // create list
            List<IPAddress> PingResults = new();

            // set initial ttl
            int t = 1;

            do {
                // send a ping to destination
                PingReply ping = SendPing(destIP, t);

                if (ping == null) {
                    Console.WriteLine("No return packet received");
                }
                // ping makes it to destination
                else if (ping.Status == IPStatus.Success) {
                    PingResults.Add(ping.Address);
                }
                // ping is dropped because ttl is too low
                else if (ping.Status == IPStatus.TimedOut || ping.Status == IPStatus.TtlExpired || ping.Status == IPStatus.TimeExceeded) {
                    PingResults.Add(ping.Address);
                    t++;
                }
                // all other cases
                else {
                    Console.WriteLine("Unable to perform traceroute");
                }
            }
            while (!PingResults.Contains(destIP));

            // write out results
            int index = 0;
            foreach (IPAddress ip in PingResults) {
                Console.WriteLine($"{index} {ip}");
                index++;
            }
        }

        // ping method
        static PingReply SendPing(IPAddress destination, int ttl = 128) {
            // new ping var
            Ping pingSender = new();
            // ttl options
            PingOptions options = new() {
                Ttl = ttl
            };

            // string bits
            const string data = "this is a string of 32 bytes bob";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            // send the ping
            PingReply reply = pingSender.Send(destination, timeout, buffer, options);

            // return reply
            return reply;
        }
    }
}