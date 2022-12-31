using System.Net;
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


            // start nslookup
            IPHostEntry lookupreturn = await Task.Run(() => DoLookup(QueryInputBox.Text.ToString()));

            if (lookupreturn == null)
            {
                DNSTextbox.Text = string.Format($"No host entry found for {QueryInputBox.Text}");
            }
            else
            {
                // write out hostname
                DNSTextbox.Text = string.Format($"Hostname: {lookupreturn.HostName}{Environment.NewLine}");

                // write out aliases
                DNSTextbox.Text += "Aliases" + Environment.NewLine;
                foreach (string alias in lookupreturn.Aliases)
                {
                    DNSTextbox.Text += alias + Environment.NewLine;
                }
                DNSTextbox.Text += Environment.NewLine;

                // write out addresses
                DNSTextbox.Text += "Addresses" + Environment.NewLine;
                foreach (IPAddress address in lookupreturn.AddressList)
                {
                    DNSTextbox.Text += address + Environment.NewLine;
                }
            }



            // start traceroute
            string tracereturn = await Task.Run(() => DoTrace());
            TraceRouteTextbox.Text += tracereturn;


            // start ping



            GoButton.Enabled = true;
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
        private static IPHostEntry DoLookup(string lookuphost)
        {
            IPHostEntry hostentry = NetPTNGui.NsLookup(lookuphost);

            return hostentry;
        }


        // traceroute
        private static string DoTrace()
        {
            return "trace from another thread!" + Environment.NewLine;
        }
    }
}