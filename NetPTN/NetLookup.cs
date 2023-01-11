using System.Net;

namespace NetPTN
{
    internal class NetLookup
    {
        public static IPHostEntry DoNetLookup(string lookupaddr)
        {
            IPHostEntry lookup = Dns.GetHostEntry(lookupaddr);
            return lookup;
        }
    }
}
