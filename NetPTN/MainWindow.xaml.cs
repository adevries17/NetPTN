using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;

namespace NetPTN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // lock the go button
                GoButton.IsEnabled = false;

                // clear text boxes
                DNSTextBlock.Text = string.Empty;
                TraceTextBlock.Text = string.Empty;
                PingTextBlock.Text = string.Empty;

                string query = QueryInputTextBox.Text;

                // do a lookup
                IPHostEntry lookup = await Task.Run(() => NetLookup.DoNetLookup(query));
                DNSTextBlock.Text += string.Format($"DNS results for {QueryInputTextBox.Text}{Environment.NewLine}");

                // cnames
                DNSTextBlock.Text += "Aliases:" + Environment.NewLine;
                foreach (string alias in lookup.Aliases)
                {
                    DNSTextBlock.Text += alias + Environment.NewLine;
                }

                DNSTextBlock.Text += Environment.NewLine;

                // ip addresses
                DNSTextBlock.Text += "Addresses:" + Environment.NewLine;
                foreach (IPAddress ip in lookup.AddressList)
                {
                    DNSTextBlock.Text += ip + Environment.NewLine;
                }



                // do a ping
                PingTextBlock.Text += string.Format($"Ping Results for {QueryInputTextBox.Text}{Environment.NewLine}");
                for (int i = 0; i < 4; i++)
                {
                    PingReply pingresult = await Task.Run(() => Netping.DoNetPing(query));
                    PingTextBlock.Text += string.Format($"Addr {pingresult.Address} | Latency {pingresult.RoundtripTime}ms | Time {DateTime.Now}{Environment.NewLine}");
                }



                // do a traceroute
                IEnumerable<IPAddress> traceresult = await Task.Run(() => NetTrace.DoNetTrace(query));
                TraceTextBlock.Text += string.Format($"Traceroute for {QueryInputTextBox.Text}{Environment.NewLine}");

                int index = 0;
                foreach (IPAddress ip in traceresult)
                {
                    TraceTextBlock.Text += index.ToString() + " " + ip.ToString() + Environment.NewLine;
                    index++;
                }


                // enable go button after process is complete
                GoButton.IsEnabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
