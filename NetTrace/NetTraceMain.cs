using NetPing;
using System.Net.NetworkInformation;

namespace NetTrace {
    internal class NetTraceMain {
        static void Main(string[] args) {
            PingReply ping = NetPingMain.SendPing(args[0], ttl: 64);

            if (ping.Status == IPStatus.Success) {
                Console.WriteLine($"Dest: {ping.Address} | TTL: {ping.Options.Ttl} | Latency: {ping.RoundtripTime} | Time: {DateTime.Now}");
            }

        }
    }
}