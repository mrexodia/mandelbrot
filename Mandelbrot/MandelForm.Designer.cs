namespace Mandelbrot
{
    partial class MandelForm
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
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelScale = new System.Windows.Forms.Label();
            this.textBoxScale = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMiddleY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMiddleX = new System.Windows.Forms.TextBox();
            this.comboBoxColors = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(12, 459);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "&Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(276, 490);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(108, 20);
            this.textBoxMax.TabIndex = 3;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(240, 493);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(30, 13);
            this.labelMax.TabIndex = 4;
            this.labelMax.Text = "Max:";
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(233, 467);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(37, 13);
            this.labelScale.TabIndex = 6;
            this.labelScale.Text = "Scale:";
            // 
            // textBoxScale
            // 
            this.textBoxScale.Location = new System.Drawing.Point(276, 464);
            this.textBoxScale.Name = "textBoxScale";
            this.textBoxScale.Size = new System.Drawing.Size(108, 20);
            this.textBoxScale.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Middle Y:";
            // 
            // textBoxMiddleY
            // 
            this.textBoxMiddleY.Location = new System.Drawing.Point(448, 490);
            this.textBoxMiddleY.Name = "textBoxMiddleY";
            this.textBoxMiddleY.Size = new System.Drawing.Size(121, 20);
            this.textBoxMiddleY.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Middle X:";
            // 
            // textBoxMiddleX
            // 
            this.textBoxMiddleX.Location = new System.Drawing.Point(448, 464);
            this.textBoxMiddleX.Name = "textBoxMiddleX";
            this.textBoxMiddleX.Size = new System.Drawing.Size(121, 20);
            this.textBoxMiddleX.TabIndex = 9;
            // 
            // comboBoxColors
            // 
            this.comboBoxColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColors.FormattingEnabled = true;
            this.comboBoxColors.Location = new System.Drawing.Point(88, 489);
            this.comboBoxColors.Name = "comboBoxColors";
            this.comboBoxColors.Size = new System.Drawing.Size(121, 21);
            this.comboBoxColors.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Color Filter:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 522);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxColors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMiddleX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMiddleY);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.textBoxScale);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.mandelPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mandelbrot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mandelPanel;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.TextBox textBoxScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMiddleY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMiddleX;
        private System.Windows.Forms.ComboBox comboBoxColors;
        private System.Windows.Forms.Label label3;
    }
}

