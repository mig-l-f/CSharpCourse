namespace FezStoreCS
{
    partial class ReceiptView
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
            this.itemListTextBox = new System.Windows.Forms.RichTextBox();
            this.totalAmountLabel = new System.Windows.Forms.Label();
            this.totalAmountTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // itemListTextBox
            // 
            this.itemListTextBox.Location = new System.Drawing.Point(13, 13);
            this.itemListTextBox.Name = "itemListTextBox";
            this.itemListTextBox.Size = new System.Drawing.Size(259, 207);
            this.itemListTextBox.TabIndex = 0;
            this.itemListTextBox.Text = "";
            // 
            // totalAmountLabel
            // 
            this.totalAmountLabel.AutoSize = true;
            this.totalAmountLabel.Location = new System.Drawing.Point(100, 236);
            this.totalAmountLabel.Name = "totalAmountLabel";
            this.totalAmountLabel.Size = new System.Drawing.Size(70, 13);
            this.totalAmountLabel.TabIndex = 1;
            this.totalAmountLabel.Text = "Total Amount";
            // 
            // totalAmountTextBox
            // 
            this.totalAmountTextBox.Location = new System.Drawing.Point(189, 232);
            this.totalAmountTextBox.Name = "totalAmountTextBox";
            this.totalAmountTextBox.ReadOnly = true;
            this.totalAmountTextBox.Size = new System.Drawing.Size(83, 20);
            this.totalAmountTextBox.TabIndex = 2;
            this.totalAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ReceiptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.totalAmountTextBox);
            this.Controls.Add(this.totalAmountLabel);
            this.Controls.Add(this.itemListTextBox);
            this.Name = "ReceiptView";
            this.Text = "ReceiptView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox itemListTextBox;
        private System.Windows.Forms.Label totalAmountLabel;
        private System.Windows.Forms.TextBox totalAmountTextBox;


    }
}