namespace Mandelbrot
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
            this.mandelPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mandelPanel
            // 
            this.mandelPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mandelPanel.Location = new System.Drawing.Point(12, 12);
            this.mandelPanel.Name = "mandelPanel";
            this.mandelPanel.Size = new System.Drawing.Size(557, 441);
            this.mandelPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 465);
            this.Controls.Add(this.mandelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mandelbrot";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mandelPanel;
    }
}

