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


            // do a lookup
            IPHostEntry lookup = await Task.Run(() => Netlookup.DoNetLookup(QueryInputBox.Text));
            DNSTextbox.Text += string.Format($"DNS results for {QueryInputBox.Text}{Environment.NewLine}");

            // cnames
            DNSTextbox.Text += "Aliases:" + Environment.NewLine;
            foreach (string alias in lookup.Aliases)
            {
                DNSTextbox.Text += alias + Environment.NewLine;
            }

            DNSTextbox.Text += Environment.NewLine;

            // ip addresses
            DNSTextbox.Text += "Addresses:" + Environment.NewLine;
            foreach (IPAddress ip in lookup.AddressList)
            {
                DNSTextbox.Text += ip + Environment.NewLine;
            }



            // do a ping
            PingTextbox.Text += string.Format($"Ping Results for {QueryInputBox.Text}{Environment.NewLine}");

            for (int i = 0; i < 4; i++)
            {
                PingReply pingresult = await Task.Run(() => Netping.DoNetPing(QueryInputBox.Text));
                PingTextbox.Text += string.Format($"Addr {pingresult.Address} | Latency {pingresult.RoundtripTime}ms | Time {DateTime.Now}{Environment.NewLine}");
            }



            // do a traceroute
            IEnumerable<IPAddress> traceresult = await Task.Run(() => NetTrace.DoNetTrace(QueryInputBox.Text));
            TraceRouteTextbox.Text += string.Format($"Traceroute for {QueryInputBox.Text}{Environment.NewLine}");

            int index = 0;
            foreach (IPAddress ip in traceresult)
            {
                TraceRouteTextbox.Text += index.ToString() + " " + ip.ToString() + Environment.NewLine;
                index++;
            }


            // enable go button after process is complete
            GoButton.Enabled = true;
        }


        // stop ping
        private void StopPingButton_Click(object sender, EventArgs e)
        {
            StopPingButton.DialogResult = DialogResult.OK;
        }



        // perform a lookup
        public static void Dolookup(IProgress<string> progress)
        {
            Task.Delay(1000).Wait();
            progress.Report("in worker task");
        }
    }
}