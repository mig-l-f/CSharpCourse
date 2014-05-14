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
            this.itemsListTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // itemsListTextBox
            // 
            this.itemsListTextBox.Location = new System.Drawing.Point(12, 23);
            this.itemsListTextBox.Multiline = true;
            this.itemsListTextBox.Name = "itemsListTextBox";
            this.itemsListTextBox.Size = new System.Drawing.Size(260, 226);
            this.itemsListTextBox.TabIndex = 0;
            this.itemsListTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ReceiptView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.itemsListTextBox);
            this.Name = "ReceiptView";
            this.Text = "ReceiptView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox itemsListTextBox;

    }
}