
namespace WinFormsApp_EmployeeManagement
{
    partial class FrmEmployee
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
            this.LbEmployeeID = new System.Windows.Forms.Label();
            this.LbEmployeeName = new System.Windows.Forms.Label();
            this.LbYearOfBirth = new System.Windows.Forms.Label();
            this.LbDepartmentName = new System.Windows.Forms.Label();
            this.LbJobTitle = new System.Windows.Forms.Label();
            this.TxtEmployeeId = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.TxtDepartmentName = new System.Windows.Forms.TextBox();
            this.CbbJobTitle = new System.Windows.Forms.ComboBox();
            this.BtnAction = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TxtYearOfBirth = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbEmployeeID
            // 
            this.LbEmployeeID.AutoSize = true;
            this.LbEmployeeID.Location = new System.Drawing.Point(163, 81);
            this.LbEmployeeID.Name = "LbEmployeeID";
            this.LbEmployeeID.Size = new System.Drawing.Size(124, 24);
            this.LbEmployeeID.TabIndex = 0;
            this.LbEmployeeID.Text = "Employee ID: ";
            // 
            // LbEmployeeName
            // 
            this.LbEmployeeName.AutoSize = true;
            this.LbEmployeeName.Location = new System.Drawing.Point(163, 150);
            this.LbEmployeeName.Name = "LbEmployeeName";
            this.LbEmployeeName.Size = new System.Drawing.Size(154, 24);
            this.LbEmployeeName.TabIndex = 1;
            this.LbEmployeeName.Text = "Employee name: ";
            // 
            // LbYearOfBirth
            // 
            this.LbYearOfBirth.AutoSize = true;
            this.LbYearOfBirth.Location = new System.Drawing.Point(163, 222);
            this.LbYearOfBirth.Name = "LbYearOfBirth";
            this.LbYearOfBirth.Size = new System.Drawing.Size(119, 24);
            this.LbYearOfBirth.TabIndex = 2;
            this.LbYearOfBirth.Text = "Year of Birth:";
            // 
            // LbDepartmentName
            // 
            this.LbDepartmentName.AutoSize = true;
            this.LbDepartmentName.Location = new System.Drawing.Point(163, 296);
            this.LbDepartmentName.Name = "LbDepartmentName";
            this.LbDepartmentName.Size = new System.Drawing.Size(170, 24);
            this.LbDepartmentName.TabIndex = 3;
            this.LbDepartmentName.Text = "Department Name:";
            // 
            // LbJobTitle
            // 
            this.LbJobTitle.AutoSize = true;
            this.LbJobTitle.Location = new System.Drawing.Point(163, 356);
            this.LbJobTitle.Name = "LbJobTitle";
            this.LbJobTitle.Size = new System.Drawing.Size(85, 24);
            this.LbJobTitle.TabIndex = 4;
            this.LbJobTitle.Text = "Job Title:";
            // 
            // TxtEmployeeId
            // 
            this.TxtEmployeeId.Location = new System.Drawing.Point(383, 73);
            this.TxtEmployeeId.Name = "TxtEmployeeId";
            this.TxtEmployeeId.Size = new System.Drawing.Size(319, 32);
            this.TxtEmployeeId.TabIndex = 5;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(383, 142);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(319, 32);
            this.txtEmployeeName.TabIndex = 6;
            // 
            // TxtDepartmentName
            // 
            this.TxtDepartmentName.Location = new System.Drawing.Point(383, 288);
            this.TxtDepartmentName.Name = "TxtDepartmentName";
            this.TxtDepartmentName.Size = new System.Drawing.Size(319, 32);
            this.TxtDepartmentName.TabIndex = 8;
            // 
            // CbbJobTitle
            // 
            this.CbbJobTitle.FormattingEnabled = true;
            this.CbbJobTitle.Location = new System.Drawing.Point(383, 348);
            this.CbbJobTitle.Name = "CbbJobTitle";
            this.CbbJobTitle.Size = new System.Drawing.Size(319, 32);
            this.CbbJobTitle.TabIndex = 9;
            // 
            // BtnAction
            // 
            this.BtnAction.Location = new System.Drawing.Point(578, 456);
            this.BtnAction.Name = "BtnAction";
            this.BtnAction.Size = new System.Drawing.Size(124, 45);
            this.BtnAction.TabIndex = 10;
            this.BtnAction.Text = "button1";
            this.BtnAction.UseVisualStyleBackColor = true;
            this.BtnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(322, 456);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(124, 45);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtYearOfBirth
            // 
            this.TxtYearOfBirth.Location = new System.Drawing.Point(383, 214);
            this.TxtYearOfBirth.Name = "TxtYearOfBirth";
            this.TxtYearOfBirth.Size = new System.Drawing.Size(319, 32);
            this.TxtYearOfBirth.TabIndex = 7;
            // 
            // FrmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnAction);
            this.Controls.Add(this.CbbJobTitle);
            this.Controls.Add(this.TxtDepartmentName);
            this.Controls.Add(this.TxtYearOfBirth);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.TxtEmployeeId);
            this.Controls.Add(this.LbJobTitle);
            this.Controls.Add(this.LbDepartmentName);
            this.Controls.Add(this.LbYearOfBirth);
            this.Controls.Add(this.LbEmployeeName);
            this.Controls.Add(this.LbEmployeeID);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEmployee";
            this.Text = "FrmEmployee";
            this.Load += new System.EventHandler(this.FrmEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbEmployeeID;
        private System.Windows.Forms.Label LbEmployeeName;
        private System.Windows.Forms.Label LbYearOfBirth;
        private System.Windows.Forms.Label LbDepartmentName;
        private System.Windows.Forms.Label LbJobTitle;
        private System.Windows.Forms.TextBox TxtEmployeeId;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox TxtDepartmentName;
        private System.Windows.Forms.ComboBox CbbJobTitle;
        private System.Windows.Forms.Button BtnAction;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtYearOfBirth;
    }
}