using System.Net.NetworkInformation;
using System.Text;

namespace NetPing {
    internal class NetPingMain {
        static void Main(string[] args) {
            try {
                // check for single argument and ping 4 times
                if (args.Length == 1) {
                    for (int i = 0; i < 4; i++) {
                        SendPing(args[0]);
                    }

                } else if (args.Length >= 2 && args[1] == "-t") {
                    // if multiple arguments and -t is specified ping infinitely
                    while (true) {
                        SendPing(args[0]);
                    }
                } else if (args.Length >= 2 && args[1] != "-t") {
                    // multiple arguments but not known argument
                    Console.WriteLine("Unknown arguments");
                }
            } catch (IndexOutOfRangeException) {
                Console.WriteLine("Not enough arguments");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        static void SendPing(string argument) {
            Ping pingSender = new();

            // string bits
            string data = "this is a string of 32 bytes bob";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            PingReply reply = pingSender.Send(argument, timeout, buffer);

            if (reply.Status == IPStatus.Success) {
                Console.WriteLine($"Address = {reply.Address} | Latency = {reply.RoundtripTime} ms | Time = {DateTime.Now}");
            }
            Thread.Sleep(1000);
        }
    }
}