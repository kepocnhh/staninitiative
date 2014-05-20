namespace SearchResultsViewer
{
    partial class Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.btnGoogleSearch = new System.Windows.Forms.Button();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGoogleSearch
            // 
            this.btnGoogleSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGoogleSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnGoogleSearch.Location = new System.Drawing.Point(18, 182);
            this.btnGoogleSearch.Name = "btnGoogleSearch";
            this.btnGoogleSearch.Size = new System.Drawing.Size(400, 37);
            this.btnGoogleSearch.TabIndex = 0;
            this.btnGoogleSearch.Text = "Google Search";
            this.btnGoogleSearch.UseVisualStyleBackColor = true;
            this.btnGoogleSearch.Click += new System.EventHandler(this.btnGoogleSearch_Click);
            // 
            // tbQuery
            // 
            this.tbQuery.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbQuery.Location = new System.Drawing.Point(18, 140);
            this.tbQuery.MaximumSize = new System.Drawing.Size(400, 30);
            this.tbQuery.MinimumSize = new System.Drawing.Size(400, 30);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(400, 20);
            this.tbQuery.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(37, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // dgvResults
            // 
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvResults.Location = new System.Drawing.Point(0, 249);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(450, 270);
            this.dgvResults.TabIndex = 3;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 519);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbQuery);
            this.Controls.Add(this.btnGoogleSearch);
            this.Name = "Viewer";
            this.Text = "Google Search Results Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGoogleSearch;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}

