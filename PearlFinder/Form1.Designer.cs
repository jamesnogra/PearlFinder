namespace PearlFinder
{
    partial class Form1
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
            this.allPearlsPicbox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.patternPicbox = new System.Windows.Forms.PictureBox();
            this.findButton = new System.Windows.Forms.Button();
            this.testOutputPicBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.allPearlsPicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternPicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testOutputPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // allPearlsPicbox
            // 
            this.allPearlsPicbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.allPearlsPicbox.Location = new System.Drawing.Point(13, 13);
            this.allPearlsPicbox.Name = "allPearlsPicbox";
            this.allPearlsPicbox.Size = new System.Drawing.Size(500, 500);
            this.allPearlsPicbox.TabIndex = 0;
            this.allPearlsPicbox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Template";
            // 
            // patternPicbox
            // 
            this.patternPicbox.Location = new System.Drawing.Point(523, 30);
            this.patternPicbox.Name = "patternPicbox";
            this.patternPicbox.Size = new System.Drawing.Size(70, 70);
            this.patternPicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.patternPicbox.TabIndex = 2;
            this.patternPicbox.TabStop = false;
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.findButton.Location = new System.Drawing.Point(523, 225);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(70, 23);
            this.findButton.TabIndex = 3;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // testOutputPicBox
            // 
            this.testOutputPicBox.ErrorImage = null;
            this.testOutputPicBox.InitialImage = null;
            this.testOutputPicBox.Location = new System.Drawing.Point(523, 149);
            this.testOutputPicBox.Name = "testOutputPicBox";
            this.testOutputPicBox.Size = new System.Drawing.Size(70, 70);
            this.testOutputPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.testOutputPicBox.TabIndex = 4;
            this.testOutputPicBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(520, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Scanning at:";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.progressBar.Location = new System.Drawing.Point(523, 254);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(70, 20);
            this.progressBar.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 529);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.testOutputPicBox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.patternPicbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allPearlsPicbox);
            this.Name = "Form1";
            this.Text = "AAA Pearl Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allPearlsPicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternPicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testOutputPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox allPearlsPicbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox patternPicbox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.PictureBox testOutputPicBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

