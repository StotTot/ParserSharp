
namespace ParserSharp
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
            this.components = new System.ComponentModel.Container();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.parseButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.receiptImage = new System.Windows.Forms.PictureBox();
            this.receiptGrid = new System.Windows.Forms.DataGridView();
            this.receiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receiptBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAXES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.receiptImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(12, 33);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(264, 20);
            this.urlBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // parseButton
            // 
            this.parseButton.Location = new System.Drawing.Point(302, 30);
            this.parseButton.Name = "parseButton";
            this.parseButton.Size = new System.Drawing.Size(116, 23);
            this.parseButton.TabIndex = 2;
            this.parseButton.Text = "Parse";
            this.parseButton.UseVisualStyleBackColor = true;
            this.parseButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(302, 60);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(116, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // receiptImage
            // 
            this.receiptImage.Location = new System.Drawing.Point(302, 92);
            this.receiptImage.Name = "receiptImage";
            this.receiptImage.Size = new System.Drawing.Size(224, 342);
            this.receiptImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.receiptImage.TabIndex = 9;
            this.receiptImage.TabStop = false;
            this.receiptImage.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // receiptGrid
            // 
            this.receiptGrid.AllowUserToAddRows = false;
            this.receiptGrid.AllowUserToDeleteRows = false;
            this.receiptGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.receiptGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TOTAL,
            this.TAXES,
            this.DATE});
            this.receiptGrid.Location = new System.Drawing.Point(12, 92);
            this.receiptGrid.Name = "receiptGrid";
            this.receiptGrid.ReadOnly = true;
            this.receiptGrid.Size = new System.Drawing.Size(263, 342);
            this.receiptGrid.TabIndex = 10;
            this.receiptGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.receiptGrid_CellContentClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 59);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(263, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ID.Width = 30;
            // 
            // TOTAL
            // 
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            this.TOTAL.Width = 60;
            // 
            // TAXES
            // 
            this.TAXES.HeaderText = "TAXES";
            this.TAXES.Name = "TAXES";
            this.TAXES.ReadOnly = true;
            this.TAXES.Width = 60;
            // 
            // DATE
            // 
            this.DATE.HeaderText = "DATE";
            this.DATE.Name = "DATE";
            this.DATE.ReadOnly = true;
            this.DATE.Width = 70;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 455);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.receiptGrid);
            this.Controls.Add(this.receiptImage);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.parseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlBox);
            this.Name = "Form1";
            this.Text = "Parser Sharp";
            ((System.ComponentModel.ISupportInitialize)(this.receiptImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button parseButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.PictureBox receiptImage;
        private System.Windows.Forms.DataGridView receiptGrid;
        private System.Windows.Forms.BindingSource receiptBindingSource;
        private System.Windows.Forms.BindingSource receiptBindingSource1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewButtonColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAXES;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
    }
}

