namespace Seminarska
{
    partial class Form2
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
            this.lblScore = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbTryAgain2 = new System.Windows.Forms.PictureBox();
            this.pbQuit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTryAgain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(177, 86);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(54, 24);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "0 pts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(135, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Your Score: ";
            // 
            // pbTryAgain2
            // 
            this.pbTryAgain2.BackgroundImage = global::Seminarska.Properties.Resources.try_again_button;
            this.pbTryAgain2.Location = new System.Drawing.Point(29, 147);
            this.pbTryAgain2.Name = "pbTryAgain2";
            this.pbTryAgain2.Size = new System.Drawing.Size(144, 60);
            this.pbTryAgain2.TabIndex = 6;
            this.pbTryAgain2.TabStop = false;
            this.pbTryAgain2.Click += new System.EventHandler(this.pbTryAgain2_Click);
            // 
            // pbQuit
            // 
            this.pbQuit.BackgroundImage = global::Seminarska.Properties.Resources.exit;
            this.pbQuit.Location = new System.Drawing.Point(268, 136);
            this.pbQuit.Name = "pbQuit";
            this.pbQuit.Size = new System.Drawing.Size(80, 80);
            this.pbQuit.TabIndex = 7;
            this.pbQuit.TabStop = false;
            this.pbQuit.Click += new System.EventHandler(this.pbQuit_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 242);
            this.Controls.Add(this.pbQuit);
            this.Controls.Add(this.pbTryAgain2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblScore);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "You lost";
            ((System.ComponentModel.ISupportInitialize)(this.pbTryAgain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbTryAgain2;
        private System.Windows.Forms.PictureBox pbQuit;
    }
}