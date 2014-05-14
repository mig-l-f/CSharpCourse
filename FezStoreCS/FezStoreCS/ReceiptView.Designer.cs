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
            this.SuspendLayout();
            // 
            // itemListTextBox
            // 
            this.itemListTextBox.Location = new System.Drawing.Point(13, 13);
            this.itemListTextBox.Name = "itemListTextBox";
            this.itemListTextBox.Size = new System.Drawing.Size(259, 225);
            this.itemListTextBox.TabIndex = 0;
            this.itemListTextBox.Text = "";
            // 
            // ReceiptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.itemListTextBox);
            this.Name = "ReceiptView";
            this.Text = "ReceiptView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox itemListTextBox;


    }
}