using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace NetPTNGui
{
    public class NetTrace
    {
        private const string DATA = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        public static IEnumerable<IPAddress> DoNetTrace(string destination)
        {
            return DoNetTrace(destination, 1);
        }

        private static IEnumerable<IPAddress> DoNetTrace(string destination, int ttl)
        {
            // create the pinger object with parameters
            Ping pinger = new();
            PingOptions options = new() { Ttl = ttl };
            int timeout = 10000;
            byte[] buffer = Encoding.ASCII.GetBytes(DATA);

            // actually send the ping
            PingReply reply = pinger.Send(destination, timeout, buffer, options);

            // create a list to store ip results
            List<IPAddress> result = new();
            if (reply.Status == IPStatus.Success)
            {
                result.Add(reply.Address);
            }
            else if (reply.Status == IPStatus.TimedOut || reply.Status == IPStatus.TtlExpired || reply.Status == IPStatus.TimeExceeded)
            {
                // add returned addr to list if address was found with ttl
                if (reply.Status == IPStatus.TtlExpired)
                {
                    result.Add(reply.Address);
                }

                // next address
                IEnumerable<IPAddress> tempaddr = DoNetTrace(destination, ttl + 1);

                result.AddRange(tempaddr);
            }
            else
            {
                // failure to 
            }

            return result;
        }
    }
}
