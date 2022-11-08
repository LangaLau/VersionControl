
namespace VAR
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
            this.dgvTick = new System.Windows.Forms.DataGridView();
            this.dvgPortfolio = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPortfolio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTick
            // 
            this.dgvTick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTick.Location = new System.Drawing.Point(12, 12);
            this.dgvTick.Name = "dgvTick";
            this.dgvTick.RowHeadersWidth = 51;
            this.dgvTick.RowTemplate.Height = 24;
            this.dgvTick.Size = new System.Drawing.Size(769, 410);
            this.dgvTick.TabIndex = 0;
            // 
            // dvgPortfolio
            // 
            this.dvgPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPortfolio.Location = new System.Drawing.Point(802, 12);
            this.dvgPortfolio.Name = "dvgPortfolio";
            this.dvgPortfolio.RowHeadersWidth = 51;
            this.dvgPortfolio.RowTemplate.Height = 24;
            this.dvgPortfolio.Size = new System.Drawing.Size(340, 151);
            this.dvgPortfolio.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(802, 179);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 52);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Mentés";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dvgPortfolio);
            this.Controls.Add(this.dgvTick);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPortfolio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTick;
        private System.Windows.Forms.DataGridView dvgPortfolio;
        private System.Windows.Forms.Button btnSave;
    }
}

