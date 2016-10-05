namespace Kodoviy_zamok_01
{
    partial class Panel2
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
            this.Open_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Open_button
            // 
            this.Open_button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Open_button.BackgroundImage = global::Kodoviy_zamok_01.Properties.Resources.ekokozha_chernaya_matovaya1;
            this.Open_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Open_button.Font = new System.Drawing.Font("Rockwell Extra Bold", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Open_button.ForeColor = System.Drawing.Color.Yellow;
            this.Open_button.Location = new System.Drawing.Point(43, 68);
            this.Open_button.Name = "Open_button";
            this.Open_button.Size = new System.Drawing.Size(191, 153);
            this.Open_button.TabIndex = 0;
            this.Open_button.Text = "Open";
            this.Open_button.UseVisualStyleBackColor = false;
            this.Open_button.Click += new System.EventHandler(this.Open_button_Click);
            // 
            // BackDoorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kodoviy_zamok_01.Properties.Resources.plastik_back_knopky_1_33_300x225;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.Open_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BackDoorPanel";
            this.Text = "BackDoorPanel";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button Open_button;

    }
}