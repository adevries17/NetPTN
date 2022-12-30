using System.Net.NetworkInformation;

namespace NetPTNGui
{
    public partial class NetPTNGuiForm : Form
    {
        public NetPTNGuiForm()
        {
            InitializeComponent();
        }


        // run nslookup
        // run traceroute
        // run ping
        private async void GoButton_Click(object sender, EventArgs e)
        {
            // lock the go button
            GoButton.Enabled = false;

            // clear text boxes
            DNSTextbox.Clear();
            TraceRouteTextbox.Clear();
            PingTextbox.Clear();

            // reset StopPing
            StopPingButton.DialogResult = DialogResult.Continue;

            // start ping
            string PingReturn = await Task.Run(() => DoPing(QueryInputBox.Text.ToString()));
            PingTextbox.Text += PingReturn;
            
            // start nslookup
            string LookupReturn = await Task.Run(() => DoLookup());
            DNSTextbox.Text += LookupReturn;

            // start traceroute
            string TraceReturn = await Task.Run(() => DoTrace());
            TraceRouteTextbox.Text += TraceReturn;
        }


        // stop ping
        private void StopPingButton_Click(object sender, EventArgs e)
        {
            StopPingButton.DialogResult = DialogResult.OK;
        }


        // ping
        private static string DoPing(string PingDest)
        {
            PingReply ping = NetPTNGui.SendPing(PingDest);
            if (ping.Status == IPStatus.Success)
            {
                return string.Format($"Addr {ping.Address} | Latency {ping.RoundtripTime}ms | TTL {ping.Options.Ttl} | Time {DateTime.Now}");
            }
            else return "";
        }


        // nslookup
        private static string DoLookup()
        {
            return "nslookup from another thread!" + Environment.NewLine;
        }


        // traceroute
        private static string DoTrace()
        {
            return "trace from another thread!" + Environment.NewLine;
        }
    }
}