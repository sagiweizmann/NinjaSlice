namespace NinjaSlice
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.Loader = new System.Windows.Forms.ProgressBar();
            this.PictureBTNStartGame = new System.Windows.Forms.PictureBox();
            this.StartXna = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBTNStartGame)).BeginInit();
            this.SuspendLayout();
            // 
            // Loader
            // 
            this.Loader.Location = new System.Drawing.Point(25, 386);
            this.Loader.Name = "Loader";
            this.Loader.Size = new System.Drawing.Size(583, 23);
            this.Loader.TabIndex = 0;
            // 
            // PictureBTNStartGame
            // 
            this.PictureBTNStartGame.BackColor = System.Drawing.Color.Transparent;
            this.PictureBTNStartGame.Image = global::NinjaSlice.Resource.startgame;
            this.PictureBTNStartGame.Location = new System.Drawing.Point(182, 237);
            this.PictureBTNStartGame.Name = "PictureBTNStartGame";
            this.PictureBTNStartGame.Size = new System.Drawing.Size(277, 104);
            this.PictureBTNStartGame.TabIndex = 2;
            this.PictureBTNStartGame.TabStop = false;
            this.PictureBTNStartGame.Click += new System.EventHandler(this.PictureBTNStartGame_Click);
            this.PictureBTNStartGame.MouseLeave += new System.EventHandler(this.PictureBTNStartGame_MouseLeave);
            this.PictureBTNStartGame.MouseHover += new System.EventHandler(this.PictureBTNStartGame_MouseHover);
            // 
            // StartXna
            // 
            this.StartXna.Interval = 60;
            this.StartXna.Tick += new System.EventHandler(this.StartXna_Tick);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::NinjaSlice.Resource.launcher;
            this.ClientSize = new System.Drawing.Size(631, 449);
            this.Controls.Add(this.PictureBTNStartGame);
            this.Controls.Add(this.Loader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBTNStartGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar Loader;
        private System.Windows.Forms.PictureBox PictureBTNStartGame;
        private System.Windows.Forms.Timer StartXna;
    }
}