namespace Ships_JosefLukasek
{
    partial class Form1
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
            this.fullscreenBtn = new System.Windows.Forms.Button();
            this.SingleBtn = new System.Windows.Forms.Button();
            this.MultiBtn = new System.Windows.Forms.Button();
            this.HostModeBtn = new System.Windows.Forms.Button();
            this.JoinModeBtn = new System.Windows.Forms.Button();
            this.SloopBtn = new System.Windows.Forms.Button();
            this.BrigBtn = new System.Windows.Forms.Button();
            this.FrigBtn = new System.Windows.Forms.Button();
            this.GallBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.SingleBtn.Location = new System.Drawing.Point(486, 245);
            this.SingleBtn.Name = "SingleBtn";
            this.SingleBtn.Size = new System.Drawing.Size(153, 47);
            this.SingleBtn.TabIndex = 1;
            this.SingleBtn.Text = "Singleplayer";
            this.SingleBtn.UseVisualStyleBackColor = true;
            // 
            // MultiBtn
            // 
            this.MultiBtn.Location = new System.Drawing.Point(486, 298);
            this.MultiBtn.Name = "MultiBtn";
            this.MultiBtn.Size = new System.Drawing.Size(153, 43);
            this.MultiBtn.TabIndex = 2;
            this.MultiBtn.Text = "Multiplayer";
            this.MultiBtn.UseVisualStyleBackColor = true;
            // 
            // HostModeBtn
            // 
            this.HostModeBtn.Location = new System.Drawing.Point(486, 245);
            this.HostModeBtn.Name = "HostModeBtn";
            this.HostModeBtn.Size = new System.Drawing.Size(153, 47);
            this.HostModeBtn.TabIndex = 3;
            this.HostModeBtn.Text = "Host game";
            this.HostModeBtn.UseVisualStyleBackColor = true;
            this.HostModeBtn.Visible = false;
            // 
            // JoinModeBtn
            // 
            this.JoinModeBtn.Location = new System.Drawing.Point(486, 298);
            this.JoinModeBtn.Name = "JoinModeBtn";
            this.JoinModeBtn.Size = new System.Drawing.Size(153, 43);
            this.JoinModeBtn.TabIndex = 4;
            this.JoinModeBtn.Text = "Join game";
            this.JoinModeBtn.UseVisualStyleBackColor = true;
            this.JoinModeBtn.Visible = false;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 797);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GallBtn);
            this.Controls.Add(this.FrigBtn);
            this.Controls.Add(this.BrigBtn);
            this.Controls.Add(this.SloopBtn);
            this.Controls.Add(this.JoinModeBtn);
            this.Controls.Add(this.HostModeBtn);
            this.Controls.Add(this.MultiBtn);
            this.Controls.Add(this.SingleBtn);
            this.Controls.Add(this.fullscreenBtn);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button button1;
    }
}
