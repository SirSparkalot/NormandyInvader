namespace GDIplusAnimations
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmr_Enemy = new System.Windows.Forms.Timer(this.components);
            this.tmr_Projectiles = new System.Windows.Forms.Timer(this.components);
            this.tmr_MotherShip = new System.Windows.Forms.Timer(this.components);
            this.tmr_EnemyProjectil = new System.Windows.Forms.Timer(this.components);
            this.tmr_MoveEnemy = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmr_Enemy
            // 
            this.tmr_Enemy.Interval = 84;
            this.tmr_Enemy.Tick += new System.EventHandler(this.tmr_Enemy_Tick);
            // 
            // tmr_Projectiles
            // 
            this.tmr_Projectiles.Interval = 42;
            this.tmr_Projectiles.Tick += new System.EventHandler(this.tmr_Projectiles_Tick);
            // 
            // tmr_MotherShip
            // 
            this.tmr_MotherShip.Interval = 12000;
            // 
            // tmr_EnemyProjectil
            // 
            this.tmr_EnemyProjectil.Interval = 4000;
            this.tmr_EnemyProjectil.Tick += new System.EventHandler(this.tmr_EnemyProjectil_Tick);
            // 
            // tmr_MoveEnemy
            // 
            this.tmr_MoveEnemy.Interval = 42;
            this.tmr_MoveEnemy.Tick += new System.EventHandler(this.tmr_MoveEnemy_Tick_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 612);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1353, 1468);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GDIplusAnimationen";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmr_Enemy;
        private System.Windows.Forms.Timer tmr_Projectiles;
        private System.Windows.Forms.Timer tmr_MotherShip;
        private System.Windows.Forms.Timer tmr_EnemyProjectil;
        private System.Windows.Forms.Timer tmr_MoveEnemy;
    }
}

