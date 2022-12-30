using System.Net.NetworkInformation;
using System.Text;

namespace NetPTNGui
{
    internal static class NetPTNGui
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new NetPTNGuiForm());
        }

        // send a ping
        public static PingReply SendPing(string destination, int ttl = 128)
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
    }
}