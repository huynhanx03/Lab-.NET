
namespace WinFormsApp_EmployeeManagement
{
    partial class FrmManagement
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
            this.PnControls = new System.Windows.Forms.Panel();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtSearchValue = new System.Windows.Forms.TextBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.DgvEmployeeList = new System.Windows.Forms.DataGridView();
            this.PnControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // PnControls
            // 
            this.PnControls.Controls.Add(this.BtnSearch);
            this.PnControls.Controls.Add(this.TxtSearchValue);
            this.PnControls.Controls.Add(this.BtnDelete);
            this.PnControls.Controls.Add(this.BtnUpdate);
            this.PnControls.Controls.Add(this.BtnInsert);
            this.PnControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnControls.Location = new System.Drawing.Point(0, 0);
            this.PnControls.Name = "PnControls";
            this.PnControls.Size = new System.Drawing.Size(1000, 171);
            this.PnControls.TabIndex = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(476, 12);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(94, 32);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtSearchValue
            // 
            this.TxtSearchValue.Location = new System.Drawing.Point(101, 12);
            this.TxtSearchValue.Name = "TxtSearchValue";
            this.TxtSearchValue.Size = new System.Drawing.Size(342, 32);
            this.TxtSearchValue.TabIndex = 3;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(767, 87);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(127, 42);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(443, 87);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(127, 42);
            this.BtnUpdate.TabIndex = 1;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(101, 87);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(127, 42);
            this.BtnInsert.TabIndex = 0;
            this.BtnInsert.Text = "Insert";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // DgvEmployeeList
            // 
            this.DgvEmployeeList.AllowUserToAddRows = false;
            this.DgvEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvEmployeeList.Location = new System.Drawing.Point(0, 171);
            this.DgvEmployeeList.Name = "DgvEmployeeList";
            this.DgvEmployeeList.ReadOnly = true;
            this.DgvEmployeeList.RowHeadersWidth = 51;
            this.DgvEmployeeList.RowTemplate.Height = 29;
            this.DgvEmployeeList.Size = new System.Drawing.Size(1000, 369);
            this.DgvEmployeeList.TabIndex = 1;
            this.DgvEmployeeList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvEmployeeList_CellFormatting);
            // 
            // FrmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.DgvEmployeeList);
            this.Controls.Add(this.PnControls);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmManagement";
            this.Text = "Management";
            this.Load += new System.EventHandler(this.FrmManagement_Load);
            this.PnControls.ResumeLayout(false);
            this.PnControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmployeeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnControls;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.DataGridView DgvEmployeeList;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtSearchValue;
    }
}