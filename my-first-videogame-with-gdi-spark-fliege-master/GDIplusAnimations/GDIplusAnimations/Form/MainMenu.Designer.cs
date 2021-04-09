namespace GDIplusAnimations
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tmrMoveing = new System.Windows.Forms.Timer(this.components);
            this.tmr_MovePlane = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("MV Boli", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPlay.Location = new System.Drawing.Point(122, 115);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(157, 52);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.MouseEnter += new System.EventHandler(this.btnPlay_MouseEnter);
            // 
            // btnOption
            // 
            this.btnOption.Font = new System.Drawing.Font("MV Boli", 22.2F, System.Drawing.FontStyle.Bold);
            this.btnOption.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOption.Location = new System.Drawing.Point(122, 197);
            this.btnOption.Margin = new System.Windows.Forms.Padding(2);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(157, 52);
            this.btnOption.TabIndex = 1;
            this.btnOption.Text = "Option";
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            this.btnOption.MouseEnter += new System.EventHandler(this.btnOption_MouseEnter);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("MV Boli", 22.2F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExit.Location = new System.Drawing.Point(122, 288);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(157, 52);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            // 
            // tmrMoveing
            // 
            this.tmrMoveing.Enabled = true;
            this.tmrMoveing.Interval = 42;
            this.tmrMoveing.Tick += new System.EventHandler(this.TmrMoveing_Tick);
            // 
            // tmr_MovePlane
            // 
            this.tmr_MovePlane.Enabled = true;
            this.tmr_MovePlane.Interval = 10;
            this.tmr_MovePlane.Tick += new System.EventHandler(this.tmr_MovePlane_Tick);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(399, 409);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.btnPlay);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(416, 454);
            this.MinimumSize = new System.Drawing.Size(350, 437);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer tmrMoveing;
        private System.Windows.Forms.Timer tmr_MovePlane;
    }
}