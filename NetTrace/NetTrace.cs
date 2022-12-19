using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace NetTrace {
    internal class NetTrace {
        static void Main(string[] args) {
            // get ip address from args
            IPHostEntry Host = Dns.GetHostEntry(args[0]);
            IPAddress destIP = Host.AddressList[0];

            // send a ping to destination
            int t = 1; // set ttl
            PingReply ping = SendPing(destIP, t);
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