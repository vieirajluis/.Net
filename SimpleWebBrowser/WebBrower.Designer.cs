namespace appWebBrowser
{
    partial class frmWebBrower
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerBrowser = new System.Windows.Forms.SplitContainer();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnGO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBrowser)).BeginInit();
            this.splitContainerBrowser.Panel1.SuspendLayout();
            this.splitContainerBrowser.Panel2.SuspendLayout();
            this.splitContainerBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerBrowser
            // 
            this.splitContainerBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBrowser.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBrowser.Name = "splitContainerBrowser";
            this.splitContainerBrowser.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBrowser.Panel1
            // 
            this.splitContainerBrowser.Panel1.Controls.Add(this.btnGO);
            this.splitContainerBrowser.Panel1.Controls.Add(this.txtURL);
            this.splitContainerBrowser.Panel1.Controls.Add(this.btnHome);
            this.splitContainerBrowser.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainerBrowser.Panel1.Controls.Add(this.btnForward);
            this.splitContainerBrowser.Panel1.Controls.Add(this.btnBack);
            this.splitContainerBrowser.Panel1MinSize = 15;
            // 
            // splitContainerBrowser.Panel2
            // 
            this.splitContainerBrowser.Panel2.Controls.Add(this.webBrowser);
            this.splitContainerBrowser.Panel2MinSize = 85;
            this.splitContainerBrowser.Size = new System.Drawing.Size(1071, 720);
            this.splitContainerBrowser.SplitterDistance = 40;
            this.splitContainerBrowser.TabIndex = 23;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1071, 676);
            this.webBrowser.TabIndex = 23;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(0, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 29);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(81, 17);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 29);
            this.btnForward.TabIndex = 16;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(162, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 29);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(243, 17);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 29);
            this.btnHome.TabIndex = 18;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(324, 17);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(369, 28);
            this.txtURL.TabIndex = 19;
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(699, 17);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(41, 29);
            this.btnGO.TabIndex = 20;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // frmWebBrower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1071, 720);
            this.Controls.Add(this.splitContainerBrowser);
            this.Name = "frmWebBrower";
            this.Text = "WebBrowser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmWebBrower_Load);
            this.splitContainerBrowser.Panel1.ResumeLayout(false);
            this.splitContainerBrowser.Panel1.PerformLayout();
            this.splitContainerBrowser.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBrowser)).EndInit();
            this.splitContainerBrowser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerBrowser;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}

