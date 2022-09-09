namespace Ships_JosefLukasek
{
    partial class ShipsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipsForm));
            this.fullscreenBtn = new System.Windows.Forms.Button();
            this.SingleBtn = new System.Windows.Forms.Button();
            this.MultiBtn = new System.Windows.Forms.Button();
            this.HostModeBtn = new System.Windows.Forms.Button();
            this.JoinModeBtn = new System.Windows.Forms.Button();
            this.SloopBtn = new System.Windows.Forms.Button();
            this.BrigBtn = new System.Windows.Forms.Button();
            this.FrigBtn = new System.Windows.Forms.Button();
            this.GallBtn = new System.Windows.Forms.Button();
            this.ClientIpBox = new System.Windows.Forms.TextBox();
            this.ClientPortBox = new System.Windows.Forms.TextBox();
            this.ClientIpLabel = new System.Windows.Forms.Label();
            this.ClientPortLabel = new System.Windows.Forms.Label();
            this.HostPortBox = new System.Windows.Forms.TextBox();
            this.ClientJoinBtn = new System.Windows.Forms.Button();
            this.HostJoinBtn = new System.Windows.Forms.Button();
            this.HostPortLabel = new System.Windows.Forms.Label();
            this.ReadyBtn = new System.Windows.Forms.Button();
            this.ReplayBtn = new System.Windows.Forms.Button();
            this.MenuBtn = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fullscreenBtn
            // 
            this.fullscreenBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fullscreenBtn.Location = new System.Drawing.Point(1025, 12);
            this.fullscreenBtn.Name = "fullscreenBtn";
            this.fullscreenBtn.Size = new System.Drawing.Size(107, 23);
            this.fullscreenBtn.TabIndex = 0;
            this.fullscreenBtn.Text = "Toggle Fullscreen";
            this.fullscreenBtn.UseVisualStyleBackColor = true;
            this.fullscreenBtn.Click += new System.EventHandler(this.fullscreenBtn_Click);
            // 
            // SingleBtn
            // 
            this.SingleBtn.Location = new System.Drawing.Point(479, 58);
            this.SingleBtn.Name = "SingleBtn";
            this.SingleBtn.Size = new System.Drawing.Size(153, 47);
            this.SingleBtn.TabIndex = 1;
            this.SingleBtn.Text = "Singleplayer";
            this.SingleBtn.UseVisualStyleBackColor = true;
            // 
            // MultiBtn
            // 
            this.MultiBtn.Location = new System.Drawing.Point(479, 111);
            this.MultiBtn.Name = "MultiBtn";
            this.MultiBtn.Size = new System.Drawing.Size(153, 43);
            this.MultiBtn.TabIndex = 2;
            this.MultiBtn.Text = "Multiplayer";
            this.MultiBtn.UseVisualStyleBackColor = true;
            this.MultiBtn.Click += new System.EventHandler(this.MultiBtn_Click);
            // 
            // HostModeBtn
            // 
            this.HostModeBtn.Location = new System.Drawing.Point(320, 58);
            this.HostModeBtn.Name = "HostModeBtn";
            this.HostModeBtn.Size = new System.Drawing.Size(153, 47);
            this.HostModeBtn.TabIndex = 3;
            this.HostModeBtn.Text = "Host game";
            this.HostModeBtn.UseVisualStyleBackColor = true;
            this.HostModeBtn.Visible = false;
            this.HostModeBtn.Click += new System.EventHandler(this.HostModeBtn_Click);
            // 
            // JoinModeBtn
            // 
            this.JoinModeBtn.Location = new System.Drawing.Point(320, 111);
            this.JoinModeBtn.Name = "JoinModeBtn";
            this.JoinModeBtn.Size = new System.Drawing.Size(153, 43);
            this.JoinModeBtn.TabIndex = 4;
            this.JoinModeBtn.Text = "Join game";
            this.JoinModeBtn.UseVisualStyleBackColor = true;
            this.JoinModeBtn.Visible = false;
            this.JoinModeBtn.Click += new System.EventHandler(this.JoinModeBtn_Click);
            // 
            // SloopBtn
            // 
            this.SloopBtn.Location = new System.Drawing.Point(12, 12);
            this.SloopBtn.Name = "SloopBtn";
            this.SloopBtn.Size = new System.Drawing.Size(123, 23);
            this.SloopBtn.TabIndex = 5;
            this.SloopBtn.Text = "Sloop (1x1)";
            this.SloopBtn.UseVisualStyleBackColor = true;
            this.SloopBtn.Click += new System.EventHandler(this.SloopBtn_Click);
            // 
            // BrigBtn
            // 
            this.BrigBtn.Location = new System.Drawing.Point(12, 41);
            this.BrigBtn.Name = "BrigBtn";
            this.BrigBtn.Size = new System.Drawing.Size(123, 23);
            this.BrigBtn.TabIndex = 6;
            this.BrigBtn.Text = "Brigantine (1x2)";
            this.BrigBtn.UseVisualStyleBackColor = true;
            this.BrigBtn.Click += new System.EventHandler(this.BrigBtn_Click);
            // 
            // FrigBtn
            // 
            this.FrigBtn.Location = new System.Drawing.Point(12, 70);
            this.FrigBtn.Name = "FrigBtn";
            this.FrigBtn.Size = new System.Drawing.Size(123, 23);
            this.FrigBtn.TabIndex = 7;
            this.FrigBtn.Text = "Frigate (1x3)";
            this.FrigBtn.UseVisualStyleBackColor = true;
            this.FrigBtn.Click += new System.EventHandler(this.FrigBtn_Click);
            // 
            // GallBtn
            // 
            this.GallBtn.Location = new System.Drawing.Point(12, 99);
            this.GallBtn.Name = "GallBtn";
            this.GallBtn.Size = new System.Drawing.Size(123, 23);
            this.GallBtn.TabIndex = 8;
            this.GallBtn.Text = "Galleon (1x4)";
            this.GallBtn.UseVisualStyleBackColor = true;
            this.GallBtn.Click += new System.EventHandler(this.GallBtn_Click);
            // 
            // ClientIpBox
            // 
            this.ClientIpBox.Location = new System.Drawing.Point(177, 311);
            this.ClientIpBox.Name = "ClientIpBox";
            this.ClientIpBox.Size = new System.Drawing.Size(100, 23);
            this.ClientIpBox.TabIndex = 9;
            // 
            // ClientPortBox
            // 
            this.ClientPortBox.Location = new System.Drawing.Point(177, 340);
            this.ClientPortBox.Name = "ClientPortBox";
            this.ClientPortBox.Size = new System.Drawing.Size(100, 23);
            this.ClientPortBox.TabIndex = 10;
            // 
            // ClientIpLabel
            // 
            this.ClientIpLabel.AutoSize = true;
            this.ClientIpLabel.Location = new System.Drawing.Point(133, 314);
            this.ClientIpLabel.Name = "ClientIpLabel";
            this.ClientIpLabel.Size = new System.Drawing.Size(38, 15);
            this.ClientIpLabel.TabIndex = 11;
            this.ClientIpLabel.Text = "label1";
            // 
            // ClientPortLabel
            // 
            this.ClientPortLabel.AutoSize = true;
            this.ClientPortLabel.Location = new System.Drawing.Point(133, 343);
            this.ClientPortLabel.Name = "ClientPortLabel";
            this.ClientPortLabel.Size = new System.Drawing.Size(38, 15);
            this.ClientPortLabel.TabIndex = 12;
            this.ClientPortLabel.Text = "label1";
            // 
            // HostPortBox
            // 
            this.HostPortBox.Location = new System.Drawing.Point(177, 436);
            this.HostPortBox.Name = "HostPortBox";
            this.HostPortBox.Size = new System.Drawing.Size(100, 23);
            this.HostPortBox.TabIndex = 13;
            // 
            // ClientJoinBtn
            // 
            this.ClientJoinBtn.Location = new System.Drawing.Point(177, 369);
            this.ClientJoinBtn.Name = "ClientJoinBtn";
            this.ClientJoinBtn.Size = new System.Drawing.Size(100, 23);
            this.ClientJoinBtn.TabIndex = 14;
            this.ClientJoinBtn.Text = "button1";
            this.ClientJoinBtn.UseVisualStyleBackColor = true;
            // 
            // HostJoinBtn
            // 
            this.HostJoinBtn.Location = new System.Drawing.Point(177, 465);
            this.HostJoinBtn.Name = "HostJoinBtn";
            this.HostJoinBtn.Size = new System.Drawing.Size(100, 23);
            this.HostJoinBtn.TabIndex = 15;
            this.HostJoinBtn.Text = "button1";
            this.HostJoinBtn.UseVisualStyleBackColor = true;
            // 
            // HostPortLabel
            // 
            this.HostPortLabel.AutoSize = true;
            this.HostPortLabel.Location = new System.Drawing.Point(133, 439);
            this.HostPortLabel.Name = "HostPortLabel";
            this.HostPortLabel.Size = new System.Drawing.Size(38, 15);
            this.HostPortLabel.TabIndex = 16;
            this.HostPortLabel.Text = "label1";
            // 
            // ReadyBtn
            // 
            this.ReadyBtn.Location = new System.Drawing.Point(736, 279);
            this.ReadyBtn.Name = "ReadyBtn";
            this.ReadyBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadyBtn.TabIndex = 17;
            this.ReadyBtn.Text = "button1";
            this.ReadyBtn.UseVisualStyleBackColor = true;
            // 
            // ReplayBtn
            // 
            this.ReplayBtn.Location = new System.Drawing.Point(741, 375);
            this.ReplayBtn.Name = "ReplayBtn";
            this.ReplayBtn.Size = new System.Drawing.Size(75, 23);
            this.ReplayBtn.TabIndex = 18;
            this.ReplayBtn.Text = "button1";
            this.ReplayBtn.UseVisualStyleBackColor = true;
            // 
            // MenuBtn
            // 
            this.MenuBtn.Location = new System.Drawing.Point(741, 404);
            this.MenuBtn.Name = "MenuBtn";
            this.MenuBtn.Size = new System.Drawing.Size(75, 23);
            this.MenuBtn.TabIndex = 19;
            this.MenuBtn.Text = "button1";
            this.MenuBtn.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(494, 773);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(38, 15);
            this.StatusLabel.TabIndex = 20;
            this.StatusLabel.Text = "label1";
            // 
            // ShipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 797);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.MenuBtn);
            this.Controls.Add(this.ReplayBtn);
            this.Controls.Add(this.ReadyBtn);
            this.Controls.Add(this.HostPortLabel);
            this.Controls.Add(this.HostJoinBtn);
            this.Controls.Add(this.ClientJoinBtn);
            this.Controls.Add(this.HostPortBox);
            this.Controls.Add(this.ClientPortLabel);
            this.Controls.Add(this.ClientIpLabel);
            this.Controls.Add(this.ClientPortBox);
            this.Controls.Add(this.ClientIpBox);
            this.Controls.Add(this.GallBtn);
            this.Controls.Add(this.FrigBtn);
            this.Controls.Add(this.BrigBtn);
            this.Controls.Add(this.SloopBtn);
            this.Controls.Add(this.JoinModeBtn);
            this.Controls.Add(this.HostModeBtn);
            this.Controls.Add(this.MultiBtn);
            this.Controls.Add(this.SingleBtn);
            this.Controls.Add(this.fullscreenBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ShipsForm";
            this.Text = "Ships - Josef Lukasek";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fullscreenBtn;
        private System.Windows.Forms.Button SingleBtn;
        private System.Windows.Forms.Button MultiBtn;
        private System.Windows.Forms.Button HostModeBtn;
        private System.Windows.Forms.Button JoinModeBtn;
        private System.Windows.Forms.Button SloopBtn;
        private System.Windows.Forms.Button BrigBtn;
        private System.Windows.Forms.Button FrigBtn;
        private System.Windows.Forms.Button GallBtn;
        private System.Windows.Forms.TextBox ClientIpBox;
        private System.Windows.Forms.TextBox ClientPortBox;
        private System.Windows.Forms.Label ClientIpLabel;
        private System.Windows.Forms.Label ClientPortLabel;
        private System.Windows.Forms.TextBox HostPortBox;
        private System.Windows.Forms.Button ClientJoinBtn;
        private System.Windows.Forms.Button HostJoinBtn;
        private System.Windows.Forms.Label HostPortLabel;
        private System.Windows.Forms.Button ReadyBtn;
        private System.Windows.Forms.Button ReplayBtn;
        private System.Windows.Forms.Button MenuBtn;
        private System.Windows.Forms.Label StatusLabel;
    }
}
