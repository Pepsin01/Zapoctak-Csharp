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
            fullscreenBtn = new System.Windows.Forms.Button();
            SingleBtn = new System.Windows.Forms.Button();
            MultiBtn = new System.Windows.Forms.Button();
            HostModeBtn = new System.Windows.Forms.Button();
            JoinModeBtn = new System.Windows.Forms.Button();
            SloopBtn = new System.Windows.Forms.Button();
            BrigBtn = new System.Windows.Forms.Button();
            FrigBtn = new System.Windows.Forms.Button();
            GallBtn = new System.Windows.Forms.Button();
            ClientIpBox = new System.Windows.Forms.TextBox();
            ClientPortBox = new System.Windows.Forms.TextBox();
            ClientIpLabel = new System.Windows.Forms.Label();
            ClientPortLabel = new System.Windows.Forms.Label();
            HostPortBox = new System.Windows.Forms.TextBox();
            ClientJoinBtn = new System.Windows.Forms.Button();
            HostJoinBtn = new System.Windows.Forms.Button();
            HostPortLabel = new System.Windows.Forms.Label();
            ReadyBtn = new System.Windows.Forms.Button();
            ReplayBtn = new System.Windows.Forms.Button();
            MenuBtn = new System.Windows.Forms.Button();
            StatusLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // fullscreenBtn
            // 
            fullscreenBtn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            fullscreenBtn.Location = new System.Drawing.Point(1025, 12);
            fullscreenBtn.Name = "fullscreenBtn";
            fullscreenBtn.Size = new System.Drawing.Size(107, 23);
            fullscreenBtn.TabIndex = 0;
            fullscreenBtn.Text = "Toggle Fullscreen";
            fullscreenBtn.UseVisualStyleBackColor = true;
            fullscreenBtn.Click += fullscreenBtn_Click;
            // 
            // SingleBtn
            // 
            SingleBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            SingleBtn.Location = new System.Drawing.Point(479, 287);
            SingleBtn.Name = "SingleBtn";
            SingleBtn.Size = new System.Drawing.Size(153, 47);
            SingleBtn.TabIndex = 1;
            SingleBtn.Text = "Singleplayer";
            SingleBtn.UseVisualStyleBackColor = true;
            // 
            // MultiBtn
            // 
            MultiBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            MultiBtn.Location = new System.Drawing.Point(479, 340);
            MultiBtn.Name = "MultiBtn";
            MultiBtn.Size = new System.Drawing.Size(153, 43);
            MultiBtn.TabIndex = 2;
            MultiBtn.Text = "Multiplayer";
            MultiBtn.UseVisualStyleBackColor = true;
            MultiBtn.Click += MultiBtn_Click;
            // 
            // HostModeBtn
            // 
            HostModeBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            HostModeBtn.Location = new System.Drawing.Point(479, 287);
            HostModeBtn.Name = "HostModeBtn";
            HostModeBtn.Size = new System.Drawing.Size(153, 47);
            HostModeBtn.TabIndex = 3;
            HostModeBtn.Text = "Host game";
            HostModeBtn.UseVisualStyleBackColor = true;
            HostModeBtn.Visible = false;
            HostModeBtn.Click += HostModeBtn_Click;
            // 
            // JoinModeBtn
            // 
            JoinModeBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            JoinModeBtn.Location = new System.Drawing.Point(479, 340);
            JoinModeBtn.Name = "JoinModeBtn";
            JoinModeBtn.Size = new System.Drawing.Size(153, 43);
            JoinModeBtn.TabIndex = 4;
            JoinModeBtn.Text = "Join game";
            JoinModeBtn.UseVisualStyleBackColor = true;
            JoinModeBtn.Visible = false;
            JoinModeBtn.Click += JoinModeBtn_Click;
            // 
            // SloopBtn
            // 
            SloopBtn.Location = new System.Drawing.Point(12, 12);
            SloopBtn.Name = "SloopBtn";
            SloopBtn.Size = new System.Drawing.Size(123, 23);
            SloopBtn.TabIndex = 5;
            SloopBtn.Text = "Sloop (1x1)";
            SloopBtn.UseVisualStyleBackColor = true;
            SloopBtn.Click += SloopBtn_Click;
            // 
            // BrigBtn
            // 
            BrigBtn.Location = new System.Drawing.Point(12, 41);
            BrigBtn.Name = "BrigBtn";
            BrigBtn.Size = new System.Drawing.Size(123, 23);
            BrigBtn.TabIndex = 6;
            BrigBtn.Text = "Brigantine (1x2)";
            BrigBtn.UseVisualStyleBackColor = true;
            BrigBtn.Click += BrigBtn_Click;
            // 
            // FrigBtn
            // 
            FrigBtn.Location = new System.Drawing.Point(12, 70);
            FrigBtn.Name = "FrigBtn";
            FrigBtn.Size = new System.Drawing.Size(123, 23);
            FrigBtn.TabIndex = 7;
            FrigBtn.Text = "Frigate (1x3)";
            FrigBtn.UseVisualStyleBackColor = true;
            FrigBtn.Click += FrigBtn_Click;
            // 
            // GallBtn
            // 
            GallBtn.Location = new System.Drawing.Point(12, 99);
            GallBtn.Name = "GallBtn";
            GallBtn.Size = new System.Drawing.Size(123, 23);
            GallBtn.TabIndex = 8;
            GallBtn.Text = "Galleon (1x4)";
            GallBtn.UseVisualStyleBackColor = true;
            GallBtn.Click += GallBtn_Click;
            // 
            // ClientIpBox
            // 
            ClientIpBox.Location = new System.Drawing.Point(177, 311);
            ClientIpBox.Name = "ClientIpBox";
            ClientIpBox.Size = new System.Drawing.Size(100, 23);
            ClientIpBox.TabIndex = 9;
            // 
            // ClientPortBox
            // 
            ClientPortBox.Location = new System.Drawing.Point(177, 340);
            ClientPortBox.Name = "ClientPortBox";
            ClientPortBox.Size = new System.Drawing.Size(100, 23);
            ClientPortBox.TabIndex = 10;
            // 
            // ClientIpLabel
            // 
            ClientIpLabel.AutoSize = true;
            ClientIpLabel.Location = new System.Drawing.Point(133, 314);
            ClientIpLabel.Name = "ClientIpLabel";
            ClientIpLabel.Size = new System.Drawing.Size(20, 15);
            ClientIpLabel.TabIndex = 11;
            ClientIpLabel.Text = "IP:";
            // 
            // ClientPortLabel
            // 
            ClientPortLabel.AutoSize = true;
            ClientPortLabel.Location = new System.Drawing.Point(133, 343);
            ClientPortLabel.Name = "ClientPortLabel";
            ClientPortLabel.Size = new System.Drawing.Size(32, 15);
            ClientPortLabel.TabIndex = 12;
            ClientPortLabel.Text = "Port:";
            // 
            // HostPortBox
            // 
            HostPortBox.Location = new System.Drawing.Point(177, 436);
            HostPortBox.Name = "HostPortBox";
            HostPortBox.Size = new System.Drawing.Size(100, 23);
            HostPortBox.TabIndex = 13;
            // 
            // ClientJoinBtn
            // 
            ClientJoinBtn.Location = new System.Drawing.Point(177, 369);
            ClientJoinBtn.Name = "ClientJoinBtn";
            ClientJoinBtn.Size = new System.Drawing.Size(100, 23);
            ClientJoinBtn.TabIndex = 14;
            ClientJoinBtn.Text = "Join";
            ClientJoinBtn.UseVisualStyleBackColor = true;
            ClientJoinBtn.Click += ClientJoinBtn_Click;
            // 
            // HostJoinBtn
            // 
            HostJoinBtn.Location = new System.Drawing.Point(177, 465);
            HostJoinBtn.Name = "HostJoinBtn";
            HostJoinBtn.Size = new System.Drawing.Size(100, 23);
            HostJoinBtn.TabIndex = 15;
            HostJoinBtn.Text = "Host";
            HostJoinBtn.UseVisualStyleBackColor = true;
            HostJoinBtn.Click += HostJoinBtn_Click;
            // 
            // HostPortLabel
            // 
            HostPortLabel.AutoSize = true;
            HostPortLabel.Location = new System.Drawing.Point(133, 439);
            HostPortLabel.Name = "HostPortLabel";
            HostPortLabel.Size = new System.Drawing.Size(29, 15);
            HostPortLabel.TabIndex = 16;
            HostPortLabel.Text = "Port";
            // 
            // ReadyBtn
            // 
            ReadyBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ReadyBtn.Location = new System.Drawing.Point(12, 715);
            ReadyBtn.Name = "ReadyBtn";
            ReadyBtn.Size = new System.Drawing.Size(312, 66);
            ReadyBtn.TabIndex = 17;
            ReadyBtn.Text = "Ready";
            ReadyBtn.UseVisualStyleBackColor = true;
            ReadyBtn.Click += ReadyBtn_Click;
            // 
            // ReplayBtn
            // 
            ReplayBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            ReplayBtn.Location = new System.Drawing.Point(479, 343);
            ReplayBtn.Name = "ReplayBtn";
            ReplayBtn.Size = new System.Drawing.Size(153, 43);
            ReplayBtn.TabIndex = 18;
            ReplayBtn.Text = "Play again";
            ReplayBtn.UseVisualStyleBackColor = true;
            ReplayBtn.Click += ReplayBtn_Click;
            // 
            // MenuBtn
            // 
            MenuBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            MenuBtn.Location = new System.Drawing.Point(479, 287);
            MenuBtn.Name = "MenuBtn";
            MenuBtn.Size = new System.Drawing.Size(153, 47);
            MenuBtn.TabIndex = 19;
            MenuBtn.Text = "Main menu";
            MenuBtn.UseVisualStyleBackColor = true;
            MenuBtn.Click += MenuBtn_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            StatusLabel.AutoSize = true;
            StatusLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StatusLabel.Location = new System.Drawing.Point(479, 752);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(134, 32);
            StatusLabel.TabIndex = 20;
            StatusLabel.Text = "StatusLabel";
            // 
            // ShipsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1144, 793);
            Controls.Add(StatusLabel);
            Controls.Add(MenuBtn);
            Controls.Add(ReplayBtn);
            Controls.Add(ReadyBtn);
            Controls.Add(HostPortLabel);
            Controls.Add(HostJoinBtn);
            Controls.Add(ClientJoinBtn);
            Controls.Add(HostPortBox);
            Controls.Add(ClientPortLabel);
            Controls.Add(ClientIpLabel);
            Controls.Add(ClientPortBox);
            Controls.Add(ClientIpBox);
            Controls.Add(GallBtn);
            Controls.Add(FrigBtn);
            Controls.Add(BrigBtn);
            Controls.Add(SloopBtn);
            Controls.Add(JoinModeBtn);
            Controls.Add(HostModeBtn);
            Controls.Add(MultiBtn);
            Controls.Add(SingleBtn);
            Controls.Add(fullscreenBtn);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "ShipsForm";
            Text = "Ships - Josef Lukasek";
            KeyDown += Form1_KeyDown;
            Resize += Form1_Resize;
            ResumeLayout(false);
            PerformLayout();
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
