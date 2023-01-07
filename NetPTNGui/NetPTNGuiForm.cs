using System.Net;

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
            var lookprog = new Progress<string>(s => DNSTextbox.Text = s);
            await Task.Run(() => Dolookup(lookprog));
            DNSTextbox.Text = "changed";


            // do a traceroute
            IEnumerable<IPAddress> traceresult = await Task.Run(() => NetTrace.GetNetTrace(QueryInputBox.Text));
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