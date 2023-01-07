using System.Net;

namespace NetPTNGui
{
    public class Netlookup
    {
        public static IPHostEntry DoNetLookup(string lookupaddr)
        {
            IPHostEntry lookup = Dns.GetHostEntry(lookupaddr);
            return lookup;
        }
    }
}
