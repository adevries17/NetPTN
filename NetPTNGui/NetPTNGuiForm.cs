using System.Net.NetworkInformation;

namespace NetPTNGui
{
    public partial class NetPTNGuiForm : Form
    {
        public NetPTNGuiForm()
        {
            InitializeComponent();
        }



        private void GoButton_Click(object sender, EventArgs e)
        {
            // clear boxes
            DNSTextbox.Clear();
            TraceRouteTextbox.Clear();
            PingTextbox.Clear();

            // reset StopPing
            StopPingButton.DialogResult = DialogResult.Continue;


            // do ping
            switch (PingTCheckbox.Checked)
            {
                // ping -t is checked
                case true:
                {
                    while (StopPingButton.DialogResult != DialogResult.OK)
                    {
                        PingTextbox.Text += "ping" + Environment.NewLine;

                        // sleep 1s / 1000ms
                        Thread.Sleep(1000);
                    }
                    break;
                }

                // ping -t not checked
                case false:
                {
                    for (int i = 0; i < 4; i++)
                    {
                        PingTextbox.Text += "ping" + Environment.NewLine;

                        // sleep 1s / 1000ms
                        Thread.Sleep(1000);
                    }
                    break;
                }

            }


            // do nslookup


            // do traceroute
        }

        private void StopPingButton_Click(object sender, EventArgs e)
        {
            StopPingButton.DialogResult = DialogResult.OK;
        }
    }
}