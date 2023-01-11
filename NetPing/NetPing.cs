using System.Net.NetworkInformation;
using System.Text;

namespace NetPing
{
    internal class NetPing
    {
        static void Main(string[] args)
        {
            try
            {
                switch (args.Length)
                {
                    // only contains ping destination
                    case 1:
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                PingReply pinger = SendPing(args[^1], 32);
                                if (pinger.Status == IPStatus.Success)
                                {
                                    WriteResult(pinger);
                                }
                                // pause for 1s / 1000ms
                                Thread.Sleep(1000);
                            }
                            break;
                        }
                    // -t is the only specified
                    case >= 2 when args.Contains("-t"):
                        {
                            // loop infinitely
                            while (true)
                            {
                                PingReply pinger = SendPing(args[0]);
                                if (pinger.Status == IPStatus.Success)
                                {
                                    WriteResult(pinger);
                                    // pause for 1s / 1000ms
                                    Thread.Sleep(1000);
                                }
                            }
                        }
                    default:
                        {
                            Console.WriteLine("Invalid arguments");

                            break;
                        }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Not enough arguments");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // send a ping
        static PingReply SendPing(string destination, int ttl = 128)
        {
            // create new ping sender
            Ping pingSender = new();
            // set ping options
            PingOptions options = new()
            {
                Ttl = ttl
            };

            // string bits
            const string DATA = "this is a string of 32 bytes bob";
            byte[] buffer = Encoding.ASCII.GetBytes(DATA);
            int timeout = 120;

            // send the ICMP packet
            PingReply reply = pingSender.Send(destination, timeout, buffer, options);

            // return reply
            return reply;
        }

        // write to console
        static void WriteResult(PingReply ping)
        {
            Console.WriteLine($"Addr {ping.Address} | Latency {ping.RoundtripTime}ms | TTL {ping.Options.Ttl} | Time {DateTime.Now}");
        }
    }
}