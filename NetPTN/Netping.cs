using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace NetPTN
{
    public class Netping
    {
        // constant to use as the data sent in the ping packet
        private const string DATA = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        // do a ping using a string
        public static PingReply DoNetPing(string destination)
        {
            // create new pinger
            Ping pinger = new();
            // set ping options
            PingOptions options = new() { Ttl = 128 };

            // string bits
            byte[] buffer = Encoding.ASCII.GetBytes(DATA);
            int timeout = 120;

            // send the ICMP packet
            PingReply reply = pinger.Send(destination, timeout, buffer, options);

            Thread.Sleep(1000);

            // return reply
            return reply;
        }

        // do a ping using an IP AddresS
        public static PingReply DoNetPing(IPAddress destination)
        {
            // create new pinger
            Ping pinger = new();
            // set ping options
            PingOptions options = new() { Ttl = 128 };

            // string bits
            byte[] buffer = Encoding.ASCII.GetBytes(DATA);
            int timeout = 120;

            // send the ICMP packet
            PingReply reply = pinger.Send(destination, timeout, buffer, options);

            Thread.Sleep(1000);

            // return reply
            return reply;
        }
    }
}
