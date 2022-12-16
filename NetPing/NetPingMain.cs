using System.Net.NetworkInformation;
using System.Text;

namespace NetPing {
    public class NetPingMain {
        public static void Main(string[] args) {
            try {
                // check for single argument and ping 4 times
                if (args.Length == 1) {
                    for (int i = 0; i < 4; i++) {
                        PingReply ping = SendPing(args[0]);

                        if (ping.Status == IPStatus.Success) {
                            Console.WriteLine($"Address = {ping.Address} | Latency = {ping.RoundtripTime} ms | Time = {DateTime.Now}");
                        }
                        Thread.Sleep(1000);
                    }

                }
                // if multiple arguments and -t is specified ping infinitely
                else if (args.Length >= 2 && args[1] == "-t") {
                    while (true) {
                        PingReply ping = SendPing(args[0]);

                        if (ping.Status == IPStatus.Success) {
                            Console.WriteLine($"Address = {ping.Address} | Latency = {ping.RoundtripTime} ms | Time = {DateTime.Now}");
                        }
                        Thread.Sleep(1000);
                    }
                }
                else if (args.Length >= 2 && args[1] != "-t") {
                    // multiple arguments but not known argument
                    Console.WriteLine("Unknown arguments");
                }
            }
            catch (IndexOutOfRangeException) {
                Console.WriteLine("Not enough arguments");
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public static PingReply SendPing(string argument) {
            Ping pingSender = new();

            // string bits
            string data = "this is a string of 32 bytes bob";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;


            PingReply reply = pingSender.Send(argument, timeout, buffer);

            // return reply
            return reply;
        }
    }
}