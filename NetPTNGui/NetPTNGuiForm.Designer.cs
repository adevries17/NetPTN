namespace NetPTNGui
{
    partial class NetPTNGuiForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QueryInputBox = new System.Windows.Forms.TextBox();
            this.QueryLabel = new System.Windows.Forms.Label();
            this.PingTCheckbox = new System.Windows.Forms.CheckBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.PingTextbox = new System.Windows.Forms.TextBox();
            this.TraceRouteTextbox = new System.Windows.Forms.TextBox();
            this.DNSTextbox = new System.Windows.Forms.TextBox();
            this.StopPingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QueryInputBox
            // 
            this.QueryInputBox.BackColor = System.Drawing.Color.Gray;
            this.QueryInputBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QueryInputBox.ForeColor = System.Drawing.Color.White;
            this.QueryInputBox.Location = new System.Drawing.Point(129, 6);
            this.QueryInputBox.Name = "QueryInputBox";
            this.QueryInputBox.Size = new System.Drawing.Size(200, 27);
            this.QueryInputBox.TabIndex = 0;
            // 
            // QueryLabel
            // 
            this.QueryLabel.AutoSize = true;
            this.QueryLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QueryLabel.Location = new System.Drawing.Point(11, 9);
            this.QueryLabel.Name = "QueryLabel";
            this.QueryLabel.Size = new System.Drawing.Size(111, 20);
            this.QueryLabel.TabIndex = 1;
            this.QueryLabel.Text = "IP or Hostname";
            // 
            // PingTCheckbox
            // 
            this.PingTCheckbox.AutoSize = true;
            this.PingTCheckbox.Location = new System.Drawing.Point(11, 36);
            this.PingTCheckbox.Name = "PingTCheckbox";
            this.PingTCheckbox.Size = new System.Drawing.Size(65, 21);
            this.PingTCheckbox.TabIndex = 2;
            this.PingTCheckbox.Text = "Ping -t";
            this.PingTCheckbox.UseVisualStyleBackColor = true;
            // 
            // GoButton
            // 
            this.GoButton.AutoSize = true;
            this.GoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GoButton.Location = new System.Drawing.Point(336, 6);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 27);
            this.GoButton.TabIndex = 3;
            this.GoButton.Text = "Go!";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // PingTextbox
            // 
            this.PingTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PingTextbox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PingTextbox.ForeColor = System.Drawing.Color.White;
            this.PingTextbox.Location = new System.Drawing.Point(537, 63);
            this.PingTextbox.Multiline = true;
            this.PingTextbox.Name = "PingTextbox";
            this.PingTextbox.Size = new System.Drawing.Size(435, 486);
            this.PingTextbox.TabIndex = 4;
            // 
            // TraceRouteTextbox
            // 
            this.TraceRouteTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TraceRouteTextbox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TraceRouteTextbox.ForeColor = System.Drawing.Color.White;
            this.TraceRouteTextbox.Location = new System.Drawing.Point(11, 263);
            this.TraceRouteTextbox.Multiline = true;
            this.TraceRouteTextbox.Name = "TraceRouteTextbox";
            this.TraceRouteTextbox.Size = new System.Drawing.Size(520, 286);
            this.TraceRouteTextbox.TabIndex = 5;
            // 
            // DNSTextbox
            // 
            this.DNSTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DNSTextbox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DNSTextbox.ForeColor = System.Drawing.Color.White;
            this.DNSTextbox.Location = new System.Drawing.Point(12, 63);
            this.DNSTextbox.Multiline = true;
            this.DNSTextbox.Name = "DNSTextbox";
            this.DNSTextbox.Size = new System.Drawing.Size(519, 194);
            this.DNSTextbox.TabIndex = 6;
            // 
            // StopPingButton
            // 
            this.StopPingButton.AutoSize = true;
            this.StopPingButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StopPingButton.Location = new System.Drawing.Point(417, 6);
            this.StopPingButton.Name = "StopPingButton";
            this.StopPingButton.Size = new System.Drawing.Size(141, 27);
            this.StopPingButton.TabIndex = 7;
            this.StopPingButton.Text = "Stop pinging!";
            this.StopPingButton.UseVisualStyleBackColor = true;
            this.StopPingButton.Click += new System.EventHandler(this.StopPingButton_Click);
            // 
            // NetPTNGuiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.StopPingButton);
            this.Controls.Add(this.DNSTextbox);
            this.Controls.Add(this.TraceRouteTextbox);
            this.Controls.Add(this.PingTextbox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.PingTCheckbox);
            this.Controls.Add(this.QueryLabel);
            this.Controls.Add(this.QueryInputBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "NetPTNGuiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetPTN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox QueryInputBox;
        private Label QueryLabel;
        private CheckBox PingTCheckbox;
        private Button GoButton;
        private TextBox PingTextbox;
        private TextBox TraceRouteTextbox;
        private TextBox DNSTextbox;
        private Button StopPingButton;
    }
}