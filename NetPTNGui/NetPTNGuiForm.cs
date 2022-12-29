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
        private void GoButton_Click(object sender, EventArgs e)
        {
            // clear boxes
            DNSTextbox.Clear();
            TraceRouteTextbox.Clear();
            PingTextbox.Clear();

            // reset StopPing
            StopPingButton.DialogResult = DialogResult.Continue;


            Parallel.Invoke(
                // do ping
                () =>
                {
                    DoPing();
                },
                // do nslookup
                () =>
                {
                    DoLookup();
                },
                // do traceroute
                () =>
                {
                    DoTrace();
                }
            );
        }


        // stop ping
        private void StopPingButton_Click(object sender, EventArgs e)
        {
            StopPingButton.DialogResult = DialogResult.OK;
        }


        // ping
        private void DoPing()
        {
            PingTextbox.Text += "ping" + Environment.NewLine;
        }


        // nslookup
        private void DoLookup()
        {
            DNSTextbox.Text += "nslookup" + Environment.NewLine;
        }


        // traceroute
        private void DoTrace()
        {
            TraceRouteTextbox.Text += "trace" + Environment.NewLine;
        }
    }
}