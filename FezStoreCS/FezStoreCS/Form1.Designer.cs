namespace FezStoreCS
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
            this.cbFezStyle = new System.Windows.Forms.ComboBox();
            this.cbFezSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbLongDesc = new System.Windows.Forms.RichTextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbFezStyle
            // 
            this.cbFezStyle.FormattingEnabled = true;
            this.cbFezStyle.Location = new System.Drawing.Point(16, 26);
            this.cbFezStyle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFezStyle.Name = "cbFezStyle";
            this.cbFezStyle.Size = new System.Drawing.Size(169, 21);
            this.cbFezStyle.TabIndex = 0;
            this.cbFezStyle.SelectedIndexChanged += new System.EventHandler(this.cbFezStyle_SelectedIndexChanged);
            // 
            // cbFezSize
            // 
            this.cbFezSize.FormattingEnabled = true;
            this.cbFezSize.Location = new System.Drawing.Point(208, 25);
            this.cbFezSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFezSize.Name = "cbFezSize";
            this.cbFezSize.Size = new System.Drawing.Size(195, 21);
            this.cbFezSize.TabIndex = 1;
            this.cbFezSize.SelectedIndexChanged += new System.EventHandler(this.cbFezSize_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Style:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Style description:";
            // 
            // rtbLongDesc
            // 
            this.rtbLongDesc.Location = new System.Drawing.Point(22, 80);
            this.rtbLongDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbLongDesc.Name = "rtbLongDesc";
            this.rtbLongDesc.Size = new System.Drawing.Size(264, 118);
            this.rtbLongDesc.TabIndex = 5;
            this.rtbLongDesc.Text = "";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPrice.Location = new System.Drawing.Point(311, 106);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(49, 20);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "£0.00";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(315, 172);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 7;
            this.add_button.Text = "Add";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 207);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.rtbLongDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFezSize);
            this.Controls.Add(this.cbFezStyle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "FezStoreCS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFezStyle;
        private System.Windows.Forms.ComboBox cbFezSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbLongDesc;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button add_button;
    }
}

