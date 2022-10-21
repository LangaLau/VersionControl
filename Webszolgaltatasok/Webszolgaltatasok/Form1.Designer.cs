
namespace Webszolgaltatasok
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
            this.dgwRates = new System.Windows.Forms.DataGridView();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBoxCurrency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRates)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwRates
            // 
            this.dgwRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwRates.Location = new System.Drawing.Point(12, 57);
            this.dgwRates.Name = "dgwRates";
            this.dgwRates.RowHeadersWidth = 51;
            this.dgwRates.RowTemplate.Height = 24;
            this.dgwRates.Size = new System.Drawing.Size(411, 381);
            this.dgwRates.TabIndex = 0;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(29, 29);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(99, 22);
            this.dtpStart.TabIndex = 1;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(157, 29);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(115, 22);
            this.dtpEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "End:";
            // 
            // cbBoxCurrency
            // 
            this.cbBoxCurrency.FormattingEnabled = true;
            this.cbBoxCurrency.Location = new System.Drawing.Point(302, 26);
            this.cbBoxCurrency.Name = "cbBoxCurrency";
            this.cbBoxCurrency.Size = new System.Drawing.Size(121, 24);
            this.cbBoxCurrency.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Currency:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBoxCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dgwRates);
            this.Name = "Form1";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.dgwRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwRates;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBoxCurrency;
        private System.Windows.Forms.Label label3;
    }
}

